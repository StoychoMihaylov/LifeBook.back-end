using Lifebook.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lifebook.Web.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public ActionResult AddArticle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(ArticleBm Article)
        {

            return View();
        }
    }
}