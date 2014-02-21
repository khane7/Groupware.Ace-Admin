using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Utilities
{
	public class PageInfo
	{
		public int TotalItems { get; set; }
		public int ItemsPerPage { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages
		{
			get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
		}
	}

	public static class PageHelper
	{
		public static MvcHtmlString getPageLink(int TotalItems, int CurrentPage, int ItemsPerPage)
		{
			PageInfo pageinfo = new PageInfo();
			pageinfo.TotalItems = TotalItems;
			pageinfo.CurrentPage = CurrentPage;
			pageinfo.ItemsPerPage = ItemsPerPage;

			return getPageLink(pageinfo);
		}
		
		public static MvcHtmlString getPageLink( PageInfo pageInfo ) {

			StringBuilder sbStart = new StringBuilder();
			sbStart.Append("<div class='row'>");
			sbStart.Append("	<div class='col-sm-6' style='text-align:left;'>");
			sbStart.Append("		<div class='dataTables_info' id='dataTables-example_info' role='alert' aria-live='polite' aria-relevant='all'>Showing " + pageInfo.CurrentPage + " to " + pageInfo.ItemsPerPage + " of " + pageInfo.TotalItems + " entries</div>");
			sbStart.Append("	</div>");
			sbStart.Append("	<div class='col-sm-6' style='text-align:right;'>");
			sbStart.Append("		<div class='dataTables_paginate paging_simple_numbers' id='dataTables-example_paginate'>");
			sbStart.Append("			<ul class='pagination'>");

			//paginate_button previous disabled
			TagBuilder tagliprev = new TagBuilder("li");
			tagliprev.MergeAttribute("tabindex", "0");
			tagliprev.MergeAttribute("aria-controls", "dataTables-example");
			string cssprev = (pageInfo.CurrentPage == 1) ? "paginate_button previous disabled" : "paginate_button previous";
			tagliprev.AddCssClass(cssprev);
			TagBuilder tagiprev = new TagBuilder("a");
			tagiprev.MergeAttribute("href", "javascript:goPageNum('prev');");
			tagiprev.MergeAttribute("disabled", "disabled");
			tagiprev.InnerHtml = "Previous";
			tagliprev.InnerHtml = tagiprev.ToString();

			sbStart.Append(tagliprev.ToString());

			if (pageInfo.TotalPages > 0)
			{
				for (int i = 1; i <= pageInfo.TotalPages; i++)
				{
					TagBuilder tagli = new TagBuilder("li");
					tagli.MergeAttribute("tabindex", "0");
					tagli.MergeAttribute("aria-controls", "dataTables-example");
					string css = (i == pageInfo.CurrentPage) ? "paginate_button active" : "paginate_button ";
					tagli.AddCssClass(css);

					TagBuilder tagi = new TagBuilder("a");
					tagi.MergeAttribute("href", "javascript:goPageNum(" + i + ");");
					tagi.InnerHtml = i.ToString();

					tagli.InnerHtml = tagi.ToString();
					sbStart.Append(tagli.ToString());
				}
			}
			else
			{
				TagBuilder tagli = new TagBuilder("li");
				tagli.MergeAttribute("tabindex", "0");
				tagli.MergeAttribute("aria-controls", "dataTables-example");
				string css = (1 == pageInfo.CurrentPage) ? "paginate_button active" : "paginate_button ";
				tagli.AddCssClass(css);

				TagBuilder tagi = new TagBuilder("a");
				tagi.MergeAttribute("href", "javascript:goPageNum(" + 1 + ");");
				tagi.InnerHtml = 1.ToString();

				tagli.InnerHtml = tagi.ToString();
				sbStart.Append(tagli.ToString());
			}

			//paginate_button next disabled
			TagBuilder taglinext = new TagBuilder("li");
			taglinext.MergeAttribute("tabindex", "0");
			taglinext.MergeAttribute("aria-controls", "dataTables-example");
			string cssnext = (pageInfo.TotalPages == 0 || pageInfo.CurrentPage == pageInfo.TotalPages) ? "paginate_button next disabled" : "paginate_button next";
			taglinext.AddCssClass(cssnext);
			TagBuilder taginext = new TagBuilder("a");
			taginext.MergeAttribute("href", "javascript:goPageNum('next');");
			taginext.MergeAttribute("disabled", "disabled");
			taginext.InnerHtml = "Next";
			taglinext.InnerHtml = taginext.ToString();

			sbStart.Append(taglinext.ToString());

			StringBuilder sbEnd = new StringBuilder();
			sbEnd.Append("			</ul>");
			sbEnd.Append("		</div>");
			sbEnd.Append("	</div>");
			sbEnd.Append("</div>");
			
			return MvcHtmlString.Create( sbStart.ToString() + sbEnd.ToString() );
		}

	}
}
