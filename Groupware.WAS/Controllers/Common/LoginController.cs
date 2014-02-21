using DAO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Groupware.Base.Controllers.common
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index( )
        {

            return View("~/views/common/Login.cshtml");
        }

		[HttpPost]
		public JObject LoginProcess()
		{
			JObject jsonObj = new JObject();
			string strId = Request.Form["id"];

			DaoEmp daoEmp = new DaoEmp();
			
			CEmp emp = daoEmp.getEmp(Request.Form["id"], Request.Form["passwd"]);
			if (emp == null)
			{
				jsonObj.Add("RESULT", "FAIL");
				jsonObj.Add("MSG", "해당되는 사용자가 없습니다.");
			}
			else
			{
				LoginProcess(emp);
				jsonObj.Add("RESULT", "OK");
			}

			return jsonObj;
		}

		public void LoginProcess( CEmp emp )
		{
			Session["idx"] = emp.idx;
			Session["emp_no"] = emp.emp_no;
			Session["name"] = emp.name;
			Session["id"] = emp.id;
			Session["email"] = emp.email;
			Session["reg_date"] = emp.reg_date;
			Session["mod_date"] = emp.mod_date;
			Session["is_used"] = emp.is_used;
			Session["is_admin"] = emp.is_admin;
			Session.Timeout = 240;
		}

		public ActionResult Logout()
		{
			Session.Clear();
			return Index();
		}

		public ActionResult LoginCheck()
		{
			return null;
		}
    }
}
