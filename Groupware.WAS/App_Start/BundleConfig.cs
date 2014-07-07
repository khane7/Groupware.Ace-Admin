using System.Web;
using System.Web.Optimization;

namespace Groupware.Base
{
	public class BundleConfig
	{
		// Bundling에 대한 자세한 정보는 http://go.microsoft.com/fwlink/?LinkId=254725를 방문하십시오.
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						"~/Scripts/jquery-ui-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.unobtrusive*",
						"~/Scripts/jquery.validate*"));

			// Modernizr의 개발 버전을 사용하여 개발하고 배우십시오. 그런 다음
			// 프로덕션할 준비가 되면 http://modernizr.com의 빌드 도구를 사용하여 필요한 테스트만 선택하십시오.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
						"~/Content/themes/base/jquery.ui.core.css",
						"~/Content/themes/base/jquery.ui.resizable.css",
						"~/Content/themes/base/jquery.ui.selectable.css",
						"~/Content/themes/base/jquery.ui.accordion.css",
						"~/Content/themes/base/jquery.ui.autocomplete.css",
						"~/Content/themes/base/jquery.ui.button.css",
						"~/Content/themes/base/jquery.ui.dialog.css",
						"~/Content/themes/base/jquery.ui.slider.css",
						"~/Content/themes/base/jquery.ui.tabs.css",
						"~/Content/themes/base/jquery.ui.datepicker.css",
						"~/Content/themes/base/jquery.ui.progressbar.css",
						"~/Content/themes/base/jquery.ui.theme.css"));

			/**
			 * jquery library
			 * */
			bundles.Add(new ScriptBundle("~/jquerylib/jstree-js").Include(
						"~/Content/jstree/jstree.js",
						"~/Content/jstree/jstree.min.js"));
			bundles.Add(new StyleBundle("~/jquerylib/jstree-css").Include(
						"~/Content/jstree/themes/default/style.css",
						"~/Content/jstree/themes/default/style.min.css"));

			/**
			 * bootstrap
			 * */

			//bundles.Add(new StyleBundle("~/custom/bootstrap-css").Include(
			//			"~/css/bootstrap.css",
			//			"~/css/bootstrap.min.css"));

			//bundles.Add(new ScriptBundle("~/custom/bootstrap-js").Include(
			//			"~/js/bootstrap.js",
			//			"~/js/bootstrap.min.js"));

			/**
			 * utility
			 * */
			bundles.Add(new ScriptBundle("~/custom/common-js").Include(
						"~/js/common/utility.js"));

		}
	}
}