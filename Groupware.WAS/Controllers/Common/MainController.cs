using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.common
{
    public class MainController : Controller
    {
        //
        // GET: /MainCommon/

        public ActionResult Index()
        {
					if (Session["idx"] == null || Session["emp_no"] == null)
					{
						return RedirectToAction("index", "login");
					}

            return View("~/views/common/main.cshtml");
        }

    }
}
