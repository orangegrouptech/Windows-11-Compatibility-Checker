using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace Windows_11_Compatibility_Checker_WPF
{
    public partial class ExceptionReporter
    {
        public static string _machineInfo_MachineName;
        public static string _machineInfo_UserName;
        public static string _machineInfo_RAM;
        public static string _machineInfo_DiskSpace;
        public static MemoryStream _screenshotStream = new MemoryStream();

        public void ReportException(string targetReportMailAddress, Exception exception, string callingMethod, List<string> attachmentList)
        {
            // GET INFORMATION
            LoadMachineInfo();

            DebugWindow debugWindow = new DebugWindow(exception, callingMethod, targetReportMailAddress, attachmentList);
            debugWindow.ShowDialog();

            // SEND E-MAIL REPORT
            DebugWindow.SendNotificationMail(targetReportMailAddress, exception, callingMethod, attachmentList);
        }

        

        public void LoadMachineInfo()
        {

            // OPERATING MEMORY / DISK SPACE
            long ram_Maximum = PerformanceInfo.GetTotalMemoryInMiB();
            long ram_Used = ram_Maximum - PerformanceInfo.GetPhysicalAvailableMemoryInMiB();

            DriveInfo driveInfo = new DriveInfo(@"C:");
            long disk_Total = (driveInfo.TotalSize / 1024 / 1024 / 1024);
            long disk_Used = ((driveInfo.TotalSize - driveInfo.AvailableFreeSpace) / 1024 / 1024 / 1024);

            _machineInfo_RAM = (int)ram_Used + " of " + (int)ram_Maximum + " MB Used";
            _machineInfo_DiskSpace = (int)disk_Used + " of " + (int)disk_Total + " GB Used";
        }
    }

    public static class NetworkTools
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        internal static extern int SendARP(int destIp, int srcIP, byte[] macAddr, ref uint physicalAddrLen);
    }

    public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }
        }
    }
}
