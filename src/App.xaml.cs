using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            string[] commandLineArgs = e.Args;
            if (commandLineArgs.Contains("-l") || commandLineArgs.Contains("-L"))
            {
                MainWindow mainWindow = new MainWindow(true);
                mainWindow.Show();
            } else
            {
                MainWindow mainWindow = new MainWindow(false); 
                mainWindow.Show();
            }
        }
    }
}
