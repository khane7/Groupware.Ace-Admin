using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Layout
{
    public class HeaderController : Controller
    {
        //
        // GET: /Header/

        public ActionResult Index()
        {
					ViewBag.HeaderTitle = "Groupware Base";

					return PartialView("~/views/layout/Header.cshtml");
        }

    }
}
