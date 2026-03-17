// -------------------------------------------------------------------------------------------------
// <copyright file="CategoryController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.ViewModels;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Features.NorthwindConnection;
// by implementing IRenderTemplate<Category>, this becomes
// the "page template" for a Category entity
public class CategoryController : Controller, IRenderTemplate<Entities.Category>
{
    private readonly IContentLoader contentLoader;

    public CategoryController(IContentLoader contentLoader)
    {
        this.contentLoader = contentLoader;
    }

    public ActionResult Index()
    {
        // Note: the GetRoutedData extension method uses the partial router to
        // convert a URL segment into a Category instance.
        // var category = HttpContext.GetRouteData();
        // Console.WriteLine(category.ToString());
        var category = HttpContext.Items["category"] as Entities.Category;
        var categoriesPages = contentLoader.GetChildren<CategoriesPage>(ContentReference.StartPage);

        CategoriesPage currentPage = null;
        if (categoriesPages.Count() > 0)
        {
            currentPage = categoriesPages.First();
        }

        var model = PageViewModel.Create(currentPage);
        model.CurrentPage.NorthwindCategory = category;

        return View("~/Features/NorthwindConnection/Category.cshtml", model);
    }
}
