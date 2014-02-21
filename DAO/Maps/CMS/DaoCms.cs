using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using log4net;

namespace DAO
{
	public class DaoCms
	{
		private static ILog logManager = LogManager.GetLogger(typeof(DaoManager));

		public IList<CCms> getCmsList( CCms cms_ )
		{
			return DaoManager.Instance.QueryForList<CCms>("CMS.select_cms_list", cms_); ;
		}
	}
}
