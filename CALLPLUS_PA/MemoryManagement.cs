using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CALLPLUS_PA
{
    /// <summary>
    /// Força a limpeza de memória ultilizada pelo programa.
    /// </summary>
    class MemoryManagement
    {
        [DllImport("kernel32.dll")]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public MemoryManagement()
        {
        }

        public void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
}
