using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    internal class DllInjector
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        private const uint MEM_COMMIT = 0x1000;
        private const uint PAGE_READWRITE = 0x04;

        public static void InjectDLL(int processId, string dllPath)
        {
            IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, processId);
            if (processHandle == IntPtr.Zero)
            {
                return;
            }

            // Allocate memory in the target process for the DLL path
            IntPtr allocatedMemory = VirtualAllocEx(processHandle, IntPtr.Zero, (uint)dllPath.Length + 1, MEM_COMMIT, PAGE_READWRITE);
            if (allocatedMemory == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return;
            }

            // Write the DLL path to the allocated memory
            byte[] dllPathBytes = Encoding.ASCII.GetBytes(dllPath);
            if (!WriteProcessMemory(processHandle, allocatedMemory, dllPathBytes, (uint)dllPathBytes.Length, out _))
            {
                CloseHandle(processHandle);
                return;
            }

            // Get the address of LoadLibraryA
            IntPtr loadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLibraryAddress == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return;
            }

            // Create a remote thread to load the DLL
            IntPtr remoteThread = CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddress, allocatedMemory, 0, out _);
            if (remoteThread == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return;
            }
            CloseHandle(remoteThread);
            CloseHandle(processHandle);
        }
    }
}
