// -------------------------------------------------------------------------------------------------
// <copyright file="CategoriesPageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Controllers;
using AlloyTraining.Features.NorthwindConnection.Entities;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlloyTraining.Features.NorthwindConnection;

public class CategoriesPageController : PageControllerBase<CategoriesPage>
{
    private readonly UrlResolver _urlResolver;
    private readonly NorthwindContext _db;
    public CategoriesPageController(NorthwindContext db, IContentLoader loader, UrlResolver urlResolver) : base(loader)
    {
        _urlResolver = urlResolver;
        _db = db;
    }

    public ActionResult Index(CategoriesPage currentPage)
    {
        var model = PageViewModel.Create(currentPage);

        model.CurrentPage.CategoryLinks = new Dictionary<string, string>();

        // we do not need to track changes or
        foreach (Entities.Category category in _db.Categories.AsNoTracking().ToList())
        {
            string name = category.CategoryName;

            string url = _urlResolver.GetVirtualPathForNonContent(
             partialRoutedObject: category, language: null, virtualPathArguments: null)
            .GetUrl();

            model.CurrentPage.CategoryLinks.Add(name, url);
        }

        return View("~/Features/NorthwindConnection/CategoriesPage.cshtml", model);
    }
}
