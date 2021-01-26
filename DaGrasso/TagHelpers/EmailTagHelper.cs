using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DaGrasso.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailAdress { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + EmailAdress);
            output.Content.SetContent(Content);
        }
    }
}
