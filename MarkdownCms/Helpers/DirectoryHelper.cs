using MarkdownCms.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownCms.Helpers
{
    public static class DirectoryHelper
    {
        public static IList<DirectoryNode> GetDirectoryTree(string path)
        {
            List<DirectoryNode> directoryTree = new List<DirectoryNode>();

            var currentDirectory = new DirectoryInfo(path);
            FileInfo[] files;
            DirectoryInfo[] subDirs;

            // First, process all the files directly under this folder
            try
            {
                files = currentDirectory.GetFiles();
            }
            // This is thrown if even one of the files requires permissions greater than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                throw e;
            }

            foreach (var file in files)
            {
                directoryTree.Add(new DirectoryNode() { Name = Path.GetFileNameWithoutExtension(file.Name), Path = file.FullName, IsFile = true });
            }

            // Now find all the subdirectories under this directory.
            subDirs = currentDirectory.GetDirectories();
            foreach (var dirInfo in subDirs)
            {
                directoryTree.Add(new DirectoryNode { Name = dirInfo.Name, Path = dirInfo.FullName, Subfolders = GetDirectoryTree(dirInfo.FullName) });
            }

            return directoryTree;
        }
    }
}