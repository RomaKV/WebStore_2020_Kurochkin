using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.WebStore.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-active-route")]
    public class ActiveRouteTagHelper: TagHelper
    {
        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public  string Controller { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            base.Process(context, output);

            var left =  context.AllAttributes.TryGetAttribute("left-active", out _);

            if (ShouldBeActive(left))
            {
                MakeActive(output);
            }
        }

        private void MakeActive(TagHelperOutput output)
        {
            var classAttribute = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttribute == null)
            {
                classAttribute = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttribute);
            } else if (classAttribute.Value?.ToString()?.Contains("active", StringComparison.Ordinal) != true)
            {
                output.Attributes.SetAttribute("class", classAttribute.Value is null ? "active" : $"{classAttribute.Value} active");
            }
        }

        private bool ShouldBeActive(bool leftActive)
        {
            var currentController = ViewContext.RouteData.Values["Controller"].ToString();

            if (!string.IsNullOrWhiteSpace(Controller) && Controller != currentController)
            {
                return false;
            }

            var currentAction = ViewContext.RouteData.Values["Action"].ToString();

            if (!leftActive && !string.IsNullOrWhiteSpace(Action) && Action != currentAction)
            {
                return false;
            }

            return true;
        }
    }
}
