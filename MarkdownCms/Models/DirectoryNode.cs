using System;
using System.Collections.Generic;
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
    }
}