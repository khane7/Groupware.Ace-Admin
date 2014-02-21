using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
	public class PageInfo
	{
		public int TotalItems { get; set; }
		public int ItemsPerPage { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages {
			get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
		}
	}

	public class PageHelper
	{
		
		public static string getPageLink( PageInfo pageInfo ) {

			TagBuilder tagBuilder = new TagBuilder();

		}

	}
}
