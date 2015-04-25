using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinIt
{
    public partial class BinItWindow : Form
    {
        // The Target Desktop
        private DirectoryInfo m_desktop;

        public BinItWindow()
        {
            // initialize
            InitializeComponent();
            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // delete me 
            //Properties.Settings.Default.Reset();


            this.m_ignoreShortcuts.Checked = Properties.Settings.Default.IgnoreShortcuts;
            this.m_ignoreFolders.Checked = Properties.Settings.Default.IgnoreFolders;
            this.m_bUseSnapshots.Checked = Properties.Settings.Default.UseSnapshots;
            this.Snapshot.Enabled = this.m_bUseSnapshots.Checked;
            this.m_desktopLabel.Text = m_desktop.ToString();


            // check if last snapshot exists, if not display message.
            if (Properties.Settings.Default.LastSnapShot != new DateTime())
            {
                this.m_ssTimestamp.Text = Properties.Settings.Default.LastSnapShot.ToString();
            }

            if (Properties.Settings.Default.Snapshot == "")
            {
                this.BinIt.Enabled = false;
                this.m_outputText.Text = "Looks like you don't have a snapshot. You need to take one before using BinIt.";
            }
        }

        private void SnapShot_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // snapshot of desktop files
            foreach (FileInfo str in m_desktop.GetFiles())
            {
                sb.AppendLine(str.ToString());
                Console.WriteLine(str.ToString());
            }

            // snapshot of directorys
            foreach (DirectoryInfo di in m_desktop.GetDirectories())
            {
                sb.AppendLine(di.ToString());
            }
            Properties.Settings.Default.Snapshot = sb.ToString();

            // store snapshot timestamp
            Properties.Settings.Default.LastSnapShot = DateTime.Now;
            Properties.Settings.Default.Save();

            // display updated timestamp
            this.m_ssTimestamp.Text = Properties.Settings.Default.LastSnapShot.ToString();

            // respond to snapshot button
            if (Properties.Settings.Default.Snapshot == "")
            {
                this.m_outputText.Text = "Snapshot failed, please try again. (Or nothing is on you're desktop!)";
            }
            else
            {
                this.m_outputText.Text = "Snapshot sucessfully taken.";
                if (!this.BinIt.Enabled)
                {
                    this.BinIt.Enabled = true;
                }
            }
        }

        private void BinIt_Click(object sender, EventArgs e)
        {
            int moveCount = 0;
            string BinIt = m_desktop.ToString() + "/" + "BinIt/";
            Directory.CreateDirectory(BinIt);

            List<string> snapshot = new List<string>(
                Properties.Settings.Default.Snapshot.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            foreach (FileInfo str in m_desktop.GetFiles())
            {
                if (this.m_ignoreShortcuts.Checked)
                {
                    if (str.Extension == ".lnk")
                    {
                        continue;
                    }
                }
                if (this.m_bUseSnapshots.Checked)
                {
                    if (snapshot.Contains(str.ToString()))
                    {
                        continue;
                    }
                }
                string MoveFrom = str.FullName;
                string MoveTo = m_desktop.ToString() + "/" + "BinIt/" + str.ToString();
                File.Move(MoveFrom, MoveTo);
                moveCount++;
            }

            if (!this.m_ignoreFolders.Checked)
            {
                foreach (DirectoryInfo di in m_desktop.GetDirectories())
                {
                    if (snapshot.Contains(di.ToString()))
                    {
                        continue;
                    }
                    string MoveFrom = di.FullName;
                    string MoveTo = m_desktop.ToString() + "/" + "BinIt/" + di.ToString();
                    Directory.Move(MoveFrom, MoveTo);
                    moveCount++;
                }
            }

            if (moveCount == 0)
            {
                this.m_outputText.Text = "Nothing to move, you have a super clean desktop, nice job!";
            }
            else
            {
                this.m_outputText.Text = string.Format("{0} -- files moved to the BinIt folder!", moveCount);
            }
        }

        private void m_ignoreShortcuts_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreShortcuts = this.m_ignoreShortcuts.Checked;
            Properties.Settings.Default.Save();
        }

        private void m_ignoreFolders_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreFolders = this.m_ignoreFolders.Checked;
            Properties.Settings.Default.Save();
        }

        private void m_bUseSnapshots_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.UseSnapshots = this.m_bUseSnapshots.Checked;
            Properties.Settings.Default.Save();
            Snapshot.Enabled = this.m_bUseSnapshots.Checked;
        }
    }
}
