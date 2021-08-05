using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            windows11.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\Windows 11.png"));
            pfp.Source = new BitmapImage(new Uri(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\pfp.png"));
            RegistryKey checkwindowsbuild = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if(Convert.ToInt32(checkwindowsbuild.GetValue("CurrentBuildNumber")) < 21390)
            {
                title.FontFamily = new FontFamily("Segoe UI");
                title.FontWeight = FontWeights.Bold;
                version.FontFamily = new FontFamily("Segoe UI");
                byLine.FontFamily = new FontFamily("Segoe UI");
                discordTag.FontFamily = new FontFamily("Segoe UI");
                license.FontFamily = new FontFamily("Segoe UI");
                credits.FontFamily = new FontFamily("Segoe UI");
                creditTesters.FontFamily = new FontFamily("Segoe UI");
                creditContributorsCode.FontFamily = new FontFamily("Segoe UI");
                closeButton.FontFamily = new FontFamily("Segoe UI");
            }
            RegistryKey darklightmode = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if ((int)darklightmode.GetValue("DarkMode") == 1)
            {
                Background = Brushes.Black;
                title.Foreground = Brushes.White;
                version.Foreground = Brushes.White;
                byLine.Foreground = Brushes.White;
                discordTag.Foreground = Brushes.White;
                license.Foreground = Brushes.White;
                credits.Foreground = Brushes.White;
                creditTesters.Foreground = Brushes.White;
                creditContributorsCode.Foreground = Brushes.White;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkForUpdates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                wc.DownloadFile("http://github.com/orangegrouptech/Windows-11-Compatibility-Checker/raw/main/version.txt", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\version.txt");
                using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\version.txt"))
                {
                    string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Orange Group\Windows 11 Compatibility Checker\version.txt");
                    for (int x = 0; x < lines.Length; x++)
                    {
                        Version version = new Version(lines[x]);
                        if (version == new Version("2.4"))
                        {
                            MessageBox.Show("Windows 11 Compatibility Checker is up to date.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                        else if (version > new Version("2.4"))
                        {
                            MessageBox.Show("An update was found. Please head over to the GitHub page to download the update. \nCurrent Version: 2.4\nLatest Version: " + lines[x], "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                        else if (version < new Version("2.4"))
                        {
                            MessageBox.Show("This build seems to be a development build that has not been pushed out to the public. \nIf you are an authorised tester, then well great, I guess.\nIf not, stop using this app and discard it. It's not very nice to use leaked builds.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                    }
                }
            } 
            catch
            {
                MessageBox.Show("There was an error checking for updates. Maybe see if you're connected to the Internet or try whitelisting github.com on your firewall.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
