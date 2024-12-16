using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    internal class TaskHelper
    {
        public static async Task ExecuteWithRetryAsync(Func<Task> action)
        {
            int delayMilliseconds = 1000;
            while (true)
            {
                try
                {
                    await action();
                    break; // Exit loop if successful
                }
                catch (Exception ex)
                {
                    //Console.WriteLine($"Error: {ex.Message}. Retrying in {delayMilliseconds}ms...");
                    await Task.Delay(delayMilliseconds); // Wait before retrying
                }
            }
        }
        public static async Task ExecuteWithRetryAsync(Func<Task> action, Action<int, string>? onRetryCallback)
        {
            int attempt = 0;
            int delayMilliseconds = 1000;
            while (true)
            {
                try
                {
                    await action();
                    break; // Exit loop if successful
                }
                catch (Exception ex)
                {
                    if (onRetryCallback == null)
                    {
                        attempt++;
                        onRetryCallback?.Invoke(attempt, ex.Message);
                    }
                    //Console.WriteLine($"Error: {ex.Message}. Retrying in {delayMilliseconds}ms...");
                    await Task.Delay(delayMilliseconds); // Wait before retrying
                }
            }
        }
    }
}
