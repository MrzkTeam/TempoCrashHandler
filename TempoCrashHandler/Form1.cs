using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace TempoCrashHandler
{
    public partial class Form1 : Form
    {
        private string[] info;

        string path = Directory.GetCurrentDirectory();
        public Form1(string[] args)
        {
            info = args;
            InitializeComponent();
        }
        public struct LoadedFont
        {
            public Font Font { get; set; }
            public FontFamily FontFamily { get; set; }
        }

        public static LoadedFont LoadFont(string file, int fontSize, FontStyle fontStyle)
        {
            var fontCollect = new PrivateFontCollection();
            fontCollect.AddFontFile(file);
            if (fontCollect.Families.Length < 0)
                throw new InvalidOperationException("NO FONT FAMILIES FOUND!");

            var loadFont = new LoadedFont();
            loadFont.FontFamily = fontCollect.Families[0];
            loadFont.Font = new Font(loadFont.FontFamily, fontSize, fontStyle, GraphicsUnit.Pixel);
            return loadFont;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string msg = this.info[0].ToUpper().Replace('"', ' ');
            string info = this.info[1].Replace("$", "\n").Replace('"', ' ');

            Font LeFont = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            Font LeFontBold = LoadFont(path + "/Resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;

            background.ImageLocation = path + "/Resource/CrashDialogBG.png";

            msgLabel.Parent = background;
            msgLabel.Text = msg;
            msgLabel.Font = LoadFont(path + "/Resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;

            infoLabel.Parent = background;
            infoLabel.Text = info;
            infoLabel.Font = LeFont;

            reportInfoLabel.Parent = background;
            reportInfoLabel.Text = "Report To:";
            reportInfoLabel.Font = LeFont;

            reportLabelButton.Parent = background;
            reportLabelButton.Text = this.info[3].Replace('"', ' ');
            reportLabelButton.Font = LeFont;

            savedInfoLabel.Parent = background;
            savedInfoLabel.Text = "'" + this.info[2].Replace('"', ' ') + "'" + " - Dumped";
            savedInfoLabel.Font = LeFont;

            restartButton.Text = "Restart";
            restartButton.Font = LeFontBold;
            restartButton.Parent = background;
            restartButton.BackColor = Color.FromArgb(0x7809302C);
            restartButton.ForeColor = Color.White;
            restartButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x7EB9FFEE);
            restartButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x7F188075);

            exitButton.Text = "Exit";
            exitButton.Font = LeFontBold;
            exitButton.Parent = background;
            exitButton.BackColor = Color.FromArgb(0x7809302C);
            exitButton.ForeColor = Color.White;
            exitButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x7EB9FFEE);
            exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x7F188075);
        }

        private void StartGitSite(object sender, EventArgs e)
        {
            string cmd = info[3];
            Process.Start(cmd);
        }

        private void ReportInfo_Hover(object sender, EventArgs e)
        {
            reportLabelButton.ForeColor = Color.Yellow;
            reportLabelButton.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
        }

        private void SavedInfo_Hover(object sender, EventArgs e)
        {
            savedInfoLabel.ForeColor = Color.Yellow;
            savedInfoLabel.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
        }

        private void SavedInfo_Leave(object sender, EventArgs e)
        {
            savedInfoLabel.ForeColor = Color.White;
            savedInfoLabel.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
        }

        private void StartFileDir(object sender, EventArgs e)
        {
            string cmd = path + "/logs/";
            Process.Start(cmd);
        }

        private void ReportInfo_Leave(object sender, EventArgs e)
        {
            reportLabelButton.ForeColor = Color.White;
            reportLabelButton.Font = LoadFont(path + "/Resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            string cmd = path + "/" + info[4];
            Process.Start(cmd);
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
