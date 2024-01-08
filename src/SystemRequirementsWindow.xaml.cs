using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class SystemRequirementsWindow : Window
    {
        public SystemRequirementsWindow()
        {
            InitializeComponent();
            RegistryKey checkwindowsbuild = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(checkwindowsbuild.GetValue("CurrentBuildNumber")) < 21390)
            {
                title.FontFamily = new FontFamily("Segoe UI");
                title.FontWeight = FontWeights.Bold;
                cpuText.FontFamily = new FontFamily("Segoe UI");
                cpuDesc1.FontFamily = new FontFamily("Segoe UI");
                cpuDesc2.FontFamily = new FontFamily("Segoe UI");
                cpuDesc3.FontFamily = new FontFamily("Segoe UI");
                ramText.FontFamily = new FontFamily("Segoe UI");
                ramDesc.FontFamily = new FontFamily("Segoe UI");
                gpuText.FontFamily = new FontFamily("Segoe UI");
                gpuDesc1.FontFamily = new FontFamily("Segoe UI");
                gpuDesc2.FontFamily = new FontFamily("Segoe UI");
                storageText.FontFamily = new FontFamily("Segoe UI");
                storageDesc.FontFamily = new FontFamily("Segoe UI");
                bootModeText.FontFamily = new FontFamily("Segoe UI");
                bootModeDesc.FontFamily = new FontFamily("Segoe UI");
                tpmText.FontFamily = new FontFamily("Segoe UI");
                tpmDesc.FontFamily = new FontFamily("Segoe UI");
                screenResText.FontFamily = new FontFamily("Segoe UI");
                screenResDesc.FontFamily = new FontFamily("Segoe UI");
                closeButton.FontFamily = new FontFamily("Segoe UI");
                softFloor.FontFamily = new FontFamily("Segoe UI");
                hardFloor.FontFamily = new FontFamily("Segoe UI");
                cpuHardText.FontFamily = new FontFamily("Segoe UI");
                cpuDescHard.FontFamily = new FontFamily("Segoe UI");
                ramHardText.FontFamily = new FontFamily("Segoe UI");
                ramDescHard.FontFamily = new FontFamily("Segoe UI");
                storageHardText.FontFamily = new FontFamily("Segoe UI");
                storageDescHard.FontFamily = new FontFamily("Segoe UI");
                bootModeHardText.FontFamily = new FontFamily("Segoe UI");
                bootModeDescHard.FontFamily = new FontFamily("Segoe UI");
                tpmHardText.FontFamily = new FontFamily("Segoe UI");
                tpmDescHard.FontFamily = new FontFamily("Segoe UI");
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
