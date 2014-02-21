using DAO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Utilities
{
    public class CodeController : Controller
    {
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult StatusList(string tree_type, int tree_level, string tree_value)
		{
			IList<CCode> listCode = new List<CCode>();
			try
			{
				DaoCode daoTree = new DaoCode();
				listCode = daoTree.getCodeList(tree_type, 0, null, tree_level);
				ViewBag.listCode = listCode;
				ViewBag.tree_value = (tree_value == null || tree_value == "") ? "" : tree_value;
			}
			catch (Exception e)
			{
				UtilityController.WriteLog(e.Message);
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/PartialView/StatusView.cshtml", listCode);
		}

		public ActionResult CodePreview(string tree_type)
		{
			IList<CCode> listCode = new List<CCode>();
			try
			{
				if (tree_type == null || tree_type == "")
				{
					tree_type = "company";
				}

				DaoCode daoCode = new DaoCode();
				listCode = daoCode.getCodeList(tree_type, 0, null, 0);
				ViewBag.listCode = listCode;
				ViewBag.listCodeType = daoCode.getCodeTypeList();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/Views/Code/CodePreview.cshtml", listCode);
		}

		public JsonResult getCodeOne(int tree_code)
		{
			CCode code = new CCode();
			JsonResult json = new JsonResult();

			HttpContext.GetGlobalResourceObject("c", "s");

			try
			{
				DaoCode daoTree = new DaoCode();

				code = daoTree.getCodeOne(tree_code);
				json.Data = code;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return json;
		}

		[HttpPost]
		public JObject setCodeOne(FormCollection form)
		{
			//Request.Form["frm"][];
			JObject jobj = new JObject();
			try
			{
				CCode code = new CCode();
				code.tree_code = form["tree_code"];
				code.tree_type = form["tree_type"];
				code.tree_level = form["tree_order"].Split('.').Length;
				code.tree_key = form["tree_key"];
				code.tree_value = form["tree_value"];
				code.tree_order = form["tree_order"];
				code.html_class = form["html_class"];

				new DaoCode().setCodeOne(code);
				jobj.Add("RESULT", "OK");

			}
			catch (Exception e)
			{
				jobj.Add("RESULT", "FAIL");
				jobj.Add("MSG", e.Message);
				//throw new Exception(e.Message);
			}
			return jobj;
		}

		[HttpPost]
		public JObject deleteCodeOne(FormCollection form)
		{
			//Request.Form["frm"][];
			JObject jobj = new JObject();
			try
			{
				new DaoCode().deleteCodeOne( int.Parse( form["tree_code"] ));

				jobj.Add("RESULT", "OK");

			}
			catch (Exception e)
			{
				jobj.Add("RESULT", "FAIL");
				jobj.Add("MSG", e.Message);
				//throw new Exception(e.Message);
			}
			return jobj;
		}

    }
}
