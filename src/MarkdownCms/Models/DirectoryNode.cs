using System;
using System.Collections.Generic;

namespace MarkdownCms.Models
{
    public class DirectoryNode
    {
        public DirectoryNode()
        {
            this.Subfolders = new List<DirectoryNode>();
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public IList<DirectoryNode> Subfolders { get; set; }

        public bool IsFile { get; set; }

        public String GetPathForUrl()
        {
            //var rootDirectory = ConfigurationManager.AppSettings["FilesPath"];
            var rootDirectory = ".";
            var path = this.Path.Replace(rootDirectory, "");
            path = path.Replace('\\', '/');
            var index = path.LastIndexOf('.');

            path = index > 0 ? path.Substring(0, index) : path;
            return path;
        }
    }    
}