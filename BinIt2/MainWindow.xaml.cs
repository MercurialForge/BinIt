using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace BinIt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static DirectoryInfo m_desktop;
        private DotIgnore m_ignore;

        public MainWindow()
        {
            InitializeComponent();

            m_ignore = new DotIgnore();
            m_ignore.ReadToLog(this.m_dotIgnoreTextBox);
            this.m_dotIgnoreTab.Header = ".ignore";
            this.m_DotIgnoreSave.IsEnabled = false;

            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // tool tip generation
            this.m_useSnapshots.ToolTip = "Ignore all shortcuts on the desktop";
            this.m_ignoreFolders.ToolTip = "Ignore all folders on the desktop";
            this.m_keepBoth.ToolTip = "Keep files with identical names by appending \"_dup\"";
            this.m_overwrite.ToolTip = "Overwrites files if already present in BinIt folder";
            this.m_useDotIgnore.ToolTip = "Protect extentions and directories listed in .ignore";
            this.m_BinIt.ToolTip = "Stash all unwanted files on your desktop in a BinIt folder";
            this.m_Snapshot.ToolTip = "Record all files and folders currently on your desktop" + Environment.NewLine +
                                                        "and protect them from clean up when running BinIt";

            // Reintialize
            this.m_ignoreShortcuts.IsChecked = Properties.Settings.Default.IgnoreShortcuts;
            this.m_ignoreFolders.IsChecked = Properties.Settings.Default.IgnoreFolders;
            this.m_useSnapshots.IsChecked = Properties.Settings.Default.UseSnapshots;
            this.m_keepBoth.IsChecked = Properties.Settings.Default.KeepBoth;
            this.m_overwrite.IsChecked = Properties.Settings.Default.Overwrite;
            this.m_useDotIgnore.IsChecked = Properties.Settings.Default.UseDotIgnore;
            this.m_Snapshot.IsEnabled = this.m_useSnapshots.IsChecked.Value;
            //this.m_desktopLabel.Text = m_desktop.ToString();

            // check if last snapshot exists, if not display message.
            if (Properties.Settings.Default.LastSnapShot != new DateTime())
            {
                this.m_outputLog.Text += string.Format("The last Snapshot was taken on: {0}", Properties.Settings.Default.LastSnapShot.ToString()) + Environment.NewLine;
            }
            else
            {
                if ((bool)this.m_useSnapshots.IsChecked)
                {
                    this.m_BinIt.IsEnabled = false;
                }
                this.m_outputLog.Text += "No Snapshot found." + Environment.NewLine;
            }
            this.m_outputLog.Text += string.Format("Target Directory is: {0}", m_desktop.ToString()) + Environment.NewLine;
        }

        private void Click_Snapshot(object sender, RoutedEventArgs e)
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
            //this.m_ssTimestamp.Text = Properties.Settings.Default.LastSnapShot.ToString();

            // warn if snapshot is empty
            if (Properties.Settings.Default.Snapshot == "")
            {
                this.m_outputLog.Text = "Snapshot failed, please try again. (Or nothing is on you're desktop!)";
            }
            else
            {
                this.m_outputLog.Text += "Snapshot sucessfully taken." + Environment.NewLine;
                if (!this.m_BinIt.IsEnabled)
                {
                    this.m_BinIt.IsEnabled = true;
                }
            }
        }

        private void Click_BinIt(object sender, RoutedEventArgs e)
        {
            int m_succeeded = 0;
            int m_failed = 0;

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
                // skip shortcuts
                if (this.m_ignoreShortcuts.IsChecked.Value)
                    if (file.Extension == ".lnk")
                        continue;

                // skip snapshot listings
                if (this.m_useSnapshots.IsChecked.Value)
                    if (snapshot.Contains(file.ToString()))
                        continue;

                // skip .ignore extentions
                if (this.m_useDotIgnore.IsChecked.Value)
                    if (m_ignore.Extentions.Contains(file.Extension.ToLower()))
                        continue;

                // move
                this.m_itemLog.Text += file.Name + Environment.NewLine;
                int[] count;
                count = FileHelper.MoveAndOverwrite(m_desktop.ToString(), file);
                m_succeeded += count[0];
                m_failed += count[1];
            }

            // check all directories
            if (!this.m_ignoreFolders.IsChecked.Value)
            {
                foreach (DirectoryInfo dir in m_desktop.GetDirectories())
                {
                    // skip BinIt
                    if (dir.Name.ToLower() == "binit")
                        continue;

                    // skip snapshot listings
                    if (this.m_useSnapshots.IsChecked.Value)
                        if (snapshot.Contains(dir.ToString()))
                            continue;

                    // skip .ingore directories
                    if (this.m_useDotIgnore.IsChecked.Value)
                        if (m_ignore.Directories.Contains(dir.Name.ToLower()))
                            continue;

                    // move
                    this.m_itemLog.Text += dir.Name + Environment.NewLine;
                    int[] count;
                    count = FileHelper.MoveAndOverwrite(m_desktop.ToString(), dir);
                    m_succeeded += count[0];
                    m_failed += count[1];
                }
            }
            // display results
            if (m_succeeded + m_failed == 0)
            {
                this.m_outputLog.Text += "Nothing to BinIt" + Environment.NewLine;
            }
            else
            {
                this.m_outputLog.Text += string.Format("{0} suceeded" + " - " + "{1} failed.", m_succeeded, m_failed) + Environment.NewLine;
            }
            if (m_failed != 0)
            {
                this.m_outputLog.Text += string.Format("{0} File(s) failed because they exists or are currently open.", m_failed) + Environment.NewLine;
            }
        }

        private void m_ignoreShortcuts_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IgnoreShortcuts = this.m_ignoreShortcuts.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void m_ignoreFolders_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IgnoreFolders = this.m_ignoreFolders.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void m_bUseSnapshots_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UseSnapshots = this.m_useSnapshots.IsChecked.Value;
            Properties.Settings.Default.Save();
            m_Snapshot.IsEnabled = this.m_useSnapshots.IsChecked.Value;

            if (Properties.Settings.Default.LastSnapShot == new DateTime())
            {
                this.m_BinIt.IsEnabled = !this.m_useSnapshots.IsChecked.Value;
            }
        }

        private void m_overwrite_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Overwrite = this.m_overwrite.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void m_keepBoth_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.KeepBoth = this.m_keepBoth.IsChecked.Value;
            Properties.Settings.Default.Save();
            this.m_overwrite.IsEnabled = !this.m_keepBoth.IsChecked.Value;
        }

        private void m_useDotIgnore_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UseDotIgnore = this.m_useDotIgnore.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void Text_Updated(object sender, SizeChangedEventArgs e)
        {
            this.m_scrollViewer.UpdateLayout();
            this.m_scrollViewer.ScrollToVerticalOffset(this.m_outputLog.ActualHeight);
        }

        private void m_dotIgnoreTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.m_DotIgnoreSave.IsEnabled = true;
            this.m_dotIgnoreTab.Header = ".ignore*";
        }

        private void m_DotIgnoreSave_Click(object sender, RoutedEventArgs e)
        {
            this.m_DotIgnoreSave.IsEnabled = false;
            m_ignore.Save(this.m_dotIgnoreTextBox);
            this.m_dotIgnoreTab.Header = ".ignore";
        }
    }
}
