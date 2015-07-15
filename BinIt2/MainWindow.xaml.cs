using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MainWindow : Window , INotifyPropertyChanged
    {

        static DirectoryInfo m_desktop;
        private DotIgnore m_ignore; 

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            this.m_outputLog.Text += string.Format("Target Directory is: {0}", m_desktop.ToString()) + Environment.NewLine;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
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

        private void Text_Updated(object sender, SizeChangedEventArgs e)
        {
            this.m_scrollViewer.UpdateLayout();
            this.m_scrollViewer.ScrollToVerticalOffset(this.m_outputLog.ActualHeight);
        }

    }
}
