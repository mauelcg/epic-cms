// -------------------------------------------------------------------------------------------------
// <copyright file="NewsPageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;

namespace AlloyTraining.Controllers;

[TemplateDescriptor(Inherited = true, Tags = new[] { RenderingTags.Mobile }, AvailableWithoutTag = false, Name = "News Page (Normal)", ModelType = typeof(NewsPage), Path = "/Views/NewsPage/Index.cshtml", Description = "This is the page template for a News page.")]
public class NewsPageController : PageController<NewsPage>
{
}
