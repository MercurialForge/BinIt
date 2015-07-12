using System;
using System.IO;

namespace BinIt2
{
    public static class FileHelper
    {
        // the total file char length
        public static int MAX_PATH = 260;

        /// <summary>
        /// Moves files. Will overwrite them if bOverwrite true.
        /// Returns the number of files or directories failed to move.
        /// </summary>
        public static bool MoveAndOverwrite(FileInfo sourceFile, FileInfo targetFile)
        {
            if (targetFile.Exists)
            {
                if (Properties.Settings.Default.KeepBoth)
                {
                    while (targetFile.Exists)
                    {
                        // recursive check to append char to filename to make unique
                        string uniqueName = "";
                        uniqueName = targetFile.Name.Substring(0, targetFile.Name.Length - targetFile.Extension.Length);
                        uniqueName += "_dup";
                        uniqueName += targetFile.Extension;
                        string newTargetFile = targetFile.Directory + "\\" + uniqueName;
                        if (newTargetFile.Length >= MAX_PATH)
                        {
                            return false;
                        }
                        else
                        {
                            targetFile = new FileInfo(newTargetFile);
                        }
                    }
                    MoveAndOverwrite(sourceFile, targetFile);
                    return true;
                }
                if (Properties.Settings.Default.Overwrite)
                {
                    // overwrite
                    if (targetFile.Exists)
                    {
                        targetFile.Delete();
                    }
                    File.Move(sourceFile.FullName, targetFile.FullName);
                    return true;
                }
                return false;
            }
            else
            {
                File.Move(sourceFile.FullName, targetFile.FullName);
                return true;
            }
        }

        /// <summary>
        /// Moves directories. If bOverwrite is true it will attempt to merge the files in both directories and delete the older empty directory.
        /// Returns the number of files or directories failed to move.
        /// </summary>
        public static bool MoveAndOverwrite(DirectoryInfo sourceLocation, DirectoryInfo targetLocation)
        {
            if (targetLocation.Exists)
            {
                if (targetLocation.Exists)
                {
                    foreach (FileInfo fi in sourceLocation.GetFiles())
                    {
                        MoveAndOverwrite(fi, new FileInfo(targetLocation.FullName + "\\" + fi.Name));
                    }
                }
                if (sourceLocation.GetFiles().Length == 0)
                {
                    Directory.Delete(sourceLocation.FullName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Directory.Move(sourceLocation.FullName, targetLocation.FullName);
                return true;
            }
        }
    }
}
