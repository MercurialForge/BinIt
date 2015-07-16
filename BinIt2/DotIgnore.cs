using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.Specialized;

namespace BinIt2
{
    public class DotIgnore
    {
        public string[] Extentions { get { return m_extentions.ToArray(); } }
        public string[] Directories { get { return m_directories.ToArray(); } }

        private List<string> m_extentions = new List<string>();
        private List<string> m_directories = new List<string>();

        public DotIgnore()
        {
            Refresh();
        }

        public void Refresh()
        {
            string dotIgnore = Properties.Settings.Default.DotIgnore;
            string[] dotIgnoreSplit = dotIgnore.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string str in dotIgnoreSplit)
            {
                string strTemp = str.Trim();

                // skip empty lines
                if (string.IsNullOrWhiteSpace(strTemp))
                    continue;

                // skip comments
                else if (strTemp.StartsWith(";") || strTemp.StartsWith("#"))
                    continue;

                // file extentions
                else if (strTemp.StartsWith("*.") || strTemp.StartsWith("."))
                    m_extentions.Add(strTemp.TrimStart('*').ToLower());

                // directory
                else if (strTemp.EndsWith("/"))
                    m_directories.Add(strTemp.TrimEnd('/').ToLower());

                // invalid
                else
                    continue;
            }
        }

    }
}
