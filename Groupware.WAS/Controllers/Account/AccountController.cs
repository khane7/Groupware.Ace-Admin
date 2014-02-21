using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Account
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
			return View("~/Views/Account/Index.cshtml");
        }

		public ActionResult List()
		{
			try
			{

			}
			catch (Exception e)
			{
				
				throw new Exception(e.Message);
			}
			return PartialView("~/Views/Account/List.cshtml");
		}

    }
}
