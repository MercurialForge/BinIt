using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinIt2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DirectoryInfo m_desktop;
        private int m_succeddedCount = 0;
        private int m_failedCount = 0;
        private DotIgnore m_ignore;

        public MainWindow()
        {
            InitializeComponent();
            m_ignore = new DotIgnore();
            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Properties.Settings.Default.Reset();

            // tool tip generation
            this.m_bUseSnapshots.ToolTip = "Ignore all shortcuts on the desktop";
            this.m_ignoreFolders.ToolTip = "Ignore all folders on the desktop";
            this.m_keepBoth.ToolTip = "Keep files with identical names by appending \"_dup\"";
            this.m_overwrite.ToolTip = "Overwrites files if already present in BinIt folder";
            this.m_useDotIgnore.ToolTip = "Protect extentions and directories listed in .ignore";
            this.BinIt.ToolTip = "Stash all unwanted files on your desktop in a BinIt folder";
            this.Snapshot.ToolTip = "Record all files and folders currently on your desktop" + Environment.NewLine +
                                                        "and protect them from clean up when running BinIt";

            // Reintialize
            this.m_ignoreShortcuts.IsChecked = Properties.Settings.Default.IgnoreShortcuts;
            this.m_ignoreFolders.IsChecked = Properties.Settings.Default.IgnoreFolders;
            this.m_bUseSnapshots.IsChecked = Properties.Settings.Default.UseSnapshots;
            this.m_keepBoth.IsChecked = Properties.Settings.Default.KeepBoth;
            this.m_overwrite.IsChecked = Properties.Settings.Default.Overwrite;
            this.m_useDotIgnore.IsChecked = Properties.Settings.Default.UseDotIgnore;
            this.Snapshot.IsEnabled = (bool)this.m_bUseSnapshots.IsChecked;
            //this.m_desktopLabel.Text = m_desktop.ToString();

            // check if last snapshot exists, if not display message.
            if (Properties.Settings.Default.LastSnapShot != new DateTime())
            {
                this.OutputLog.Text += string.Format("The last Snapshot was taken on: {0}", Properties.Settings.Default.LastSnapShot.ToString()) + Environment.NewLine;
            }
            else
            {
                if ((bool)this.m_bUseSnapshots.IsChecked)
                {
                    this.BinIt.IsEnabled = false;
                }
                this.OutputLog.Text += "No Snapshot found." + Environment.NewLine;
            }
            this.OutputLog.Text += string.Format("Target Directory is: {0}", m_desktop.ToString()) + Environment.NewLine;
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
                this.OutputLog.Text = "Snapshot failed, please try again. (Or nothing is on you're desktop!)";
            }
            else
            {
                this.OutputLog.Text += "Snapshot sucessfully taken." + Environment.NewLine;
                if (!this.BinIt.IsEnabled)
                {
                    this.BinIt.IsEnabled = true;
                }
            }
        }

        private void Click_BinIt(object sender, RoutedEventArgs e)
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
                if (this.m_ignoreShortcuts.IsChecked == true)
                    if (file.Extension == ".lnk")
                        continue;

                // skip snapshot listings
                if (this.m_bUseSnapshots.IsChecked == true)
                    if (snapshot.Contains(file.ToString()))
                        continue;

                // skip .ignore extentions
                if (this.m_useDotIgnore.IsChecked == true)
                    if (m_ignore.Extentions.Contains(file.Extension.ToLower()))
                        continue;

                // move
                try
                {
                    Internal_MoveAndOverwrite(file);
                }
                catch(Exception x)
                {
                    this.OutputLog.Text += "ERROR: A file to be Binned was found open and cannot be moved." + Environment.NewLine;
                }
            }

            // check all directories
            if (!this.m_ignoreFolders.IsChecked == true)
            {
                foreach (DirectoryInfo dir in m_desktop.GetDirectories())
                {
                    Console.WriteLine(dir.Name);
                    // skip BinIt
                    if (dir.Name.ToLower() == "binit")
                        continue;

                    // skip snapshot listings
                    if (this.m_bUseSnapshots.IsChecked == true)
                        if (snapshot.Contains(dir.ToString()))
                            continue;

                    // skip .ingore directories
                    if (this.m_useDotIgnore.IsChecked == true)
                        if (m_ignore.Directories.Contains(dir.Name.ToLower()))
                            continue;

                    // move
                    try
                    {
                        Internal_MoveAndOverwrite(dir);
                    }
                    catch (Exception x)
                    {
                        this.OutputLog.Text += "ERROR: A file to be Binned was found open and cannot be moved." + Environment.NewLine;
                    }
                }
            }
            // display results
            if (m_succeddedCount + m_failedCount == 0)
            {
                this.OutputLog.Text += "Nothing to BinIt" + Environment.NewLine;
            }
            else
            {
                this.OutputLog.Text += string.Format("{0} suceeded." + Environment.NewLine + "{1} failed.", m_succeddedCount, m_failedCount) + Environment.NewLine;
            }
            if (m_failedCount != 0)
            {
                this.OutputLog.Text += " File already exists or resulting name is too long." + Environment.NewLine;
            }
        }

        private void m_ignoreShortcuts_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IgnoreShortcuts = (bool)this.m_ignoreShortcuts.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void m_ignoreFolders_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IgnoreFolders = (bool)this.m_ignoreFolders.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void m_bUseSnapshots_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UseSnapshots = (bool)this.m_bUseSnapshots.IsChecked;
            Properties.Settings.Default.Save();
            Snapshot.IsEnabled = (bool)this.m_bUseSnapshots.IsChecked;

            if (Properties.Settings.Default.LastSnapShot == new DateTime())
            {
                this.BinIt.IsEnabled = !(bool)this.m_bUseSnapshots.IsChecked;
            }
        }

        private void m_overwrite_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Overwrite = (bool)this.m_overwrite.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void m_keepBoth_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.KeepBoth = (bool)this.m_keepBoth.IsChecked;
            Properties.Settings.Default.Save();
            this.m_overwrite.IsEnabled = !(bool)this.m_keepBoth.IsChecked;
        }

        private void m_useDotIgnore_CheckedChanged(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.UseDotIgnore = (bool)this.m_useDotIgnore.IsChecked;
            Properties.Settings.Default.Save();
        }

        private void Internal_MoveAndOverwrite(FileInfo file)
        {
            FileInfo MoveFrom = file;
            FileInfo MoveTo = new FileInfo(m_desktop.ToString() + "\\" + "BinIt\\" + MoveFrom.Name);
            if (FileHelper.MoveAndOverwrite(MoveFrom, MoveTo))
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
