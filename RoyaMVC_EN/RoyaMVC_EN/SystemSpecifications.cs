using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RoyaMVC_EN
{
    public static class SystemSpecifications
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;

            public MEMORYSTATUSEX() {
                //this.dwLength = (uint)Marshal.SizeOf(typeof(NativeMethods.MEMORYSTATUSEX));
                this.dwLength = (uint)Marshal.SizeOf(this);
            }
        }


        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);



        public static ulong GetMemorySize() {
            ulong installedMemory = 0;

            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();

            if (GlobalMemoryStatusEx(memStatus)) {
                installedMemory = memStatus.ullTotalPhys;
            }

            return installedMemory;
        }

        public static string GetCPUSpeedFromRegistery() {
            string cpuPath = @"HARDWARE\DESCRIPTION\System\CentralProcessor";

            Microsoft.Win32.RegistryKey registrykeyHKLM = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey registrykeyCPUs = registrykeyHKLM.OpenSubKey(cpuPath, false);

            StringBuilder sbCPUDetails = new StringBuilder();

            int iCPUCount;
            for (iCPUCount = 0; iCPUCount < registrykeyCPUs.SubKeyCount; iCPUCount++) {
                Microsoft.Win32.RegistryKey registrykeyCPUDetail = registrykeyHKLM.OpenSubKey(cpuPath + "\\" + iCPUCount, false);
                string sMHz = registrykeyCPUDetail.GetValue("~MHz").ToString();
                string sProcessorNameString = registrykeyCPUDetail.GetValue("ProcessorNameString").ToString();
                sbCPUDetails.Append(Environment.NewLine + "\t" + string.Format("CPU{0}: {1} MHz for {2}", new object[] { iCPUCount, sMHz, sProcessorNameString }));
                registrykeyCPUDetail.Close();
            }

            registrykeyCPUs.Close();
            registrykeyHKLM.Close();

            var sCPUSpeed = iCPUCount++ + " core(s) found:" + sbCPUDetails.ToString();
            return sCPUSpeed;
        }
        //public static uint CPUSpeed() {
        //    ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'");
        //    uint sp = (uint)(Mo["CurrentClockSpeed"]);
        //    Mo.Dispose();
        //    return sp;
        //}
    }
}
