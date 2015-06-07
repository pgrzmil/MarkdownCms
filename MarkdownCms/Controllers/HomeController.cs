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
        public ActionResult Index()
        {
            //var tree = DirectoryHelper.GetDirectoryTree(ConfigurationManager.AppSettings["FilesPath"]);
            return View();
        }
    }
}