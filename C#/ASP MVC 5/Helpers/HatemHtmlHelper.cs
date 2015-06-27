using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using System.Web.Mvc.Html;

namespace Blex.ModelsHelper
{
    public static class HatemHtmlHelper
    {
        /// <summary>
        /// call the Native TextBoxFor method but saving some little work
        /// This is an Html Helper extinsion method
        /// </summary>
        /// <param name="classname">CSS Class Name</param>
        /// <param name="withPlaceHolder">Is this TextBox have a Place Holder</param>
        public static MvcHtmlString TextBoxForH<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string classname, bool withPlaceHolder = true)
        {
            object htmlAttributes = new{
                @class=classname,
                @placeholder=withPlaceHolder?DisplayNameExtensions.DisplayNameFor(htmlHelper,expression):null
            };
            return InputExtensions.TextBoxFor(htmlHelper, expression, htmlAttributes);
        }
        /// <summary>
        /// call the Native TextBoxFor method but saving some little work
        /// This is an Html Helper extinsion method
        /// </summary>
        /// <param name="classname">CSS Class Name</param>
        /// <param name="withPlaceHolder">Is this TextBox have a Place Holder</param>
        public static MvcHtmlString PasswordForH<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string classname, bool withPlaceHolder = true)
        {
            object htmlAttributes = new
            {
                @class = classname,
                @placeholder = withPlaceHolder ? DisplayNameExtensions.DisplayNameFor(htmlHelper, expression) : null
            };
            return InputExtensions.PasswordFor(htmlHelper, expression, htmlAttributes);
        }

        //
        // Summary:
        //     Returns a radio button input element for each property in the object that is
        //     represented by the specified expression, using the specified HTML attributes.
        //     With the proper value selected.
        //
        // Parameters:
        //   htmlHelper:
        //     The HTML helper instance that this method extends.
        //
        //   expression:
        //     An expression that identifies the object that contains the properties to render.
        //
        //   value:
        //     The value of the selected radio button. and when re-displaying the matched value will be set as "Checked"
        //
        //   htmlAttributes:
        //     An object that contains the HTML attributes to set for the element.
        //
        public static MvcHtmlString RadioButtonForH<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,object expressionValue, object value, string classname =null)
        {
            object htmlAttributes;
            if (expressionValue.Equals(value))
            {
                htmlAttributes = new
                {
                    @class = classname,
                    @checked = "checked"
                };
            }
            else
                htmlAttributes = new
                {
                    @class = classname
                };
            return InputExtensions.RadioButtonFor(htmlHelper, expression, value, htmlAttributes);
        }

        public static MvcHtmlString AjaxAntiForgeryForm(this HtmlHelper htmlHelper)
        {
            string result = "<form id =\"__AjaxAntiForgeryForm\" hidden =\"hidden\" action =\"#\" method =\"post\">";
            result += htmlHelper.AntiForgeryToken().ToHtmlString();
            result += "</form>";
            return new MvcHtmlString(result);
        }
    }
}