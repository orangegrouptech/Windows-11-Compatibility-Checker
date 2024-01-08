using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
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
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void checkForUpdates_Click(object sender, RoutedEventArgs e)
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
                        if (version == new Version("3.0"))
                        {
                            //iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("Windows 11 Compatibility Checker is up to date.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            ContentDialog dialog = new ContentDialog();
                            dialog.Title = "Information";
                            dialog.Content = "Windows 11 Compatibility Checker is up to date.";
                            dialog.PrimaryButtonText = "OK";
                            dialog.DefaultButton = ContentDialogButton.Primary;
                            await dialog.ShowAsync();
                            break;
                        }
                        else if (version > new Version("3.0"))
                        {
                            //iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("An update was found. Please head over to the GitHub page to download the update. \nCurrent Version: 2.4\nLatest Version: " + lines[x], "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            ContentDialog dialog = new ContentDialog();
                            dialog.Title = "Information";
                            dialog.Content = "An update was found. Would you like to head over to the download page now? \nCurrent Version: 3.0\nLatest Version: " + lines[x];
                            dialog.PrimaryButtonText = "Yes";
                            dialog.SecondaryButtonText = "No";
                            dialog.DefaultButton = ContentDialogButton.Primary;
                            var result = await dialog.ShowAsync();
                            if (result == ContentDialogResult.Primary)
                            {
                                Process.Start("https://github.com/orangegrouptech/Windows-11-Compatibility-Checker/releases/latest");
                            }
                            break;
                        }
                        else if (version < new Version("3.0"))
                        {
                            iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("This build seems to be a development build that has not been pushed out to the public. \nIf you are an authorised tester, then well great, I guess.\nIf not, stop using this app and discard it. It's not very nice to use leaked builds.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                    }
                }
            } 
            catch
            {
                iNKORE.UI.WPF.Modern.Controls.MessageBox.Show("There was an error checking for updates. Maybe see if you're connected to the Internet or try whitelisting github.com on your firewall.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
