using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using log4net;

public class DaoManager
{
	private static object syncLock = new object();
	private static ISqlMapper mapper = null;

	public static ISqlMapper Instance
	{
		get
		{
			try
			{
				if (mapper == null)
				{
					lock (syncLock)
					{
						if (mapper == null)
						{
							DomSqlMapBuilder dom = new DomSqlMapBuilder();

							//XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument( "Config.sqlMap.config" );
							XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("DAO.Config.sqlMap.config, DAO");
							mapper = dom.Configure(sqlMapConfig);

						}
					}
				}

				return mapper;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}