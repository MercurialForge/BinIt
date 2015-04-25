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
        private int m_succeddedCount = 0;
        private int m_failedCount = 0;
        private DotIgnore m_ignore;

        public BinItWindow()
        {
            // initialize
            InitializeComponent();
            m_ignore = new DotIgnore();
            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // tool tip generation
            this.tipShortcuts.SetToolTip(this.m_ignoreShortcuts, "Ignore all shortcuts on the desktop");
            this.tipFolders.SetToolTip(this.m_ignoreFolders, "Ignore all folders on the desktop");
            this.tipKeepBoth.SetToolTip(this.m_keepBoth, "Keep files with identical names by appending \"_dup\"");
            this.tipOverwrite.SetToolTip(this.m_overwrite, "Overwrites files if already present in BinIt folder");
            this.tipBinIt.SetToolTip(this.BinIt, "Stash all unwanted files on your desktop in a BinIt folder");
            this.tipSnapshot.SetToolTip(this.Snapshot, "Record all files and folders currently on your desktop" + Environment.NewLine +
                                                        "and protect them from clean up when running BinIt");


            this.m_outputText.Text = "Initialized";
            this.m_ignoreShortcuts.Checked = Properties.Settings.Default.IgnoreShortcuts;
            this.m_ignoreFolders.Checked = Properties.Settings.Default.IgnoreFolders;
            this.m_bUseSnapshots.Checked = Properties.Settings.Default.UseSnapshots;
            this.m_keepBoth.Checked = Properties.Settings.Default.KeepBoth;
            this.m_overwrite.Checked = Properties.Settings.Default.Overwrite;
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
                this.m_outputText.Text = "Looks like you don't have a snapshot.";
            }
        }

        private void SnapShot_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // snapshot of desktop files
            foreach (FileInfo str in m_desktop.GetFiles())
            {
                sb.AppendLine(str.ToString());
            }

            // snapshot of directorys
            foreach (DirectoryInfo di in m_desktop.GetDirectories())
            {
                sb.AppendLine(di.ToString());
            }

            // store and save snapshot and timestamp
            Properties.Settings.Default.Snapshot = sb.ToString();
            Properties.Settings.Default.LastSnapShot = DateTime.Now;
            Properties.Settings.Default.Save();

            // display updated timestamp
            this.m_ssTimestamp.Text = Properties.Settings.Default.LastSnapShot.ToString();

            // warn if snapshot is empty
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
            m_succeddedCount = 0;
            m_failedCount = 0;

            // reload DotIngore file
            this.m_ignore.Reload();

            // create BinIt directory if it does not exist
            string BinIt = m_desktop.ToString() + "/" + "BinIt/";
            Directory.CreateDirectory(BinIt);

            // read back the snapshot
            List<string> snapshot = new List<string>(
                Properties.Settings.Default.Snapshot.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            // check all files
            foreach (FileInfo file in m_desktop.GetFiles())
            {
                Console.WriteLine(file.Name);
                // skip shortcuts
                if (this.m_ignoreShortcuts.Checked)
                    if (file.Extension == ".lnk")
                        continue;

                // skip snapshot listings
                if (this.m_bUseSnapshots.Checked)
                    if (snapshot.Contains(file.ToString()))
                        continue;

                // skip .ignore extentions
                if (m_ignore.Extentions.Contains(file.Extension))
                    continue;

                // move
                Internal_MoveAndOverwrite(file);
            }

            // check all directories
            if (!this.m_ignoreFolders.Checked)
            {
                foreach (DirectoryInfo dir in m_desktop.GetDirectories())
                {
                    // skip BinIt
                    if (dir.Name.ToLower() == "binit")
                        continue;

                    // skip snapshot listings
                    if (snapshot.Contains(dir.ToString()))
                        continue;

                    // skip .ingore directories
                    if(m_ignore.Directories.Contains(dir.Name))
                        continue;

                    // move
                    Internal_MoveAndOverwrite(dir);
                }
            }
            // display results
            if(m_succeddedCount + m_failedCount == 0)
            {
                this.m_outputText.Text = "Nothing to BinIt";
            }
            else
            {
                this.m_outputText.Text = string.Format("{0} suceeded." + Environment.NewLine + "{1} failed.", m_succeddedCount, m_failedCount);
            }
            if(m_failedCount != 0)
            {
                this.m_outputText.Text += " The files or directories remaining are too long in name.";
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
            if (Properties.Settings.Default.Snapshot == "")
            {
                BinIt.Enabled = !this.m_bUseSnapshots.Checked;
            }
        }

        private void m_overwrite_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Overwrite = this.m_overwrite.Checked;
            Properties.Settings.Default.Save();
        }

        private void m_keepBoth_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepBoth = this.m_keepBoth.Checked;
            Properties.Settings.Default.Save();
            this.m_overwrite.Enabled = !this.m_keepBoth.Checked;
        }

        private void Internal_MoveAndOverwrite(FileInfo file)
        {
            FileInfo MoveFrom = file;
            FileInfo MoveTo = new FileInfo(m_desktop.ToString() + "\\" + "BinIt\\" + MoveFrom.Name);
            if(FileHelper.MoveAndOverwrite(MoveFrom, MoveTo))
            {
                m_succeddedCount++;
            }
            else
            {
                m_failedCount++;
            }
        }

        private void Internal_MoveAndOverwrite(DirectoryInfo dir)
        {
            DirectoryInfo MoveFrom = dir;
            DirectoryInfo MoveTo = new DirectoryInfo(m_desktop.ToString() + "\\" + "BinIt\\" + MoveFrom.Name);
            if (FileHelper.MoveAndOverwrite(MoveFrom, MoveTo))
            {
                m_succeddedCount++;
            }
            else
            {
                m_failedCount++;
            }
        }
    }
}
