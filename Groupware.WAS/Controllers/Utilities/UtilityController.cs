using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Groupware.Base.Controllers.Utilities
{
    public class UtilityController : Controller
    {
        //
        // GET: /Utility/

        public ActionResult Index()
        {
            return View();
        }

		public static void WriteLog( string strLog )
		{
			Console.Out.WriteLine(strLog);
		}

		public static string getClientIP()
		{
			string hostname = null;
			string ipaddr = null; 
			IPAddress[] ips;
			hostname = Dns.GetHostName();
			ips = Dns.GetHostAddresses(hostname);
			foreach (IPAddress ip in ips)
			{
				ipaddr = ip.ToString();
			}
			return ipaddr;
		}

		public static string getUserIP( HttpRequestBase request )
		{
			string ipList = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (!string.IsNullOrEmpty(ipList))
			{
				return ipList.Split(',')[0];
			}

			return request.ServerVariables["REMOTE_ADDR"];
		}

    }
}
