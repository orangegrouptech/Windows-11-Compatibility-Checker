
namespace Windows_11_Compatibility_Checker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cpuName = new System.Windows.Forms.Label();
            this.cpuStatus = new System.Windows.Forms.PictureBox();
            this.ramImage = new System.Windows.Forms.PictureBox();
            this.memoryAmount = new System.Windows.Forms.Label();
            this.gpuStatus = new System.Windows.Forms.PictureBox();
            this.gpuText = new System.Windows.Forms.Label();
            this.secureBootStatus = new System.Windows.Forms.PictureBox();
            this.secureBootText = new System.Windows.Forms.Label();
            this.cpuArchitectureStatus = new System.Windows.Forms.PictureBox();
            this.cpuArchitectureText = new System.Windows.Forms.Label();
            this.storageText = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.storageImage = new System.Windows.Forms.PictureBox();
            this.notificationStatus = new System.Windows.Forms.PictureBox();
            this.notificationText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cpuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secureBootStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuArchitectureStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows 11 Compatibility at a glance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label2.Location = new System.Drawing.Point(27, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your Specs:";
            // 
            // cpuName
            // 
            this.cpuName.AutoSize = true;
            this.cpuName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cpuName.Location = new System.Drawing.Point(63, 135);
            this.cpuName.Name = "cpuName";
            this.cpuName.Size = new System.Drawing.Size(129, 25);
            this.cpuName.TabIndex = 2;
            this.cpuName.Text = "CPU: Unknown";
            // 
            // cpuStatus
            // 
            this.cpuStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.cpuStatus.Location = new System.Drawing.Point(32, 136);
            this.cpuStatus.Name = "cpuStatus";
            this.cpuStatus.Size = new System.Drawing.Size(33, 31);
            this.cpuStatus.TabIndex = 3;
            this.cpuStatus.TabStop = false;
            // 
            // ramImage
            // 
            this.ramImage.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.ramImage.Location = new System.Drawing.Point(32, 170);
            this.ramImage.Name = "ramImage";
            this.ramImage.Size = new System.Drawing.Size(33, 31);
            this.ramImage.TabIndex = 5;
            this.ramImage.TabStop = false;
            // 
            // memoryAmount
            // 
            this.memoryAmount.AutoSize = true;
            this.memoryAmount.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.memoryAmount.Location = new System.Drawing.Point(63, 168);
            this.memoryAmount.Name = "memoryAmount";
            this.memoryAmount.Size = new System.Drawing.Size(135, 25);
            this.memoryAmount.TabIndex = 4;
            this.memoryAmount.Text = "RAM: Unknown";
            // 
            // gpuStatus
            // 
            this.gpuStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.gpuStatus.Location = new System.Drawing.Point(32, 203);
            this.gpuStatus.Name = "gpuStatus";
            this.gpuStatus.Size = new System.Drawing.Size(33, 31);
            this.gpuStatus.TabIndex = 7;
            this.gpuStatus.TabStop = false;
            // 
            // gpuText
            // 
            this.gpuText.AutoSize = true;
            this.gpuText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.gpuText.Location = new System.Drawing.Point(63, 202);
            this.gpuText.Name = "gpuText";
            this.gpuText.Size = new System.Drawing.Size(130, 25);
            this.gpuText.TabIndex = 6;
            this.gpuText.Text = "GPU: Unknown";
            // 
            // secureBootStatus
            // 
            this.secureBootStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.secureBootStatus.Location = new System.Drawing.Point(32, 302);
            this.secureBootStatus.Name = "secureBootStatus";
            this.secureBootStatus.Size = new System.Drawing.Size(33, 31);
            this.secureBootStatus.TabIndex = 9;
            this.secureBootStatus.TabStop = false;
            // 
            // secureBootText
            // 
            this.secureBootText.AutoSize = true;
            this.secureBootText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.secureBootText.Location = new System.Drawing.Point(63, 301);
            this.secureBootText.Name = "secureBootText";
            this.secureBootText.Size = new System.Drawing.Size(244, 25);
            this.secureBootText.TabIndex = 8;
            this.secureBootText.Text = "Secure Boot Status: Unknown";
            // 
            // cpuArchitectureStatus
            // 
            this.cpuArchitectureStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.cpuArchitectureStatus.Location = new System.Drawing.Point(32, 236);
            this.cpuArchitectureStatus.Name = "cpuArchitectureStatus";
            this.cpuArchitectureStatus.Size = new System.Drawing.Size(33, 31);
            this.cpuArchitectureStatus.TabIndex = 11;
            this.cpuArchitectureStatus.TabStop = false;
            // 
            // cpuArchitectureText
            // 
            this.cpuArchitectureText.AutoSize = true;
            this.cpuArchitectureText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cpuArchitectureText.Location = new System.Drawing.Point(63, 235);
            this.cpuArchitectureText.Name = "cpuArchitectureText";
            this.cpuArchitectureText.Size = new System.Drawing.Size(228, 25);
            this.cpuArchitectureText.TabIndex = 10;
            this.cpuArchitectureText.Text = "CPU Architecture: Unknown";
            // 
            // storageText
            // 
            this.storageText.AutoSize = true;
            this.storageText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.storageText.Location = new System.Drawing.Point(63, 268);
            this.storageText.Name = "storageText";
            this.storageText.Size = new System.Drawing.Size(157, 25);
            this.storageText.TabIndex = 14;
            this.storageText.Text = "Storage: Unknown";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.pictureBox5.Location = new System.Drawing.Point(32, 335);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 31);
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label7.Location = new System.Drawing.Point(63, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(459, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "TPM: Check the BIOS and enable AMD fTPM or Intel PTT.";
            // 
            // storageImage
            // 
            this.storageImage.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.storageImage.Location = new System.Drawing.Point(32, 269);
            this.storageImage.Name = "storageImage";
            this.storageImage.Size = new System.Drawing.Size(33, 31);
            this.storageImage.TabIndex = 15;
            this.storageImage.TabStop = false;
            // 
            // notificationStatus
            // 
            this.notificationStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsSuccess;
            this.notificationStatus.Location = new System.Drawing.Point(117, 16);
            this.notificationStatus.Name = "notificationStatus";
            this.notificationStatus.Size = new System.Drawing.Size(33, 31);
            this.notificationStatus.TabIndex = 18;
            this.notificationStatus.TabStop = false;
            // 
            // notificationText
            // 
            this.notificationText.AutoSize = true;
            this.notificationText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.notificationText.Location = new System.Drawing.Point(151, 15);
            this.notificationText.Name = "notificationText";
            this.notificationText.Size = new System.Drawing.Size(306, 25);
            this.notificationText.TabIndex = 19;
            this.notificationText.Text = "No new alerts from the checker. Nice!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 429);
            this.Controls.Add(this.notificationText);
            this.Controls.Add(this.notificationStatus);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.storageImage);
            this.Controls.Add(this.storageText);
            this.Controls.Add(this.cpuArchitectureStatus);
            this.Controls.Add(this.cpuArchitectureText);
            this.Controls.Add(this.secureBootStatus);
            this.Controls.Add(this.secureBootText);
            this.Controls.Add(this.gpuStatus);
            this.Controls.Add(this.gpuText);
            this.Controls.Add(this.ramImage);
            this.Controls.Add(this.memoryAmount);
            this.Controls.Add(this.cpuStatus);
            this.Controls.Add(this.cpuName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Windows 11 Compatibility Checker";
            ((System.ComponentModel.ISupportInitialize)(this.cpuStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secureBootStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuArchitectureStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cpuName;
        private System.Windows.Forms.PictureBox cpuStatus;
        private System.Windows.Forms.PictureBox ramImage;
        private System.Windows.Forms.Label memoryAmount;
        private System.Windows.Forms.PictureBox gpuStatus;
        private System.Windows.Forms.Label gpuText;
        private System.Windows.Forms.PictureBox secureBootStatus;
        private System.Windows.Forms.Label secureBootText;
        private System.Windows.Forms.PictureBox cpuArchitectureStatus;
        private System.Windows.Forms.Label cpuArchitectureText;
        private System.Windows.Forms.Label storageText;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox storageImage;
        private System.Windows.Forms.PictureBox notificationStatus;
        private System.Windows.Forms.Label notificationText;
    }
}

