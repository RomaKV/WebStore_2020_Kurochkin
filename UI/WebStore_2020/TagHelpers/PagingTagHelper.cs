﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.WebStore.DomainNew.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UI.WebStore.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public PagingTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext, HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }

        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
          = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = this.urlHelperFactory.GetUrlHelper(ViewContext);
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");
            for (var i = 1; i <= PageModel.TotalPages; i++)
            {
                var item = CreateTag(i, urlHelper);
                ulTag.InnerHtml.AppendHtml(item);

            }
            
            base.Process(context, output);
            output.Content.AppendHtml(ulTag);

        }

        private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            var li = new TagBuilder("li");
            var a = new TagBuilder("a");
            if (pageNumber == PageModel.PageNumber)
            {
                a.MergeAttribute("data-page", PageModel.PageNumber.ToString());
                li.AddCssClass("active");

            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                a.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                foreach (var (key, value) in PageUrlValues.Where(
                    p=>p.Value != null))

                {
                    a.MergeAttribute($"data-{key}", value.ToString());
                }
            }

            a.InnerHtml.AppendHtml(pageNumber.ToString());
            li.InnerHtml.AppendHtml(a);
            return li;

        }
    }

}
