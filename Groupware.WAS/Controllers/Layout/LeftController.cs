using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Layout
{
    public class LeftController : Controller
    {
        //
        // GET: /Left/

        public ActionResult Index()
        {
			IList<CCode> listTree = new List<CCode>();
			try
			{
				DaoCode daoTree = new DaoCode();
				listTree = daoTree.getCodeList("leftmenu", 0, null, 2);
				ViewBag.listTree = listTree;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/views/layout/LeftMenu.cshtml", listTree);
        }

    }
}
