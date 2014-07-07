using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace DAO
{
	public class DaoAccount
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CAccount> getAcountList(string strSearch_)
		{
			IList<CAccount> ilUser = new List<CAccount>();

			try
			{
				IDictionary<string, object> iDic = new Dictionary<string, object>();
				iDic.Add("search_text", strSearch_);

				ilUser = DaoManager.Instance.QueryForList<CAccount>("ACCOUNT.select_account_list", iDic);
			}
			catch (Exception ex)
			{
				System.Console.Out.WriteLine( ex.Message );
				System.Console.Out.WriteLine( ex.StackTrace );
			}

			return ilUser;
		}

		public CAccount getAcount(IDictionary<string, object> dic)
		{
			return DaoManager.Instance.QueryForObject<CAccount>("ACCOUNT.select_account", dic);
		}

		public CAccount getAcount(int idx)
		{
			IDictionary<string, object> iDic = new Dictionary<string, object>();
			iDic.Add("idx", idx);
			return DaoManager.Instance.QueryForObject<CAccount>("ACCOUNT.select_account", idx);
		}

		public CAccount getAcount(string id, string passwd)
		{
			IDictionary<string, object> iDic = new Dictionary<string, object>();
			iDic.Add("id", id);
			iDic.Add("passwd", passwd);
			return getAcount(iDic);
		}
		/*
		public CEmp getEmp(string emp_no, string passwd)
		{
			IDictionary<string, object> iDic = new Dictionary<string, object>();
			iDic.Add("emp_no", emp_no);
			iDic.Add("passwd", passwd);
			return getEmp(iDic);
		}
		*/

		public void setAccount(CAccount acount)
		{
			if (acount.idx == 0)
			{
				DaoManager.Instance.Insert("ACCOUNT.insert_account", acount);
			}
			else
			{
				DaoManager.Instance.Update("ACCOUNT.update_account", acount);
			}
		}

		public void delAccount(int idx)
		{
			DaoManager.Instance.Delete("ACCOUNT.delete_account", idx);
		}

	}
}
