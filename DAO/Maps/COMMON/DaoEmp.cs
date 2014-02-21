using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace DAO
{
	public class DaoEmp
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CEmp> getEmpList( string strSearch_ )
		{
			IList<CEmp> ilUser = new List<CEmp>();

			try
			{
				IDictionary<string, object> iDic = new Dictionary<string, object>();
				iDic.Add("EMP.search_text", strSearch_);

				ilUser = DaoManager.Instance.QueryForList<CEmp>("EMP.select_emp_list", iDic);
			}
			catch (Exception ex)
			{
				System.Console.Out.WriteLine( ex.Message );
				System.Console.Out.WriteLine( ex.StackTrace );
			}

			return ilUser;
		}

		public CEmp getEmp( IDictionary<string, object> dic )
		{
			return DaoManager.Instance.QueryForObject<CEmp>("EMP.select_emp", dic);
		}

		public CEmp getEmp( int idx )
		{
			IDictionary<string, object> iDic = new Dictionary<string, object>();
			iDic.Add("idx", idx);
			return DaoManager.Instance.QueryForObject<CEmp>("EMP.select_emp", idx);
		}

		public CEmp getEmp(string id, string passwd)
		{
			IDictionary<string, object> iDic = new Dictionary<string, object>();
			iDic.Add("id", id);
			iDic.Add("passwd", passwd);
			return getEmp( iDic );
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

		public void setEmp(CEmp emp)
		{
			if (emp.idx == null || emp.idx == 0)
			{
				DaoManager.Instance.Insert("EMP.insert_emp", emp);
			}
			else
			{
				DaoManager.Instance.Update("EMP.update_emp", emp);
			}
		}

		public void delEmp(int idx)
		{
			DaoManager.Instance.Delete("EMP.delete_emp", idx );
		}

	}
}
