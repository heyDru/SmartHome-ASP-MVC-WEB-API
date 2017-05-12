using Model.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SmartHomeMVC.Helpers

{
    public static class DeviceHelper
    {
        public static IHtmlString File(this HtmlHelper helper, Device model)
        {
            //TagBuilder tb = new TagBuilder("input");
            //tb.Attributes.Add("type", "file");
            //tb.Attributes.Add("id", id);


            TagBuilder tag = new TagBuilder("div");

            MvcHtmlString htmlString = PartialExtensions.Partial(helper,"somePartial", model);

            //return new MvcHtmlString(tb.ToString());

            return htmlString;

        }
    }
}