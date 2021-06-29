﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Windows_11_Compatibility_Checker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.CenterToScreen();
            RegistryKey setdarkmodepreferences = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Orange Group\Windows 11 Compatibility Checker");
            if (setdarkmodepreferences.GetValue("DarkMode") == null)
            {
                setdarkmodepreferences.SetValue("DarkMode", 0);
            }
            if ((int)setdarkmodepreferences.GetValue("DarkMode") == 1)
            {
                this.BackColor = System.Drawing.Color.Black;
                title.ForeColor = System.Drawing.Color.White;
                version.ForeColor = System.Drawing.Color.White;
                byLine.ForeColor = System.Drawing.Color.White;
                discordTag.ForeColor = System.Drawing.Color.White;
                license.ForeColor = System.Drawing.Color.White;
                credits.ForeColor = System.Drawing.Color.White;
                creditIcons.ForeColor = System.Drawing.Color.White;
                creditTesters.ForeColor = System.Drawing.Color.White;
                creditTesters2.ForeColor = System.Drawing.Color.White;
                twitterButton.Image = Properties.Resources.twitter_white__Custom_;
                githubButton.Image = Properties.Resources.github_white__Custom_;
                twitterButton.Location = new System.Drawing.Point(85, 366);
            }
            else if ((int)setdarkmodepreferences.GetValue("DarkMode") == 0)
            {
                this.BackColor = System.Drawing.Color.White;
                title.ForeColor = System.Drawing.Color.Black;
                version.ForeColor = System.Drawing.Color.Black;
                byLine.ForeColor = System.Drawing.Color.Black;
                discordTag.ForeColor = System.Drawing.Color.Black;
                license.ForeColor = System.Drawing.Color.Black;
                credits.ForeColor = System.Drawing.Color.Black;
                creditIcons.ForeColor = System.Drawing.Color.Black;
                creditTesters.ForeColor = System.Drawing.Color.Black;
                creditTesters2.ForeColor = System.Drawing.Color.Black;
                twitterButton.Image = Properties.Resources.twitter__Custom_;
                githubButton.Image = Properties.Resources.github__Custom_;
                twitterButton.Location = new System.Drawing.Point(85, 363);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/orangegrouptech/Windows-11-Compatibility-Checker");
        }

        private void twitterButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/OrangeGroupTech");
        }
    }
}
