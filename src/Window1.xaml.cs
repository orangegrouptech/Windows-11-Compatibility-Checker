using System;
using System.Diagnostics;
using System.Linq;
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
            }
            
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
