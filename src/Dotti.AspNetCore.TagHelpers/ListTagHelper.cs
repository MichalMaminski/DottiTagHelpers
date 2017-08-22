using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Dotti.AspNetCore.TagHelpers
{
    [HtmlTargetElement(tag: OrderedListElement, Attributes = ItemsAttributeName)]
    [HtmlTargetElement(tag: UnorderedListElement, Attributes = ItemsAttributeName)]
    public class ListTagHelper : TagHelper
    {
        private const string OrderedListElement = "ol";
        private const string UnorderedListElement = "ul";
        private const string ItemsAttributeName = "asp-items";
        
        [HtmlAttributeName(ItemsAttributeName)]
        public IEnumerable<object> Items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            
            RenderItems(output);
        }

        private void RenderItems(TagHelperOutput output)
        {
            foreach (var item in Items)
            {
                output.Content.AppendFormat($"<li>{item}</li>");
            }
        }
    }
}
