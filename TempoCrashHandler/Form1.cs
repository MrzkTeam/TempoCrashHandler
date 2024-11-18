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
            string msg = this.info[0].ToUpper();
            string info = this.info[1].Replace("$", "\n");

            Font LeFont = LoadFont(path + "/resource/Inconsolata-Regular.ttf", 16, FontStyle.Regular).Font;
            Font LeFontBold = LoadFont(path + "/resource/Inconsolata-Bold.ttf", 20, FontStyle.Bold).Font;

            background.ImageLocation = path + "/engine/crashHandlerBG.png";

            msgLabel.Parent = background;
            msgLabel.Text = msg;
            msgLabel.Font = LoadFont(path + "/resource/Inconsolata-Bold.ttf", 22, FontStyle.Bold).Font;

            infoLabel.Parent = background;
            infoLabel.Text = info;
            infoLabel.Font = LeFont;

            reportInfoLabel.Parent = background;
            reportInfoLabel.Text = "Report To:";
            reportInfoLabel.Font = LeFont;

            reportLabelButton.Parent = background;
            reportLabelButton.Text = this.info[3];
            reportLabelButton.Font = LeFont;

            savedInfoLabel.Parent = background;
            savedInfoLabel.Text = "'" + this.info[2] + "'" + " - Saved to 'logs/'";
            savedInfoLabel.Font = LeFont;

            restartButton.Text = "Restart";
            restartButton.Font = LeFontBold;
            restartButton.Parent = background;
            restartButton.BackColor = Color.FromArgb(0x7809302C);
            restartButton.ForeColor = Color.White;
            restartButton.FlatAppearance.MouseDownBackColor = Color.White;
            restartButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x7809302C);

            exitButton.Text = "Exit";
            exitButton.Font = LeFontBold;
            exitButton.Parent = background;
            exitButton.BackColor = Color.FromArgb(0x7809302C);
            exitButton.ForeColor = Color.White;
            exitButton.FlatAppearance.MouseDownBackColor = Color.White;
            exitButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x7809302C);
        }

        private void StartGitSite(object sender, EventArgs e)
        {
            string cmd = info[3];
            Process.Start(cmd);
        }

        private void ReportInfo_Hover(object sender, EventArgs e)
        {
            reportLabelButton.ForeColor = Color.Yellow;
        }

        private void SavedInfo_Hover(object sender, EventArgs e)
        {
            savedInfoLabel.ForeColor = Color.Yellow;
        }

        private void SavedInfo_Leave(object sender, EventArgs e)
        {
            savedInfoLabel.ForeColor = Color.White;
        }

        private void StartFileDir(object sender, EventArgs e)
        {
            string cmd = path + "/logs/";
            Process.Start(cmd);
        }

        private void ReportInfo_Leave(object sender, EventArgs e)
        {
            reportLabelButton.ForeColor = Color.White;
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
