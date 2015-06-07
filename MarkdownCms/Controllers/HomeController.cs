using MarkdownCms.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkdownCms.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string path = "")
        {
            var rootPath = ConfigurationManager.AppSettings["FilesPath"];
            var tree = DirectoryHelper.GetDirectoryTree(rootPath);
            ViewBag.Nodes = tree;

            using (var reader = new System.IO.StreamReader(rootPath + "\\README.md"))
            {
                var fileContent = reader.ReadToEnd();
                var htmlResult = CommonMark.CommonMarkConverter.Convert(fileContent);
                ViewBag.FileContent = htmlResult;
            }
            return View();
        }
    }
}