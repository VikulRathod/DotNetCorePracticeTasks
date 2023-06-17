using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _3_CustomHelpersTask.CustomHelpers
{
    [HtmlTargetElement(Attributes = "asp-active-link")]
    public class ActiveRouteTagHelper : TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context,
            TagHelperOutput output)
        {
            var currentController =
                ViewContext.RouteData.Values["Controller"].ToString();
            var currentAction =
                ViewContext.RouteData.Values["Action"].ToString();

            var tagController = context.AllAttributes.
                FirstOrDefault(a => a.Name == "asp-controller").
                Value.ToString();

            var tagAction = context.AllAttributes.
                FirstOrDefault(a => a.Name == "asp-action").
                Value.ToString();

            if (currentController == tagController.ToString() 
                && currentAction == tagAction.ToString())
            {
                var existingCss = context.AllAttributes.
                    FirstOrDefault(a => a.Name == "class").
                    Value.ToString();

                var cssClass = context.AllAttributes.
                    FirstOrDefault(a => a.Name == "asp-active-link").
                    Value.ToString();

                output.Attributes.SetAttribute("class", $"{existingCss} {cssClass}");
            }
        }
    }
}
