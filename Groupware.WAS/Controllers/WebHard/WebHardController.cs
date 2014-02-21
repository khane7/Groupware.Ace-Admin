using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.WebHard
{
    public class WebHardController : Controller
    {
        //
        // GET: /WebHard/

        public ActionResult Index()
        {
            return View("~/Views/WebHard/Index.cshtml");
        }

		public ActionResult Popup()
		{
			return View("~/Views/WebHard/PopIndex.cshtml");
		}

    }
}
