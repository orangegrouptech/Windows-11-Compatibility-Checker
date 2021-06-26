using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace Windows_11_Compatibility_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Check for Windows 11
            RegistryKey checkwindowsversion = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            int windowsversion = Convert.ToInt32(checkwindowsversion.GetValue("CurrentBuildNumber"));
            if(windowsversion >= 21996)
            {
                notificationText.Text = "You\'re already running Windows 11 you fool";
                notificationStatus.Image = Properties.Resources.WindowsWarning;
            } else
            {
                string sku = (string)checkwindowsversion.GetValue("CompositionEditionID");
                if (sku.Contains("Enterprise"))
                {
                    notificationText.Text = "No Enterprise SKU in Windows 11 for now.";
                    notificationStatus.Image = Properties.Resources.WindowsWarning;
                }
            }
            //CPU
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                cpuName.Text = "CPU: "+(string)mo["Name"];
            }
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker");
            //File.Create(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\AMD.txt");
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt", Properties.Resources.CPUs);
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt"))
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt");
                for (int x = 0; x < lines.Length; x++)
                {
                    if (cpuName.Text.Contains(lines[x]))
                    {
                        cpuStatus.Image = Properties.Resources.WindowsSuccess;
                        sr.Close();
                        break;
                    }
                    else
                    {
                        cpuStatus.Image = Properties.Resources.WindowsCritical;
                    }
                }
            }
            //RAM
            foreach (ManagementObject mo in mos.Get())
            {
                ManagementScope oMs = new ManagementScope();
                ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                ManagementObjectCollection oCollection = oSearcher.Get();

                long MemSize = 0;
                long mCap = 0;

                foreach (ManagementObject obj in oCollection)
                {
                    mCap = Convert.ToInt64(obj["Capacity"]);
                    MemSize += mCap;
                }
                var memory = MemSize / 1024 / 1024 / 1024;
                memoryAmount.Text = "RAM: "+ memory + "GB";
                if(memory >= 4)
                {
                    ramImage.Image = Properties.Resources.WindowsSuccess;
                } else
                {
                    ramImage.Image = Properties.Resources.WindowsCritical;
                }
            }
            //GPU
            Process.Start("dxdiag", "/x dxv.xml");
            while (!File.Exists("dxv.xml"))
                Thread.Sleep(100);
            XmlDocument doc = new XmlDocument();
            doc.Load("dxv.xml");
            XmlNode dxd = doc.SelectSingleNode("//DxDiag");
            XmlNode dxv = dxd.SelectSingleNode("//DirectXVersion");
            var dxversion = Convert.ToInt32(dxv.InnerText.Split(' ')[1]);
            if(dxversion < 12)
            {
                gpuText.Text = "GPU: DirectX "+dxversion+". Update to DirectX 12 or get a GPU that supports it.";
                gpuStatus.Image = Properties.Resources.WindowsCritical;
            } else
            {
                gpuText.Text = "GPU: DirectX "+dxversion;
                gpuStatus.Image = Properties.Resources.WindowsSuccess;
            }
            //CPU Architecture
            bool is64 = System.Environment.Is64BitOperatingSystem;
            if(is64 == true)
            {
                cpuArchitectureText.Text = "CPU Architecture: 64-bit";
                cpuArchitectureStatus.Image = Properties.Resources.WindowsSuccess;
            } else
            {
                cpuArchitectureText.Text = "CPU Architecture: 32-bit";
                cpuArchitectureStatus.Image = Properties.Resources.WindowsCritical;
            }
            //Storage
            DriveInfo mainDrive = new DriveInfo(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            var totalsize = mainDrive.TotalSize / 1024 / 1024 / 1024;
            storageText.Text = "Storage: " + totalsize + "GB";
            if(totalsize >= 64)
            {
                storageImage.Image = Properties.Resources.WindowsSuccess;
            } else
            {
                storageImage.Image = Properties.Resources.WindowsCritical;
            }
            //Secure Boot
            RegistryKey securebootstatuskey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecureBoot\State");
            var securebootstatus = securebootstatuskey.GetValue("UEFISecureBootEnabled");
            if((int)securebootstatus == 1)
            {
                secureBootText.Text = "Secure Boot: Enabled";
                secureBootStatus.Image = Properties.Resources.WindowsSuccess;
            } else if((int)securebootstatus == 0)
            {
                secureBootText.Text = "Secure Boot: Disabled. Enable Secure Boot in the BIOS.";
                secureBootStatus.Image = Properties.Resources.WindowsCritical;
            }
            //TPM
            
        }
    }
}