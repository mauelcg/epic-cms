// -------------------------------------------------------------------------------------------------
// <copyright file="ProductPageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class ProductPageController : PageControllerBase<ProductPage>
    {
        public ProductPageController(IContentLoader loader) : base(loader)
        {
        }

        [ResponseCache(Duration = 1200)] // Removing duration will automatically cache this dynamic content for 2 hours
        public ActionResult Index(ProductPage currentPage) => View(CreatePageViewModel(currentPage));
    }
}
