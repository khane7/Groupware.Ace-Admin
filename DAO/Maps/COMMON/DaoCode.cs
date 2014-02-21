using IBatisNet.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
	public class DaoCode
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CCode> getCodeList(IDictionary<string, Object> dic)
		{
			return DaoManager.Instance.QueryForList<CCode>("CODE.select_code_list", dic);
		}

		public IList<CCode> getCodeList(string tree_type, int tree_code, string emp_no, int tree_level)
		{

			IDictionary<string, object> dic = new Dictionary<string, object>();

			dic.Add("tree_type", tree_type);
			dic.Add("tree_code", tree_code);
			dic.Add("emp_no", emp_no);
			dic.Add("tree_level", tree_level);

			return getCodeList(dic);
		}

		public IList<String> getCodeTypeList()
		{
			return DaoManager.Instance.QueryForList<String>("CODE.select_code_type_list", null);
		}

		public CCode getCodeOne(int tree_code)
		{
			return DaoManager.Instance.QueryForObject<CCode>("CODE.select_code_one", tree_code);
		}

		public void setCodeOne (CCode code)
		{
			if ( code.tree_code == null || code.tree_code == ""  )
			{
				DaoManager.Instance.Insert("CODE.insert_code_one", code);
			}
			else
			{
				DaoManager.Instance.Update("CODE.update_code_one", code);
			}	
		}

		public void deleteCodeOne( int tree_code )
		{
			DaoManager.Instance.Delete("CODE.delete_code_one", tree_code);
		}

	}
}
