using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ShopAroundTheCorner.Models.ViewModels;

namespace ShopAroundTheCorner.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PaginationTagHelper : TagHelper
	{
		// Will dynamically create page links
		private IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

		// gets the value of the number of pages
		public PageInfo PageModel { get; set; }
		public string PageAction { get; set; }

		// brings in different information related to styling
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper uh = uhf.GetUrlHelper(vc);

			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i <= PageModel.TotalPages; i++)
			{
                // appends the a tags with links to other pages
                TagBuilder tb = new TagBuilder("a");
                
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
				// styling with dynamic pages
				if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage
                    ? PageClassSelected : PageClassNormal);
                }
				// appends page number and makes i int a string
                tb.InnerHtml.Append(i.ToString());
				// appends the final a tag within div tag
				final.InnerHtml.AppendHtml(tb);
			}
            // final packages info to a div tag
            output.Content.AppendHtml(final.InnerHtml);
		}
    }
}

