using IBatisNet.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
	public class DaoCommand
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CCommand> getCommandList(IDictionary<string, object> dic)
		{
			return DaoManager.Instance.QueryForList<CCommand>("COMMAND.select_command_list", dic);
		}
		public IList<CCommand> getCommandList(string search_key, string search_value, string ord_emp_no, string receive_emp_no, int page, int limit)
		{
			IDictionary<string, object> dic = new Dictionary<string, object>();
			int start = (page == 1) ? 0 : (page-1) * limit;
			dic.Add("search_key", search_key);
			dic.Add("search_value", search_value);
			dic.Add("ord_emp_no", ord_emp_no);
			dic.Add("receive_emp_no", receive_emp_no);
			dic.Add("start", start);
			dic.Add("limit", limit);

			return getCommandList(dic);
		}

		public CCommand getCommandOne(int idx)
		{
			return DaoManager.Instance.QueryForObject<CCommand>("COMMAND.select_command_one", idx);
		}

		public int getCommandCount(IDictionary<string, object> dic)
		{
			return DaoManager.Instance.QueryForObject<int>("COMMAND.select_command_count", dic);
		}
		public int getCommandCount(string search_key, string search_value, string ord_emp_no, string receive_emp_no )
		{
			IDictionary<string, object> dic = new Dictionary<string, object>();
			dic.Add("search_key", search_key);
			dic.Add("search_value", search_value);
			dic.Add("ord_emp_no", ord_emp_no);
			dic.Add("receive_emp_no", receive_emp_no);

			return getCommandCount(dic);
		}

		public void setCommand( CCommand command )
		{
			if (command.idx == null || command.idx == 0)
			{
				DaoManager.Instance.Insert("COMMAND.insert_command", command);
			}
			else
			{
				DaoManager.Instance.Update("COMMAND.update_command", command);
			}
		}

		public void deleteCommand(int idx)
		{

			DaoManager.Instance.Update("COMMAND.delete_command", idx);
		}

	}
}
