using MarkdownCms.Controllers;
using Microsoft.Framework.Configuration;
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

        private string root { get; set; }

        public String GetPathForUrl()
        {            
            var rootDirectory = Configuration.FilesPath;
            var path = this.Path.Replace(rootDirectory, "");
            path = path.Replace('\\', '/');
            var index = path.LastIndexOf('.');

            path = index > 0 ? path.Substring(0, index) : path;
            return path;
        }
    }    
}