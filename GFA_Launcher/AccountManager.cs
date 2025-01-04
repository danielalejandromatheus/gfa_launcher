using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    public class AccountManager
    {
        const string AccountsFilePath = "accountsData.dat";
        const string AccountsKeyPath = "accountsKey.bin";
        private BindingList<AccountData> accounts;
        private BindingList<Item> autoLoginOptions;
        public AccountManager()
        {
            // Load accounts from saved accounts in settings
            accounts = new BindingList<AccountData>();
            autoLoginOptions = new BindingList<Item>
            {
                new Item
                {
                    Value = "",
                    Display = "Do not auto-login"
                }
            };

            accounts.ListChanged += Accounts_ListChanged;
            LoadAccounts();
        }
        private void Accounts_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateAutoLoginOptions();
        }
        private void UpdateAutoLoginOptions()
        {
            var existingItems = autoLoginOptions.Select(item => item.Value).ToHashSet();

            // Add new accounts to the list
            foreach (var account in accounts)
            {
                if (!existingItems.Contains(account.Username))
                {
                    autoLoginOptions.Add(new Item
                    {
                        Value = account.Username,
                        Display = account.Username
                    });
                }
            }

            // Remove items that no longer exist in the accounts
            for (int i = autoLoginOptions.Count - 1; i >= 0; i--)
            {
                var item = autoLoginOptions[i];
                if (item.Value != "" && !accounts.Any(acc => acc.Username == item.Value))
                {
                    autoLoginOptions.RemoveAt(i);
                }
            }
        }
        public bool AddAccount(string username, string password)
        {
            if (accounts.Any(a => a.Username == username))
            {
                return false;
            }
            accounts.Add(new AccountData { Username = username, Secret = Convert.ToBase64String(EncryptionHelper.Encrypt(password)) });
            return true;
        }
        public bool RemoveAccount(int accountIndex)
        {
            // Check if account exists
            if (accountIndex < 0 || accountIndex >= accounts.Count)
            {
                return false;
            }
            accounts.RemoveAt(accountIndex);
            return true;
        }
        public void SaveAccounts()
        {
            var lines = new List<string>();

            foreach (AccountData acc in accounts)
            {
                lines.Add($"{acc.Username}|{acc.Secret}");
            }
            if(File.Exists(AccountsFilePath))
            {
                File.SetAttributes(AccountsFilePath, FileAttributes.Normal);
            }
            File.WriteAllLines(AccountsFilePath, lines);
            File.SetAttributes(AccountsFilePath, FileAttributes.Hidden);
        }

        private void LoadAccounts()
        {
            if (!File.Exists(AccountsFilePath)) return;

            var lines = File.ReadAllLines(AccountsFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 2)
                {
                    accounts.Add(new AccountData { Username = parts[0], Secret = parts[1] });
                }
            }
        }
        public AccountData? GetCurrentAccount(string username)
        {
            var account = accounts.FirstOrDefault(
                a => a.Username == username);
            if (account == null)
            {
                return null;
            }
                return new AccountData
            {
                Username = account.Username,
                Secret = EncryptionHelper.DecryptData(account.Secret)
            };
        }
        public BindingList<AccountData> Accounts
        {
            get => accounts;
        }
        public BindingList<Item> AutoLoginOptions
        {
            get => autoLoginOptions;
        }
        public class AccountData
        {
            public string Username { get; set; }
            public string Secret { get; set; }
        }
    }
}
