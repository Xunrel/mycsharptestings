using System;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AjaxDialogs.Models;

namespace AjaxDialogs.HtmlHelpers
{
    /// <summary>
    /// Paging helpers for default HTML ActionLink and Ajax ActionLink
    /// </summary>
    public static class PagingHelpers
    {
        /// <summary>
        /// Helper to generate HTML ActionLink pagination based on <see cref="PagingInfo"/>.
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl, object htmlAttributes = null)
        {
            var result = new StringBuilder();

            for (var i = 1; i < pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.InnerHtml = i.ToString(CultureInfo.InvariantCulture);

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                if (htmlAttributes != null)
                {
                    var newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                    tag.MergeAttributes(newAttributes);
                }
                tag.MergeAttribute("href", pageUrl(i));
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }

        /// <summary>
        /// Helper to generate Ajax ActionLink pagination based on <see cref="PagingInfo"/>.
        /// </summary>
        /// <param name="ajax"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl"></param>
        /// <param name="ajaxOptions"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString AjaxPageLinks(this AjaxHelper ajax, PagingInfo pagingInfo, Func<int, string> pageUrl,
                                                  AjaxOptions ajaxOptions, object htmlAttributes = null)
        {
            var result = new StringBuilder();

            for (var i = 1; i < pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.InnerHtml = HttpUtility.HtmlEncode(i.ToString(CultureInfo.InvariantCulture));

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                if (htmlAttributes != null)
                {
                    var newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                    tag.MergeAttributes(newAttributes);
                }

                tag.MergeAttribute("href", pageUrl(i));

                if (ajax.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
                }

                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}