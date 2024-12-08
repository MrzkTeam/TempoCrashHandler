using System.Drawing;

namespace TempoCrashHandler
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer

        private void InitializeComponent()
        {
            this.background = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.msgLabel = new System.Windows.Forms.Label();
            this.reportInfoLabel = new System.Windows.Forms.Label();
            this.reportLabelButton = new System.Windows.Forms.Label();
            this.savedInfoLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Transparent;
            this.background.ImageLocation = "";
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(580, 770);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 0;
            this.background.TabStop = false;
            //
            // msgLabel
            //
            this.msgLabel.BackColor = System.Drawing.Color.Black;
            this.msgLabel.ForeColor = System.Drawing.Color.White;
            this.msgLabel.Location = new System.Drawing.Point(0, 25);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Font = LoadFont(path + "/Resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;
            this.msgLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.msgLabel.Size = new System.Drawing.Size(580, 40);
            this.msgLabel.TabIndex = 1;
            // 
            // infoLabel
            // 
            this.infoLabel.BackColor = System.Drawing.Color.FromArgb(0x78000000);
            this.infoLabel.ForeColor = System.Drawing.Color.White;
            this.infoLabel.Location = new System.Drawing.Point(15, 95);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            this.infoLabel.Size = new System.Drawing.Size(580 - 30, 485);
            this.infoLabel.TabIndex = 2;
            // 
            // reportInfoLabel
            // 
            this.reportInfoLabel.BackColor = System.Drawing.Color.FromArgb(0x78000000);
            this.reportInfoLabel.ForeColor = System.Drawing.Color.White;
            this.reportInfoLabel.Location = new System.Drawing.Point(15, 595);
            this.reportInfoLabel.Name = "reportInfoLabel";
            this.reportInfoLabel.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            this.reportInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reportInfoLabel.Size = new System.Drawing.Size(580 - 30, 25);
            this.reportInfoLabel.TabIndex = 3;
            // 
            // reportLabelButton
            // 
            this.reportLabelButton.BackColor = System.Drawing.Color.FromArgb(0x78000000);
            this.reportLabelButton.ForeColor = System.Drawing.Color.White;
            this.reportLabelButton.Location = new System.Drawing.Point(15, 595 + 25);
            this.reportLabelButton.Name = "reportLabelButton";
            this.reportLabelButton.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            this.reportLabelButton.Click += new System.EventHandler(this.StartGitSite);
            this.reportLabelButton.MouseHover += new System.EventHandler(this.ReportInfo_Hover);
            this.reportLabelButton.MouseLeave += new System.EventHandler(this.ReportInfo_Leave);
            this.reportLabelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.reportLabelButton.Size = new System.Drawing.Size(580 - 30, 25);
            this.reportLabelButton.TabIndex = 4;
            // 
            // savedInfoLabel
            // 
            this.savedInfoLabel.BackColor = System.Drawing.Color.FromArgb(0x78000000);
            this.savedInfoLabel.ForeColor = System.Drawing.Color.White;
            this.savedInfoLabel.Location = new System.Drawing.Point(15, 595 + 50);
            this.savedInfoLabel.Name = "savedInfoLabel";
            this.savedInfoLabel.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            this.savedInfoLabel.Click += new System.EventHandler(this.StartFileDir);
            this.savedInfoLabel.MouseHover += new System.EventHandler(this.SavedInfo_Hover);
            this.savedInfoLabel.MouseLeave += new System.EventHandler(this.SavedInfo_Leave);
            this.savedInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.savedInfoLabel.Size = new System.Drawing.Size(550, 25);
            this.savedInfoLabel.TabIndex = 5;
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.Black;
            this.restartButton.Font = LoadFont(path + "/Resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Location = new System.Drawing.Point(30, 680);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(250, 70);
            this.restartButton.TabIndex = 6;
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Black;
            this.exitButton.Font = LoadFont(path + "/Resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(250+30+15, 680);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(250, 70);
            this.exitButton.TabIndex = 7;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.restartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(580, 770);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.reportInfoLabel);
            this.Controls.Add(this.reportLabelButton);
            this.Controls.Add(this.savedInfoLabel);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Tempo Crash Handler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tempo Crash Handler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox background;
        public System.Windows.Forms.Label msgLabel;
        public System.Windows.Forms.Label infoLabel;
        public System.Windows.Forms.Label reportInfoLabel;
        public System.Windows.Forms.Label reportLabelButton;
        public System.Windows.Forms.Label savedInfoLabel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Button exitButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

