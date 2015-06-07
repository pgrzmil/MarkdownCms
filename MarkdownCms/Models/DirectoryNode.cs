using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var rootDirectory = ConfigurationManager.AppSettings["FilesPath"];
            var path = this.Path.Replace(rootDirectory, "");
            path = path.Replace('\\', '/');
            var index = path.LastIndexOf('.');

            path = index > 0 ? path.Substring(0, index) : path;
            return path;
        }
    }
}