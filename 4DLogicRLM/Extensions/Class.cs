using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UserMenuExtensions
    {
        

        public static string MenuUrl(this IHtmlHelper htmlHelper)
        {
            var viewContext = htmlHelper.ViewContext;
            var currentPageUrl = viewContext.HttpContext.Request.Path;
            string PageUrl = currentPageUrl.ToString();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            PageUrl = rgx.Replace(PageUrl, " ");

            string[] currentPageWords = PageUrl.Split(' ');
            foreach(var item in currentPageWords)
            {
                PageUrl = "";
            }
            return currentPageUrl;
        }

        public static string PageName(this IHtmlHelper htmlHelper)
        {
            var viewContext = htmlHelper.ViewContext;
            var currentPageUrl = viewContext.HttpContext.Request.Path;
            string PageUrl = currentPageUrl.ToString();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            PageUrl = rgx.Replace(PageUrl, " ");
            string PageWords = "";
            string[] currentPageWords = PageUrl.Split(' ');

            var result = new StringBuilder();

            //for (int i = 0; i < currentPageWords.Count(); i++)
            //{
            //    foreach (var ch in currentPageWords[i])
            //    {
            //        if (char.IsUpper(ch) && result.Length > 0)
            //        {
            //            result.Append(' ');
            //        }
            //        result.Append(ch);
            //    }
            //    currentPageWords[i] = result.ToString();
            //}

            

            foreach (var item in currentPageWords)
            {
                if(item != "" || item != " ")
                {
                    if (item != "Identity")
                    {
                        PageWords = PageWords + " " + Regex.Replace(item, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
                    }
                }
            }
            return PageWords;
        }
    }
}
