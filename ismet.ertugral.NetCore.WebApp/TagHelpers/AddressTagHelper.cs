using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.TagHelpers
{
    [HtmlTargetElement("Address")]
    public class AddressTagHelper : TagHelper
    {
        private readonly string _printableButton =
        //"<iframe width=\"100%\" height=\"510\" id=\"gmap_canvas\" src=\"https://maps.google.com/maps?q={0}&t=&z=10&ie=UTF8&iwloc=&output=embed\" frameborder=\"0\" scrolling=\"no\" marginheight=\"0\" marginwidth=\"0\"></iframe>" +
        "<button type='button' class='btn {2}' onclick=\"window.open(" +
        "'https://www.google.com/maps/search/{0}')\" style=\"{3}\">" +
        "📍{1} 🗺️</button>";
        public string ClassValue { get; set; }
        public string StyleValue { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.Content.SetHtmlContent($"<div>{string.Format(_printableButton, content.GetContent(), content.GetContent(), ClassValue, StyleValue)}</div>");
        }
    }
}
