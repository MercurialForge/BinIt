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
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Click_Snapshot(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).Click_Snapshot();
        }

        private void Click_BinIt(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).Click_BinIt();
        }

        private void OutputText_Updated(object sender, SizeChangedEventArgs e)
        {
            this.m_scrollViewer.UpdateLayout();
            this.m_scrollViewer.ScrollToVerticalOffset(this.m_outputLog.ActualHeight);
        }

        private void ItemText_Updated(object sender, SizeChangedEventArgs e)
        {
            this.m_scrollViewer.UpdateLayout();
            this.m_scrollViewer.ScrollToVerticalOffset(this.m_itemLog.ActualHeight);
        }

        private void IgnoreText_Updated(object sender, SizeChangedEventArgs e)
        {
            this.m_scrollViewer.UpdateLayout();
            this.m_scrollViewer.ScrollToVerticalOffset(this.m_ignoreLog.ActualHeight);
        }

    }
}
