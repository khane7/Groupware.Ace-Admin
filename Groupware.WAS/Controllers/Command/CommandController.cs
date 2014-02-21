using DAO;
using Groupware.Base.Controllers.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace Groupware.Base.Controllers.Command
{
    public class CommandController : Controller
    {
        //
        // GET: /Command/

        public ActionResult Index()
        {
            return View("~/Views/Command/Index.cshtml");
        }

		public ActionResult List()
		{
			DaoCommand daoCommand = new DaoCommand();
			IList<CCommand> listCommand = new List<CCommand>();

			if (Session["emp_no"] == null)
			{
				RedirectToAction("Index", "Login");
			}

			try
			{
				int totalCount = 0;
				int pageNum = (Request["pageNum"] == null) ? 1 : int.Parse(Request["pageNum"]);
				int limitCount = (Session["limitCount"] != null) ? int.Parse(Session["limitCount"].ToString()) : 20;

				TagBuilder tag = new TagBuilder("pageinfo");

				if (Request["list_type"] == "send")
				{
					totalCount = daoCommand.getCommandCount(Request["search_key"], Request["search_value"], Session["emp_no"].ToString(), null);
					listCommand = daoCommand.getCommandList(Request["search_key"], Request["search_value"], Session["emp_no"].ToString(), null, pageNum, limitCount);
				}
				else if (Request["list_type"] == "receive")
				{
					totalCount = daoCommand.getCommandCount(Request["search_key"], Request["search_value"], null, Session["emp_no"].ToString());
					listCommand = daoCommand.getCommandList(Request["search_key"], Request["search_value"], null, Session["emp_no"].ToString(), pageNum, limitCount);
				}
				else
				{
					totalCount = daoCommand.getCommandCount(Request["search_key"], Request["search_value"], null, null);
					listCommand = daoCommand.getCommandList(Request["search_key"], Request["search_value"], null, null, pageNum, limitCount);
				}
				PageInfo pageInfo = new PageInfo();
				pageInfo.TotalItems = totalCount;
				pageInfo.CurrentPage = pageNum;
				pageInfo.ItemsPerPage = limitCount;

				ViewBag.listCommand = listCommand;
				ViewBag.pageInfo = pageInfo;
				ViewBag.PageLink = PageHelper.getPageLink(totalCount, pageNum, limitCount);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

			return PartialView("~/VIews/Command/CommandList.cshtml");
		}

		public ActionResult Write()
		{
			try
			{
				CCommand command = new CCommand();
				if (Request["idx"] != null && int.Parse(Request["idx"]) > 0)
				{
					DaoCommand daoCommand = new DaoCommand();
					command = daoCommand.getCommandOne(int.Parse(Request["idx"]));

					//ViewBag.status = new DaoCode().getCodeList("status", 0, null, 0);
				}

				ViewBag.command = command;
			}
			catch (Exception e)
			{
				
				throw new Exception(e.Message);
			}
			return View("~/VIews/Command/CommandWrite.cshtml");
		}

		public ActionResult View()
		{
			try
			{
				if (Request["idx"] != null && int.Parse(Request["idx"]) > 0)
				{
					DaoCommand daoCommand = new DaoCommand();
					CCommand command = daoCommand.getCommandOne(int.Parse(Request["idx"]));
					ViewBag.command = command;
					if ( command.ord_emp_no.Equals( Session["emp_no"] ) )
					{
						ViewBag.IsAuth = true;
					}
					else
					{
						ViewBag.IsAuth = false;
					}

					ViewBag.status = new DaoCode().getCodeList("status", 0, null, 0);
				}
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
			return View("~/VIews/Command/CommandView.cshtml");
		}

		[HttpPost]
		[ValidateInput(false)]
		public JObject Save()
		{
			JObject jsonObj = new JObject();

			try
			{
				DaoCommand daoCommand = new DaoCommand();
				CCommand command = new CCommand();
				command.subject = Request["subject"];
				command.ord_emp_no = Session["emp_no"].ToString();
				command.ord_emp_name = Request["ord_emp_no"];
				command.ord_type = Request["tree_value"];
				command.content = Request["content"];
				command.reg_ip = UtilityController.getUserIP(Request);

				if (Request["idx"] != null && Request["idx"].ToString() != "")
				{
					command.idx = int.Parse(Request["idx"]);
					command.mod_date = DateTime.Now.Date;
					
				}
				else
				{
					command.reg_date = DateTime.Now;
					command.mod_date = DateTime.Now;
				}
				daoCommand.setCommand(command);
				jsonObj.Add("RESULT", "OK");
			}
			catch (Exception e)
			{
				jsonObj.Add("RESULT", "FAIL");
				jsonObj.Add("MSG", e.Message);
				UtilityController.WriteLog(e.Message);
				//throw new Exception(e.Message);
			}

			return jsonObj;
		}

		[HttpPost]
		public JObject Delete()
		{
			JObject json = new JObject();
			try
			{
				int idx = int.Parse( Request["idx"].ToString() );
				new DaoCommand().deleteCommand(idx);
				json.Add("RESULT", "OK");
			}
			catch (Exception e)
			{
				json.Add("RESULT", "FAIL");
				json.Add("MSG", e.Message);
				//throw;
			}
			return json;
		}

    }
}
