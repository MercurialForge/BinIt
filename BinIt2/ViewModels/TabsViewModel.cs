using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinIt2
{
    class TabsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        MainWindowViewModel m_owner;
        public TabsViewModel(MainWindowViewModel mainWindowVM)
        {
            m_owner = mainWindowVM;
        }

        public string OutputLog
        {
            get { return LogGenerator(m_owner.OutputLog); }
            set
            {
                m_owner.OutputLog.Add(value);
                OnPropertyChanged("OutputLog");
            }
        }

        public string ItemLog
        {
            get { return LogGenerator(m_owner.ItemLog); }
            set
            {
                m_owner.ItemLog.Add(value);
                OnPropertyChanged("ItemLog");
            }
        }

        private string LogGenerator(BindingList<string> strings)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string str in strings)
            {
                sb.AppendLine(str.ToString());
            }
            return sb.ToString();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
