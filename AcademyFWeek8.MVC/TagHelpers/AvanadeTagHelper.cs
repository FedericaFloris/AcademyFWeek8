using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AcademyFWeek8.MVC.TagHelpers
{
    public class AvanadeTagHelper : TagHelper
    {
        public string TestoBottone { get; set; }
        public string Sito { get; set; }
        public string LinguaSito { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Content.SetContent(TestoBottone);
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("rel", "alternate");
            output.Attributes.SetAttribute("href", Sito);
            output.Attributes.SetAttribute("hreflang", LinguaSito);
        }
    }
}
