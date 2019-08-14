using System;
using System.IO;
using System.Collections.Generic;


namespace readdb.Class
{
    public class PathList
    {
        private System.IO.DirectoryInfo parentDirectory;
        private System.IO.DirectoryInfo childDirectory;

        public PathList()
        {

        }

        ~PathList()
        {

        }

        public void SetParentFolderPath(string parentFolderPath)
        {
            parentDirectory = new System.IO.DirectoryInfo(parentFolderPath);
        }

        public void SetChildFolerPath(string childFolderPath)
        {
            childDirectory = new System.IO.DirectoryInfo(childFolderPath);
        }

        
        public List<DirectoryInfo> GetFolders()
        {
            List<DirectoryInfo> folders = new List<DirectoryInfo>();
            folders.AddRange(parentDirectory.GetDirectories());
            folders.Sort(new CompareDirectoryInfoEntries());
            return folders;
        }

        public List<FileInfo> GetFiles()
        {
            List<FileInfo> files = new List<FileInfo>();
            files.AddRange(childDirectory.GetFiles());
            files.Sort(new CompareFileInfoEntries());
            return files;
        }

        public List<DirectoryInfo> GetFolders(string parentFolderPath)
        {
            SetParentFolderPath(parentFolderPath);
            return GetFolders();
        }

        public List<FileInfo> GetFiles(string childFolderPath)
        {
            SetChildFolerPath(childFolderPath);
            return GetFiles();
        }

        public class CompareDirectoryInfoEntries : IComparer<DirectoryInfo>
        {
            public int Compare(DirectoryInfo f1, DirectoryInfo f2)
            {
                return (string.Compare(f1.Name, f2.Name));
            }
        }

        public class CompareFileInfoEntries : IComparer<FileInfo>
        {
            public int Compare(FileInfo f1, FileInfo f2)
            {
                return (string.Compare(f1.Name, f2.Name));
            }
        }

    }



}
