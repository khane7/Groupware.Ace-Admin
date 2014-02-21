using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Partial
{
    public class EditorController : Controller
    {
        //
        // GET: /Editor/

        public ActionResult Index(string content)
        {
			ViewBag.contents = content;
			return PartialView("~/Views/PartialView/ckeditor.cshtml", content);
        }

    }
}
