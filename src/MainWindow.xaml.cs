using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Media;
using System.Management;
using System.IO;
using System.Xml;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Welcome to this utter mess, aka the Windows 11 Compatibility Checker source code. I've clearly labelled
        //the code of each check with comments so that I don't mess you or myself up when I debug.
        //I've also left 3 lines for each check. Use Control + F to find your way if you get lost.
        //Have a nice day!
        public MainWindow()
        {
            InitializeComponent();
            Main2();
        }

        private async void Main2()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker");
            await Delay(100);
            Properties.Resources.WindowsCritical.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png");
            Properties.Resources.WindowsWarning.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsWarning.png");
            Properties.Resources.WindowsSuccess.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png");
            Properties.Resources.WindowsHelp.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png");
            Properties.Resources.circle_cropped__Custom___1_.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\pfp.png");
            Properties.Resources.Windows_11.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\Windows 11.png");
            notificationStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
            cpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            ramImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            gpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            cpuArchitectureStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            storageImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            secureBootStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            biosModeStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            tpmStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            screenResolutionStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsHelp.png"));
            
            
            
            //Dark Light Mode
            RegistryKey setdarkmodepreferences = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if (setdarkmodepreferences.GetValue("DarkMode") == null)
            {
                setdarkmodepreferences.SetValue("DarkMode", 0);
            }
            if ((int)setdarkmodepreferences.GetValue("DarkMode") == 1)
            {
                Background = Brushes.Black;
                notificationText.Foreground = Brushes.White;
                Title.Foreground = Brushes.White;
                yourSpecsTitle.Foreground = Brushes.White;
                cpuName.Foreground = Brushes.White;
                memoryAmount.Foreground = Brushes.White;
                gpuText.Foreground = Brushes.White;
                cpuArchitectureText.Foreground = Brushes.White;
                storageText.Foreground = Brushes.White;
                secureBootText.Foreground = Brushes.White;
                biosModeText.Foreground = Brushes.White;
                tpmText.Foreground = Brushes.White;
                screenResolutionText.Foreground = Brushes.White;
                darkModeButton.Content = "Light Mode";
            }
            else if ((int)setdarkmodepreferences.GetValue("DarkMode") == 0)
            {
                Background = Brushes.White;
                notificationText.Foreground = Brushes.Black;
                Title.Foreground = Brushes.Black;
                yourSpecsTitle.Foreground = Brushes.Black;
                cpuName.Foreground = Brushes.Black;
                memoryAmount.Foreground = Brushes.Black;
                gpuText.Foreground = Brushes.Black;
                cpuArchitectureText.Foreground = Brushes.Black;
                storageText.Foreground = Brushes.Black;
                secureBootText.Foreground = Brushes.Black;
                biosModeText.Foreground = Brushes.Black;
                tpmText.Foreground = Brushes.Black;
                screenResolutionText.Foreground = Brushes.Black;
                darkModeButton.Content = "Dark Mode";
            }



            //Check for Windows 11
            RegistryKey checkwindowsversion = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            int windowsversion = Convert.ToInt32(checkwindowsversion.GetValue("CurrentBuildNumber"));
            if (windowsversion >= 21996)
            {
                notificationText.Content = "You\'re already running Windows 11 you fool";
                notificationText.Margin = new Thickness(0, 0, -180, 243);
                notificationStatus.Margin = new Thickness(135, 9, 0, 0);
                notificationStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\WindowsWarning.png"));
            } else
            {
                var checkedition = checkwindowsversion.GetValue("EditionID");
                if((string)checkedition == "Home")
                {
                    notificationText.Content = "Looks like you're using the Home SKU. Internet Connection is required to upgrade.";
                    notificationStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\WindowsWarning.png"));
                    notificationStatus.Margin = new Thickness(-8, 9, 0, 0);
                    notificationText.Margin = new Thickness(0, 0, -35, 243);
                }
            }



            //No Segoe UI Variable in Windows 10, revert to Segoe UI
            RegistryKey checkwindowsbuild = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(checkwindowsbuild.GetValue("CurrentBuildNumber")) < 21390)
            {
                notificationText.FontFamily = new FontFamily("Segoe UI");
                Title.FontWeight = FontWeights.Bold;
                yourSpecsTitle.FontFamily = new FontFamily("Segoe UI");
                cpuName.FontFamily = new FontFamily("Segoe UI");
                memoryAmount.FontFamily = new FontFamily("Segoe UI");
                gpuText.FontFamily = new FontFamily("Segoe UI");
                cpuArchitectureText.FontFamily = new FontFamily("Segoe UI");
                storageText.FontFamily = new FontFamily("Segoe UI");
                secureBootText.FontFamily = new FontFamily("Segoe UI");
                biosModeText.FontFamily = new FontFamily("Segoe UI");
                tpmText.FontFamily = new FontFamily("Segoe UI");
                screenResolutionText.FontFamily = new FontFamily("Segoe UI");
            }
            await Delay(100);


            //CPU
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get())
            {
                cpuName.Content = "CPU: " + (string)mo["Name"];
            }
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker");
            //File.Create(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\AMD.txt");
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt", Properties.Resources.CPUs);
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt"))
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\CPUs.txt");
                for (int x = 0; x < lines.Length; x++)
                {
                    if (cpuName.Content.ToString().Contains(lines[x]))
                    {
                        cpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+@"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                        sr.Close();
                        break;
                    }
                    else
                    {
                        cpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
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
                memoryAmount.Content = "RAM: " + memory + "GB";
                if (memory >= 4)
                {
                    ramImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                }
                else
                {
                    ramImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                }
            }
            await Delay(200);



            //GPU
            Process.Start("dxdiag", "/x " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\dxv.xml");
            while (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\dxv.xml"))
                Thread.Sleep(100);
            XmlDocument doc = new XmlDocument();
            doc.Load(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\dxv.xml");
            XmlNode dxd = doc.SelectSingleNode("//DxDiag");
            XmlNode dxv = dxd.SelectSingleNode("//DirectXVersion");
            XmlNode dxm = dxd.SelectSingleNode("//DriverModel");
            Version dxversion = new Version(dxv.InnerText.Split(' ')[1] + ".0");
            Version wddmversion = new Version(dxm.InnerText.Split(' ')[1]);
            if (dxversion < new Version("12.0"))
            {
                gpuText.Content = "GPU: DirectX " + dxversion + ", WDDM " + wddmversion + ". Update to DirectX 12 or get a GPU with DX12.";
                gpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
            }
            else
            {
                gpuText.Content = "GPU: DirectX " + dxversion + ", WDDM " + wddmversion;

                if (wddmversion < new Version("2.0"))
                {
                    gpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                }
                else
                {
                    gpuStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                }
            }
            await Delay(200);



            //CPU Architecture
            bool is64 = System.Environment.Is64BitOperatingSystem;
            if (is64 == true)
            {
                cpuArchitectureText.Content = "CPU Architecture: 64-bit";
                cpuArchitectureStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
            }
            else
            {
                cpuArchitectureText.Content = "CPU Architecture: 32-bit";
                cpuArchitectureStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
            }
            await Delay(200);
            
            
            
            //Storage
            DriveInfo mainDrive = new DriveInfo(System.IO.Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System)));
            var totalsize = mainDrive.TotalSize / 1024 / 1024 / 1024;
            storageText.Content = "Storage: " + totalsize + "GB";
            if (totalsize >= 64)
            {
                storageImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
            }
            else
            {
                storageImage.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
            }
            await Delay(200);
            
            
            
            //BIOS Mode
            Process process2 = new Process();
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.RedirectStandardOutput = true;
            process2.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            process2.StartInfo.Arguments = "bcdedit";
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.Verb = "runas";
            process2.Start();
            string s2 = process2.StandardOutput.ReadToEnd();
            process2.WaitForExit();

            using (StreamWriter outfile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\BIOSMode.txt"))
            {
                outfile.Write(s2);
            }
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\BIOSMode.txt"))
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\BIOSMode.txt");
                for (var i = 0; i < lines.Length; i++)
                {
                    if (lines[i].ToLower().Contains(@"path                    \windows\system32\winload.efi")/* || lines[20].Contains(@"path                    \WINDOWS\system32\winload.efi")*/)
                    {
                        biosModeStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                        biosModeText.Content = "BIOS Mode: UEFI";
                        break;
                    }
                    else
                    {
                        biosModeStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                        biosModeText.Content = "BIOS Mode: Legacy";
                    }
                }

            }
            
            
            
            //Secure Boot
            try
            {
                RegistryKey securebootstatuskey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\SecureBoot\State");
                var securebootstatus = securebootstatuskey.GetValue("UEFISecureBootEnabled");
                if ((int)securebootstatus == 1)
                {
                    secureBootText.Content = "Secure Boot: Enabled";
                    secureBootStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                }
                else if ((int)securebootstatus == 0)
                {
                    secureBootText.Content = "Secure Boot: Disabled. Enable Secure Boot in the BIOS.";
                    secureBootStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                }
            }
            catch
            {
                secureBootText.Content = "Secure Boot: Registry Entry not found. You may be using Legacy Boot.";
                secureBootStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
            }
            await Delay(200);



            //TPM
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
            process.StartInfo.Arguments = "Get-TPM";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Verb = "runas";
            process.Start();
            string s = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            using (StreamWriter outfile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt"))
            {
                outfile.Write(s);
            }
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt"))
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\TPMresult.txt");

                if (lines[2].Contains("TpmPresent                : True"))
                {
                    //TPM VERSION [WMIC]
                    Process wmicTPMVersionProcess = new Process();
                    wmicTPMVersionProcess.StartInfo.UseShellExecute = false;
                    wmicTPMVersionProcess.StartInfo.RedirectStandardOutput = true;
                    wmicTPMVersionProcess.StartInfo.FileName = @"C:\Windows\System32\Wbem\wmic.exe";
                    wmicTPMVersionProcess.StartInfo.Arguments = @"/namespace:\\root\CIMV2\Security\MicrosoftTpm path Win32_Tpm get SpecVersion";
                    wmicTPMVersionProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    wmicTPMVersionProcess.StartInfo.CreateNoWindow = true;
                    wmicTPMVersionProcess.StartInfo.Verb = "runas";
                    wmicTPMVersionProcess.Start();

                    Version tpmVersion = new Version(wmicTPMVersionProcess.StandardOutput.ReadToEnd().Split('\n')[1].Split(',')[0]);
                    wmicTPMVersionProcess.WaitForExit();

                    if (tpmVersion < new Version("2.0"))
                    {
                        tpmStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                        tpmText.Content = "TPM: Version " + tpmVersion;
                    }
                    else
                    {
                        if (lines[4].Contains("TpmEnabled                : True"))
                        {
                            tpmStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
                            tpmText.Content = "TPM: Version " + tpmVersion + ", Present and enabled";
                        }
                        else
                        {
                            tpmStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsWarning.png"));
                            tpmText.Content = "TPM: Version " + tpmVersion + ", Present but not enabled";
                        }
                    }

                    sr.Close();
                }
                else
                {
                    tpmStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
                    tpmText.Content = "TPM: Not present";
                }
            }



            //Screen Resolution
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            screenResolutionText.Content = "Screen Resolution: " + screenWidth + "x" + screenHeight;
            if (screenWidth >= 1280 && screenHeight >= 720)
            {
                screenResolutionStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsSuccess.png"));
            }
            else
            {
                screenResolutionStatus.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\WindowsCritical.png"));
            }
        }

        private void darkModeButton_Click(object sender, EventArgs e)
        {
            RegistryKey setdarkmodepreferences = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if (setdarkmodepreferences.GetValue("DarkMode") == null || (int)setdarkmodepreferences.GetValue("DarkMode") == 0)
            {
                setdarkmodepreferences.SetValue("DarkMode", 1);
                Background = Brushes.Black;
                notificationText.Foreground = Brushes.White;
                Title.Foreground = Brushes.White;
                yourSpecsTitle.Foreground = Brushes.White;
                cpuName.Foreground = Brushes.White;
                memoryAmount.Foreground = Brushes.White;
                gpuText.Foreground = Brushes.White;
                cpuArchitectureText.Foreground = Brushes.White;
                storageText.Foreground = Brushes.White;
                secureBootText.Foreground = Brushes.White;
                biosModeText.Foreground = Brushes.White;
                tpmText.Foreground = Brushes.White;
                screenResolutionText.Foreground = Brushes.White;
                darkModeButton.Content = "Light Mode";
            }
            else
            {
                setdarkmodepreferences.SetValue("DarkMode", 0);
                Background = Brushes.White;
                notificationText.Foreground = Brushes.Black;
                Title.Foreground = Brushes.Black;
                yourSpecsTitle.Foreground = Brushes.Black;
                cpuName.Foreground = Brushes.Black;
                memoryAmount.Foreground = Brushes.Black;
                gpuText.Foreground = Brushes.Black;
                cpuArchitectureText.Foreground = Brushes.Black;
                storageText.Foreground = Brushes.Black;
                secureBootText.Foreground = Brushes.Black;
                biosModeText.Foreground = Brushes.Black;
                tpmText.Foreground = Brushes.Black;
                screenResolutionText.Foreground = Brushes.Black;
                darkModeButton.Content = "Dark Mode";
            }
        }
        private async Task Delay(int howlong)
        {
            await Task.Delay(howlong);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
        }

        private void sysRequirementsButton_Click(object sender, RoutedEventArgs e)
        {
            /*System.Windows.MessageBox.Show("CPU:\nWindows 11 requires a compatible 64-bit processor: \n• 8th Gen Intel Core and above\n• AMD Ryzen based on Zen+ and above (except Ryzen 3 2200G and Ryzen 5 2400G).\n6th Gen Intel and below as well as Zen 1 and below are vulnerable to Spectre (Meltdown for Intel CPUs)." +
                "\n\nRAM:\nWindows 11 requires at least 4GB of RAM.\n\n" +
                "GPU: \nWindows 11 requires a GPU that's compatible with DirectX 12 and later.\n\n" +
                "Architecture: \nWindows 11 requires a 64-bit processor and operating system. If you are using a 32-bit OS but your CPU supports 64-bit, you need to wipe the drive and reinstall Windows.\n\n" +
                "Storage:\nWindows 11 requires at least 64GB of storage.\n\n" +
                "Boot Mode: \nWindows 11 is UEFI-only. Legacy BIOS is not supported.\n\n" +
                "Secure Boot:\nWindows 11 requires Secure Boot.\n\n" +
                "TPM:\nWindows 11 requires TPM 2.0.\n\n" +
                "Screen resolution: \nWindows 11 requires a display with a 720p resolution (1280 x 720) and higher.", "System Requirements", MessageBoxButton.OK, MessageBoxImage.Information);
            */
            Window2 window2 = new Window2();
            window2.ShowDialog();
        }
    }
}
