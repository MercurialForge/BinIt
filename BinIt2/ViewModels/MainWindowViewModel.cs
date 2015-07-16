using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinIt2
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<string> OutputLog { get; private set; }
        public BindingList<string> ItemLog { get; private set; }

        public TabsViewModel Tabs { get; private set; }

        private DotIgnore m_ignore;
        private DirectoryInfo m_desktop;

        public MainWindowViewModel()
        {
            OutputLog = new BindingList<string>();
            ItemLog = new BindingList<string>();

            Tabs = new TabsViewModel(this);

            m_desktop = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            m_ignore = new DotIgnore();

            LogMessage(string.Format("Target Directory is: {0}", m_desktop.ToString()));
        }

        public void LogMessage (string s)
        {
            Tabs.OutputLog = s;
        }

        public void ItemMessage (string s)
        {
            Tabs.ItemLog = s;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Click_Snapshot()
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
                LogMessage("Snapshot failed, please try again. (Or nothing is on you're desktop!)");
            }
            else
            {
                LogMessage("Snapshot sucessfully taken.");
            }
        }

        public void Click_BinIt()
        {
            int m_succeeded = 0;
            int m_failed = 0;

            // reload DotIngore file
            m_ignore.Refresh();

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
                if (Properties.Settings.Default.IgnoreShortcuts)
                    if (file.Extension == ".lnk")
                        continue;

                // skip snapshot listings
                if (Properties.Settings.Default.UseSnapshot)
                    if (snapshot.Contains(file.ToString()))
                        continue;

                // skip .ignore extentions
                if (Properties.Settings.Default.UseDotIgnore)
                    if (m_ignore.Extentions.Contains(file.Extension.ToLower()))
                        continue;

                // move
                ItemMessage(file.Name);

                int[] count;
                count = FileHelper.MoveAndOverwrite(m_desktop.ToString(), file);
                m_succeeded += count[0];
                m_failed += count[1];
            }

            // check all directories
            if (!Properties.Settings.Default.IgnoreFolders)
            {
                foreach (DirectoryInfo dir in m_desktop.GetDirectories())
                {
                    // skip BinIt
                    if (dir.Name.ToLower() == "binit")
                        continue;

                    // skip snapshot listings
                    if (Properties.Settings.Default.UseSnapshot)
                        if (snapshot.Contains(dir.ToString()))
                            continue;

                    // skip .ingore directories
                    if (Properties.Settings.Default.UseDotIgnore)
                        if (m_ignore.Directories.Contains(dir.Name.ToLower()))
                            continue;

                    // move
                    ItemMessage(dir.Name);

                    int[] count;
                    count = FileHelper.MoveAndOverwrite(m_desktop.ToString(), dir);
                    m_succeeded += count[0];
                    m_failed += count[1];
                }
            }


            // display results
            if (m_succeeded + m_failed == 0)
            {
                ItemMessage("Nothing to Bin");
                LogMessage("Nothing to Bin");
            }
            else
            {
                LogMessage(string.Format("{0} suceeded" + " - " + "{1} failed.", m_succeeded, m_failed));
            }
            if (m_failed != 0)
            {
                LogMessage(string.Format("{0} File(s) failed because they already exist or are currently open.", m_failed));
            }

            // break item messages
            ItemMessage("----------");
        }
    }
}
