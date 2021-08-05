using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Windows;
using System.Windows.Media;

namespace Windows_11_Compatibility_Checker_WPF
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public static string _machineInfo_RAM;
        public static string _machineInfo_DiskSpace;
        public static string targetReportEmailAddress1;
        public static Exception exception1;
        public static string callingMethod1;
        public static List<string> attachmentList1;
        public static void SendNotificationMail(string targetReportMailAddress, Exception exception, string callingMethod, List<string> attachmentList)
        {
            Dictionary<string, string> reportValues = new Dictionary<string, string>()
            {
                { "Application",  "Orange Group - Windows 11 Compatibility Checker" },
                { "App Version",  Assembly.GetExecutingAssembly().GetName().Version.ToString() },
                { "Date / Time", DateTime.Now.ToString("dd.MM.yyyy HH:mm") },
                { "Operating Memory", _machineInfo_RAM },
                { "Drive C", _machineInfo_DiskSpace },
                { "Exception Message", exception.Message },
                { "Calling Method", callingMethod },
                { "Stacktrace", exception.StackTrace }
            };

            // E-MAIL SUBJECT AND CREATE BODY HTML TABLE
            string eMailMessageSubject = "Orange Group - Windows 11 Compatibility Checker - Unhandled Exception Report";
            string eMailMessageBody = string.Empty;

            HtmlTable table = new HtmlTable
            {
                Border = 3,
                BorderColor = "#FF0000",
                BgColor = "#FFC0CB",
                CellPadding = 5,
                CellSpacing = 10
            };

            StringBuilder mailMessageString = new StringBuilder();

            foreach (var reportvalue in reportValues)
            {
                HtmlTableRow row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell { InnerText = reportvalue.Key });
                row.Cells.Add(new HtmlTableCell { InnerText = reportvalue.Value });
                table.Rows.Add(row);
            }

            using (var sw = new StringWriter())
            {
                table.RenderControl(new HtmlTextWriter(sw));
                mailMessageString.AppendFormat(sw.ToString());
                eMailMessageBody = mailMessageString.ToString();
            }

            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("ExceptionReport@Windows11CompatibilityChecker.com");
                    mailMessage.Subject = eMailMessageSubject;
                    mailMessage.Body = eMailMessageBody;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(targetReportMailAddress));
                    mailMessage.Priority = MailPriority.High;

                    foreach (string attachmentFile in attachmentList)
                    {
                        if (File.Exists(attachmentFile))
                        {
                            mailMessage.Attachments.Add(new Attachment(attachmentFile));
                        }
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "gmail-smtp-in.l.google.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 25;
                    smtp.Send(mailMessage);

                    MessageBox.Show("The error report has been sent to Orange Group successfully.", "Windows 11 Compatibility Checker", MessageBoxButton.OK, MessageBoxImage.Information);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                           "Unable to send exception details e-mail due to following error: " +
                           ex.Message,
                       "Windows 11 Compatibility Checker - Unhandled Exception Report",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }
        public void LoadMachineInfo()
        {
            RegistryKey checkwindowsbuild = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(checkwindowsbuild.GetValue("CurrentBuildNumber")) < 21390)
            {
                title.FontFamily = new FontFamily("Segoe UI");
                title.FontWeight = FontWeights.Bold;
                title2.FontFamily = new FontFamily("Segoe UI");
                title3.FontFamily = new FontFamily("Segoe UI");
                title4.FontFamily = new FontFamily("Segoe UI");
                appName.FontFamily = new FontFamily("Segoe UI");
                appVersion.FontFamily = new FontFamily("Segoe UI");
                dateTime.FontFamily = new FontFamily("Segoe UI");
                ramAmount.FontFamily = new FontFamily("Segoe UI");
                storageAmount.FontFamily = new FontFamily("Segoe UI");
                exceptionMessage.FontFamily = new FontFamily("Segoe UI");
                callingMethod.FontFamily = new FontFamily("Segoe UI");
                stacktrace.FontFamily = new FontFamily("Segoe UI");
                files.FontFamily = new FontFamily("Segoe UI");
                privacy1.FontFamily = new FontFamily("Segoe UI");
                privacy2.FontFamily = new FontFamily("Segoe UI");
                privacy3.FontFamily = new FontFamily("Segoe UI");
                privacyPolicyLink.FontFamily = new FontFamily("Segoe UI");
                sendReportButton.FontFamily = new FontFamily("Segoe UI");
                doNotSendButton.FontFamily = new FontFamily("Segoe UI");
            }

            // OPERATING MEMORY / DISK SPACE
            long ram_Maximum = PerformanceInfo.GetTotalMemoryInMiB();
            long ram_Used = ram_Maximum - PerformanceInfo.GetPhysicalAvailableMemoryInMiB();

            DriveInfo driveInfo = new DriveInfo(@"C:");
            long disk_Total = (driveInfo.TotalSize / 1024 / 1024 / 1024);
            long disk_Used = ((driveInfo.TotalSize - driveInfo.AvailableFreeSpace) / 1024 / 1024 / 1024);

            _machineInfo_RAM = (int)ram_Used + " of " + (int)ram_Maximum + " MB Used";
            _machineInfo_DiskSpace = (int)disk_Used + " of " + (int)disk_Total + " GB Used";
        }
        public Window3(Exception exception, string callingMethodVar, string targetReportEmailAddress, List<string> attachmentList)
        {
            exception1 = exception;
            targetReportEmailAddress1 = targetReportEmailAddress;
            callingMethod1 = callingMethodVar;
            attachmentList1 = attachmentList;
            LoadMachineInfo();
            InitializeComponent();
            appVersion.Content = "Application Version: "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
            dateTime.Content = "Date and Time: "+ DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            ramAmount.Content = "Amount of RAM you have: "+_machineInfo_RAM;
            storageAmount.Content = "Amount of storage on your Windows drive: " + _machineInfo_DiskSpace;
            exceptionMessage.Content = "Exception message: " + exception.Message;
            callingMethod.Content = "Calling method: " + callingMethodVar;
            stacktrace.Content = "Stacktrace";
        }

        private void sendReportButton_Click(object sender, RoutedEventArgs e)
        {
            SendNotificationMail(targetReportEmailAddress1, exception1, callingMethod1, attachmentList1);
        }

        private void ___No_Name__Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Process.GetCurrentProcess().Kill();
        }

        private void doNotSendButton_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start("https://gist.github.com/orangegrouptech/e9e15471df7462319fd1887db42d1d97#windows-11-compatibility-checker");
        }
    }
}
