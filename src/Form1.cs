using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
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
            this.CenterToScreen();
            Main2();
        }
        private async void Main2() {
            //Dark Light Mode
            RegistryKey setdarkmodepreferences = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if ((int)setdarkmodepreferences.GetValue("DarkMode") == 1)
            {
                BackColor = System.Drawing.Color.Black;
                notificationText.ForeColor = System.Drawing.Color.White;
                Title.ForeColor = System.Drawing.Color.White;
                yourSpecsTitle.ForeColor = System.Drawing.Color.White;
                cpuName.ForeColor = System.Drawing.Color.White;
                memoryAmount.ForeColor = System.Drawing.Color.White;
                gpuText.ForeColor = System.Drawing.Color.White;
                cpuArchitectureText.ForeColor = System.Drawing.Color.White;
                storageText.ForeColor = System.Drawing.Color.White;
                secureBootText.ForeColor = System.Drawing.Color.White;
                tpmText.ForeColor = System.Drawing.Color.White;
                screenResolutionText.ForeColor = System.Drawing.Color.White;
                darkModeButton.Text = "Light Mode";
            }
            else if((int)setdarkmodepreferences.GetValue("DarkMode") == 0 || setdarkmodepreferences.GetValue("DarkMode") == null)
            {
                BackColor = System.Drawing.Color.White;
                notificationText.ForeColor = System.Drawing.Color.Black;
                Title.ForeColor = System.Drawing.Color.Black;
                yourSpecsTitle.ForeColor = System.Drawing.Color.Black;
                cpuName.ForeColor = System.Drawing.Color.Black;
                memoryAmount.ForeColor = System.Drawing.Color.Black;
                gpuText.ForeColor = System.Drawing.Color.Black;
                cpuArchitectureText.ForeColor = System.Drawing.Color.Black;
                storageText.ForeColor = System.Drawing.Color.Black;
                secureBootText.ForeColor = System.Drawing.Color.Black;
                tpmText.ForeColor = System.Drawing.Color.Black;
                screenResolutionText.ForeColor = System.Drawing.Color.Black;
                darkModeButton.Text = "Dark Mode";
            }
            //Check for Windows 11
            RegistryKey checkwindowsversion = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            int windowsversion = Convert.ToInt32(checkwindowsversion.GetValue("CurrentBuildNumber"));
            if (windowsversion >= 21996)
            {
                notificationText.Text = "You\'re already running Windows 11 you fool";
                notificationStatus.Image = Properties.Resources.WindowsWarning;
            } else
            {
                string sku = (string)checkwindowsversion.GetValue("EditionID");
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
                cpuName.Text = "CPU: " + (string)mo["Name"];
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
            await Delay(200);
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
                memoryAmount.Text = "RAM: " + memory + "GB";
                if (memory >= 4)
                {
                    ramImage.Image = Properties.Resources.WindowsSuccess;
                } else
                {
                    ramImage.Image = Properties.Resources.WindowsCritical;
                }
            }
            await Delay(200);
            //GPU
            Process.Start("dxdiag", "/x "+Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\dxv.xml");
            while (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\dxv.xml"))
                Thread.Sleep(100);
            XmlDocument doc = new XmlDocument();
            doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\dxv.xml");
            XmlNode dxd = doc.SelectSingleNode("//DxDiag");
            XmlNode dxv = dxd.SelectSingleNode("//DirectXVersion");
            var dxversion = Convert.ToInt32(dxv.InnerText.Split(' ')[1]);
            if (dxversion < 12)
            {
                gpuText.Text = "GPU: DirectX " + dxversion + ". Update to DirectX 12 or get a GPU that supports it.";
                gpuStatus.Image = Properties.Resources.WindowsCritical;
            } else
            {
                gpuText.Text = "GPU: DirectX " + dxversion;
                gpuStatus.Image = Properties.Resources.WindowsSuccess;
            }
            await Delay(200);
            //CPU Architecture
            bool is64 = System.Environment.Is64BitOperatingSystem;
            if (is64 == true)
            {
                cpuArchitectureText.Text = "CPU Architecture: 64-bit";
                cpuArchitectureStatus.Image = Properties.Resources.WindowsSuccess;
            } else
            {
                cpuArchitectureText.Text = "CPU Architecture: 32-bit";
                cpuArchitectureStatus.Image = Properties.Resources.WindowsCritical;
            }
            await Delay(200);
            //Storage
            DriveInfo mainDrive = new DriveInfo(Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            var totalsize = mainDrive.TotalSize / 1024 / 1024 / 1024;
            storageText.Text = "Storage: " + totalsize + "GB";
            if (totalsize >= 64)
            {
                storageImage.Image = Properties.Resources.WindowsSuccess;
            } else
            {
                storageImage.Image = Properties.Resources.WindowsCritical;
            }
            await Delay(200);
            //Secure Boot
            RegistryKey securebootstatuskey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecureBoot\State");
            var securebootstatus = securebootstatuskey.GetValue("UEFISecureBootEnabled");
            if ((int)securebootstatus == 1)
            {
                secureBootText.Text = "Secure Boot: Enabled";
                secureBootStatus.Image = Properties.Resources.WindowsSuccess;
            } else if ((int)securebootstatus == 0)
            {
                secureBootText.Text = "Secure Boot: Disabled. Enable Secure Boot in the BIOS.";
                secureBootStatus.Image = Properties.Resources.WindowsCritical;
            }
            await Delay(200);
            //TPM
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            process.StartInfo.Arguments = "Get-TPM";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Verb = "runas";
            process.Start();
            string s = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            using (StreamWriter outfile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt"))
            {
                outfile.Write(s);
            }
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt"))
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt");
                    if (lines[2].Contains("TpmPresent                : True"))
                    {
                        if(lines[4].Contains("TpmEnabled                : True"))
                        {
                            tpmStatus.Image = Properties.Resources.WindowsSuccess;
                            tpmText.Text = "TPM: Present and enabled";
                        } else
                        {
                            tpmStatus.Image = Properties.Resources.WindowsWarning;
                            tpmText.Text = "TPM: Present but not enabled";
                        }
                        sr.Close();
                    }
                    else
                    {
                        tpmStatus.Image = Properties.Resources.WindowsCritical;
                        tpmText.Text = "TPM: Not present";
                    }
            }
            //Screen Resolution
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenResolutionText.Text = "Screen Resolution: " + screenWidth + "x" + screenHeight;
            if(screenWidth >= 1280 && screenHeight >= 720)
            {
                screenResolutionStatus.Image = Properties.Resources.WindowsSuccess;
            } else
            {
                screenResolutionStatus.Image = Properties.Resources.WindowsCritical;
            }
        }

        private void darkModeButton_Click(object sender, EventArgs e)
        {
            RegistryKey setdarkmodepreferences = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if(setdarkmodepreferences.GetValue("DarkMode") == null || (int)setdarkmodepreferences.GetValue("DarkMode") == 0)
            {
                setdarkmodepreferences.SetValue("DarkMode", 1);
                BackColor = System.Drawing.Color.Black;
                notificationText.ForeColor = System.Drawing.Color.White;
                Title.ForeColor = System.Drawing.Color.White;
                yourSpecsTitle.ForeColor = System.Drawing.Color.White;
                cpuName.ForeColor = System.Drawing.Color.White;
                memoryAmount.ForeColor = System.Drawing.Color.White;
                gpuText.ForeColor = System.Drawing.Color.White;
                cpuArchitectureText.ForeColor = System.Drawing.Color.White;
                storageText.ForeColor = System.Drawing.Color.White;
                secureBootText.ForeColor = System.Drawing.Color.White;
                tpmText.ForeColor = System.Drawing.Color.White;
                screenResolutionText.ForeColor = System.Drawing.Color.White;
                darkModeButton.Text = "Light Mode";
            } else
            {
                setdarkmodepreferences.SetValue("DarkMode", 0);
                BackColor = System.Drawing.Color.White;
                notificationText.ForeColor = System.Drawing.Color.Black;
                Title.ForeColor = System.Drawing.Color.Black;
                yourSpecsTitle.ForeColor = System.Drawing.Color.Black;
                cpuName.ForeColor = System.Drawing.Color.Black;
                memoryAmount.ForeColor = System.Drawing.Color.Black;
                gpuText.ForeColor = System.Drawing.Color.Black;
                cpuArchitectureText.ForeColor = System.Drawing.Color.Black;
                storageText.ForeColor = System.Drawing.Color.Black;
                secureBootText.ForeColor = System.Drawing.Color.Black;
                tpmText.ForeColor = System.Drawing.Color.Black;
                screenResolutionText.ForeColor = System.Drawing.Color.Black;
                darkModeButton.Text = "Dark Mode";
            }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }
    }
}