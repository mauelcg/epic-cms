// -------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperExtensions.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.Text;
using System.Text.Encodings.Web;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlloyTraining.Business.ExtensionMethods
{
    public static class HtmlHelpers
    {
        public static IHtmlContent MenuList(
            this IHtmlHelper helper,
            ContentReference rootLink,
            Func<MenuItem, HelperResult> itemTemplate = null,
            bool includeRoot = false,
            bool requireVisibleInMenu = true,
            bool requirePageTemplate = true)
        {
            itemTemplate ??= GetDefaultItemTemplate(helper);
            var currentContentLink = helper.ViewContext.HttpContext.GetContentLink();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            static IEnumerable<PageData> Filter(IEnumerable<PageData> pages)
            {
                return FilterForVisitor.Filter(pages).Cast<PageData>();
            }

            var pagePath = contentLoader.GetAncestors(currentContentLink)
                .Reverse()
                .Select(x => x.ContentLink)
                .SkipWhile(x => !x.CompareToIgnoreWorkID(rootLink))
                .ToList();

            var menuItems = FilterForVisitor.Filter(contentLoader.GetChildren<PageData>(rootLink)).Cast<PageData>()
                .Select(x => CreateMenuItem(x, currentContentLink, pagePath, contentLoader, Filter))
                .ToList();

            if (includeRoot)
            {
                menuItems.Insert(0, CreateMenuItem(contentLoader.Get<PageData>(rootLink), currentContentLink, pagePath, contentLoader, Filter));
            }

            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);
            foreach (var menuItem in menuItems)
            {
                itemTemplate(menuItem).WriteTo(writer, HtmlEncoder.Default);
            }

            return new HtmlString(buffer.ToString());
        }

        private static MenuItem CreateMenuItem(PageData page, ContentReference currentContentLink, List<ContentReference> pagePath, IContentLoader contentLoader, Func<IEnumerable<PageData>, IEnumerable<PageData>> filter)
        {
            var menuItem = new MenuItem(page)
            {
                Selected = page.ContentLink.CompareToIgnoreWorkID(currentContentLink) ||
                           pagePath.Contains(page.ContentLink),

                HasChildren = new Lazy<bool>(() => filter(contentLoader.GetChildren<PageData>(page.ContentLink)).Any())
            };

            return menuItem;
        }

        private static Func<MenuItem, HelperResult> GetDefaultItemTemplate(IHtmlHelper helper) => x => new HelperResult(writer =>
                                                                                                           {
                                                                                                               helper.PageLink(x.Page).WriteTo(writer, HtmlEncoder.Default);
                                                                                                               return Task.CompletedTask;
                                                                                                           });

        public class MenuItem
        {
            public MenuItem(PageData page)
            {
                Page = page;
            }

            public PageData Page { get; set; }

            public bool Selected { get; set; }

            public Lazy<bool> HasChildren { get; set; }
        }

        public static ConditionalLink BeginConditionalLink(this IHtmlHelper helper, bool shouldWriteLink, string url, string title = null, string cssClass = null)
        {
            if (shouldWriteLink)
            {
                var linkTag = new TagBuilder("a");
                linkTag.Attributes.Add("href", url);

                if (!string.IsNullOrWhiteSpace(title))
                {
                    linkTag.Attributes.Add("title", title);
                }

                if (!string.IsNullOrWhiteSpace(cssClass))
                {
                    linkTag.Attributes.Add("class", cssClass);
                }

                helper.ViewContext.Writer.Write(linkTag.RenderStartTag());
            }

            return new ConditionalLink(helper.ViewContext, shouldWriteLink);
        }

        public static ConditionalLink BeginConditionalLink(this IHtmlHelper helper, bool shouldWriteLink, Func<string> urlGetter, string title = null, string cssClass = null)
        {
            var url = string.Empty;

            if (shouldWriteLink)
            {
                url = urlGetter();
            }

            return helper.BeginConditionalLink(shouldWriteLink, url, title, cssClass);
        }

        public class ConditionalLink : IDisposable
        {
            private readonly ViewContext _viewContext;
            private readonly bool _linked;
            private bool _disposed;

            public ConditionalLink(ViewContext viewContext, bool isLinked)
            {
                _viewContext = viewContext;
                _linked = isLinked;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                {
                    return;
                }

                _disposed = true;

                if (_linked)
                {
                    _viewContext.Writer.Write("</a>");
                }
            }
        }
    }
}
