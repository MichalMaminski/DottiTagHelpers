using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Dotti.AspNetCore.TagHelpers
{
    [HtmlTargetElement(tag: "list", Attributes = RequiredListAttributes)]
    public class ListTagHelper : TagHelper
    {
        private const string RequiredListAttributes = "asp-items, asp-list-type";
        private const string ItemsAttributeName = "asp-items";
        private const string ListTypeAttributeName = "asp-list-type";

        [HtmlAttributeName(ListTypeAttributeName)]
        public ListTag ListType { get; set; }

        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<object> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            UpdateTagName(output);

            RenderItems(output);
        }

        private void RenderItems(TagHelperOutput output)
        {
            foreach (var item in Items)
            {
                output.Content.AppendFormat($"<li>{item}</li>");
            }
        }

        private void UpdateTagName(TagHelperOutput output)
        {
            output.TagName = ListType == ListTag.Ordered ? "ol" : "ul";
        }
    }
}
