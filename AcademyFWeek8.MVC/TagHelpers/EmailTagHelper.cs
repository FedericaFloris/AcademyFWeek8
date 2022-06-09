using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AcademyFWeek8.MVC.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        //<a class ="btn btn-primary" href=mailto:pippo@mail.it>Mandami una mail</a>
        public string ToUser { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Content.SetContent("Mandami una e-mail");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");
        }
    }
}
