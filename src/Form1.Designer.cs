
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
            this.Title = new System.Windows.Forms.Label();
            this.yourSpecsTitle = new System.Windows.Forms.Label();
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
            this.tpmStatus = new System.Windows.Forms.PictureBox();
            this.tpmText = new System.Windows.Forms.Label();
            this.storageImage = new System.Windows.Forms.PictureBox();
            this.notificationStatus = new System.Windows.Forms.PictureBox();
            this.notificationText = new System.Windows.Forms.Label();
            this.darkModeButton = new System.Windows.Forms.Button();
            this.screenResolutionStatus = new System.Windows.Forms.PictureBox();
            this.screenResolutionText = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.biosModeStatus = new System.Windows.Forms.PictureBox();
            this.biosModeText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cpuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secureBootStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuArchitectureStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpmStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenResolutionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biosModeStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.Title.Location = new System.Drawing.Point(23, 51);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(468, 37);
            this.Title.TabIndex = 0;
            this.Title.Text = "Windows 11 Compatibility at a glance";
            // 
            // yourSpecsTitle
            // 
            this.yourSpecsTitle.AutoSize = true;
            this.yourSpecsTitle.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.yourSpecsTitle.Location = new System.Drawing.Point(27, 101);
            this.yourSpecsTitle.Name = "yourSpecsTitle";
            this.yourSpecsTitle.Size = new System.Drawing.Size(110, 28);
            this.yourSpecsTitle.TabIndex = 1;
            this.yourSpecsTitle.Text = "Your Specs:";
            // 
            // cpuName
            // 
            this.cpuName.AutoSize = true;
            this.cpuName.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cpuName.Location = new System.Drawing.Point(63, 135);
            this.cpuName.Name = "cpuName";
            this.cpuName.Size = new System.Drawing.Size(126, 25);
            this.cpuName.TabIndex = 2;
            this.cpuName.Text = "CPU: Checking";
            // 
            // cpuStatus
            // 
            this.cpuStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.cpuStatus.Location = new System.Drawing.Point(32, 136);
            this.cpuStatus.Name = "cpuStatus";
            this.cpuStatus.Size = new System.Drawing.Size(33, 31);
            this.cpuStatus.TabIndex = 3;
            this.cpuStatus.TabStop = false;
            this.cpuStatus.Click += new System.EventHandler(this.cpuStatus_Click);
            // 
            // ramImage
            // 
            this.ramImage.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.ramImage.Location = new System.Drawing.Point(32, 169);
            this.ramImage.Name = "ramImage";
            this.ramImage.Size = new System.Drawing.Size(33, 31);
            this.ramImage.TabIndex = 5;
            this.ramImage.TabStop = false;
            this.ramImage.Click += new System.EventHandler(this.ramImage_Click);
            // 
            // memoryAmount
            // 
            this.memoryAmount.AutoSize = true;
            this.memoryAmount.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.memoryAmount.Location = new System.Drawing.Point(63, 167);
            this.memoryAmount.Name = "memoryAmount";
            this.memoryAmount.Size = new System.Drawing.Size(132, 25);
            this.memoryAmount.TabIndex = 4;
            this.memoryAmount.Text = "RAM: Checking";
            // 
            // gpuStatus
            // 
            this.gpuStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.gpuStatus.Location = new System.Drawing.Point(32, 202);
            this.gpuStatus.Name = "gpuStatus";
            this.gpuStatus.Size = new System.Drawing.Size(33, 31);
            this.gpuStatus.TabIndex = 7;
            this.gpuStatus.TabStop = false;
            this.gpuStatus.Click += new System.EventHandler(this.gpuStatus_Click);
            // 
            // gpuText
            // 
            this.gpuText.AutoSize = true;
            this.gpuText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.gpuText.Location = new System.Drawing.Point(63, 201);
            this.gpuText.Name = "gpuText";
            this.gpuText.Size = new System.Drawing.Size(127, 25);
            this.gpuText.TabIndex = 6;
            this.gpuText.Text = "GPU: Checking";
            // 
            // secureBootStatus
            // 
            this.secureBootStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.secureBootStatus.Location = new System.Drawing.Point(32, 334);
            this.secureBootStatus.Name = "secureBootStatus";
            this.secureBootStatus.Size = new System.Drawing.Size(33, 31);
            this.secureBootStatus.TabIndex = 9;
            this.secureBootStatus.TabStop = false;
            this.secureBootStatus.Click += new System.EventHandler(this.secureBootStatus_Click);
            // 
            // secureBootText
            // 
            this.secureBootText.AutoSize = true;
            this.secureBootText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.secureBootText.Location = new System.Drawing.Point(63, 333);
            this.secureBootText.Name = "secureBootText";
            this.secureBootText.Size = new System.Drawing.Size(241, 25);
            this.secureBootText.TabIndex = 8;
            this.secureBootText.Text = "Secure Boot Status: Checking";
            // 
            // cpuArchitectureStatus
            // 
            this.cpuArchitectureStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.cpuArchitectureStatus.Location = new System.Drawing.Point(32, 235);
            this.cpuArchitectureStatus.Name = "cpuArchitectureStatus";
            this.cpuArchitectureStatus.Size = new System.Drawing.Size(33, 31);
            this.cpuArchitectureStatus.TabIndex = 11;
            this.cpuArchitectureStatus.TabStop = false;
            this.cpuArchitectureStatus.Click += new System.EventHandler(this.cpuArchitectureStatus_Click);
            // 
            // cpuArchitectureText
            // 
            this.cpuArchitectureText.AutoSize = true;
            this.cpuArchitectureText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.cpuArchitectureText.Location = new System.Drawing.Point(63, 234);
            this.cpuArchitectureText.Name = "cpuArchitectureText";
            this.cpuArchitectureText.Size = new System.Drawing.Size(225, 25);
            this.cpuArchitectureText.TabIndex = 10;
            this.cpuArchitectureText.Text = "CPU Architecture: Checking";
            // 
            // storageText
            // 
            this.storageText.AutoSize = true;
            this.storageText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.storageText.Location = new System.Drawing.Point(63, 267);
            this.storageText.Name = "storageText";
            this.storageText.Size = new System.Drawing.Size(154, 25);
            this.storageText.TabIndex = 14;
            this.storageText.Text = "Storage: Checking";
            // 
            // tpmStatus
            // 
            this.tpmStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.tpmStatus.Location = new System.Drawing.Point(32, 367);
            this.tpmStatus.Name = "tpmStatus";
            this.tpmStatus.Size = new System.Drawing.Size(33, 31);
            this.tpmStatus.TabIndex = 17;
            this.tpmStatus.TabStop = false;
            this.tpmStatus.Click += new System.EventHandler(this.tpmStatus_Click);
            // 
            // tpmText
            // 
            this.tpmText.AutoSize = true;
            this.tpmText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.tpmText.Location = new System.Drawing.Point(63, 366);
            this.tpmText.Name = "tpmText";
            this.tpmText.Size = new System.Drawing.Size(128, 25);
            this.tpmText.TabIndex = 16;
            this.tpmText.Text = "TPM: Checking";
            // 
            // storageImage
            // 
            this.storageImage.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.storageImage.Location = new System.Drawing.Point(32, 268);
            this.storageImage.Name = "storageImage";
            this.storageImage.Size = new System.Drawing.Size(33, 31);
            this.storageImage.TabIndex = 15;
            this.storageImage.TabStop = false;
            this.storageImage.Click += new System.EventHandler(this.storageImage_Click);
            // 
            // notificationStatus
            // 
            this.notificationStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsSuccess;
            this.notificationStatus.Location = new System.Drawing.Point(131, 16);
            this.notificationStatus.Name = "notificationStatus";
            this.notificationStatus.Size = new System.Drawing.Size(33, 31);
            this.notificationStatus.TabIndex = 18;
            this.notificationStatus.TabStop = false;
            // 
            // notificationText
            // 
            this.notificationText.AutoSize = true;
            this.notificationText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.notificationText.Location = new System.Drawing.Point(165, 15);
            this.notificationText.Name = "notificationText";
            this.notificationText.Size = new System.Drawing.Size(306, 25);
            this.notificationText.TabIndex = 19;
            this.notificationText.Text = "No new alerts from the checker. Nice!";
            // 
            // darkModeButton
            // 
            this.darkModeButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.darkModeButton.Location = new System.Drawing.Point(531, 446);
            this.darkModeButton.Name = "darkModeButton";
            this.darkModeButton.Size = new System.Drawing.Size(106, 31);
            this.darkModeButton.TabIndex = 20;
            this.darkModeButton.Text = "Dark Mode";
            this.darkModeButton.UseVisualStyleBackColor = true;
            this.darkModeButton.Click += new System.EventHandler(this.darkModeButton_Click);
            // 
            // screenResolutionStatus
            // 
            this.screenResolutionStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.screenResolutionStatus.Location = new System.Drawing.Point(32, 400);
            this.screenResolutionStatus.Name = "screenResolutionStatus";
            this.screenResolutionStatus.Size = new System.Drawing.Size(33, 31);
            this.screenResolutionStatus.TabIndex = 22;
            this.screenResolutionStatus.TabStop = false;
            this.screenResolutionStatus.Click += new System.EventHandler(this.screenResolutionStatus_Click);
            // 
            // screenResolutionText
            // 
            this.screenResolutionText.AutoSize = true;
            this.screenResolutionText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.screenResolutionText.Location = new System.Drawing.Point(63, 398);
            this.screenResolutionText.Name = "screenResolutionText";
            this.screenResolutionText.Size = new System.Drawing.Size(233, 25);
            this.screenResolutionText.TabIndex = 21;
            this.screenResolutionText.Text = "Screen Resolution: Checking";
            // 
            // aboutButton
            // 
            this.aboutButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.aboutButton.Location = new System.Drawing.Point(12, 448);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(106, 29);
            this.aboutButton.TabIndex = 23;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // biosModeStatus
            // 
            this.biosModeStatus.Image = global::Windows_11_Compatibility_Checker.Properties.Resources.WindowsHelp__Custom_1;
            this.biosModeStatus.Location = new System.Drawing.Point(32, 301);
            this.biosModeStatus.Name = "biosModeStatus";
            this.biosModeStatus.Size = new System.Drawing.Size(33, 31);
            this.biosModeStatus.TabIndex = 25;
            this.biosModeStatus.TabStop = false;
            this.biosModeStatus.Click += new System.EventHandler(this.biosModeStatus_Click);
            // 
            // biosModeText
            // 
            this.biosModeText.AutoSize = true;
            this.biosModeText.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.biosModeText.Location = new System.Drawing.Point(63, 300);
            this.biosModeText.Name = "biosModeText";
            this.biosModeText.Size = new System.Drawing.Size(184, 25);
            this.biosModeText.TabIndex = 24;
            this.biosModeText.Text = "BIOS Mode: Checking";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(649, 489);
            this.Controls.Add(this.biosModeStatus);
            this.Controls.Add(this.biosModeText);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.screenResolutionStatus);
            this.Controls.Add(this.screenResolutionText);
            this.Controls.Add(this.darkModeButton);
            this.Controls.Add(this.notificationText);
            this.Controls.Add(this.notificationStatus);
            this.Controls.Add(this.tpmStatus);
            this.Controls.Add(this.tpmText);
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
            this.Controls.Add(this.yourSpecsTitle);
            this.Controls.Add(this.Title);
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
            ((System.ComponentModel.ISupportInitialize)(this.tpmStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenResolutionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biosModeStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label yourSpecsTitle;
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
        private System.Windows.Forms.PictureBox tpmStatus;
        private System.Windows.Forms.Label tpmText;
        private System.Windows.Forms.PictureBox storageImage;
        private System.Windows.Forms.PictureBox notificationStatus;
        private System.Windows.Forms.Label notificationText;
        private System.Windows.Forms.Button darkModeButton;
        private System.Windows.Forms.PictureBox screenResolutionStatus;
        private System.Windows.Forms.Label screenResolutionText;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.PictureBox biosModeStatus;
        private System.Windows.Forms.Label biosModeText;
    }
}

