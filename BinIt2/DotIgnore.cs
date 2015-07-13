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

        private const string DotIgnoreFileName = ".ignore";

        public DotIgnore()
        {
            Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + DotIgnoreFileName);
            if (Properties.Settings.Default.FirstBoot)
            {
                Properties.Settings.Default.FirstBoot = false;
                using (StreamWriter file = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + DotIgnoreFileName))
                {
                    file.WriteLine("*.afiletype");
                    file.WriteLine("/ADirectoryOrFolder");
                }
            }
        }

        public void Reload()
        {
            Load(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + DotIgnoreFileName);
        }

        private void Load(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                Read(new StreamReader(path));
            }
        }

        public void ReadToLog(TextBox log)
        {
            string line;
            using (StreamReader file = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + DotIgnoreFileName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    log.Text += line + Environment.NewLine;
                }
            }
        }

        public void Save(TextBox log)
        {
            StringCollection lines = new StringCollection();
            int lineCount = log.LineCount;

            for (int line = 0; line < lineCount; line++)
                lines.Add(log.GetLineText(line));

            using (StreamWriter file = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + DotIgnoreFileName))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    file.Write(lines[i]);
                }
            }
        }

        private void Read(TextReader file)
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();

                // skip empty lines
                if (line == string.Empty)
                    continue;

                // skip comments
                else if (line.StartsWith(";") || line.StartsWith("#"))
                    continue;

                // file extentions
                else if (line.StartsWith("*.") || line.StartsWith("."))
                    m_extentions.Add(line.TrimStart('*').ToLower());

                // directory
                else if (line.EndsWith("/"))
                    m_directories.Add(line.TrimEnd('/').ToLower());

                // invalid
                else
                    continue;
            }
            file.Close();
        }

    }
}
