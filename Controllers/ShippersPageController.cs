// -------------------------------------------------------------------------------------------------
// <copyright file="ShippersPageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class ShippersPageController : PageControllerBase<ShippersPage>
    {
        public ShippersPageController(IContentLoader loader) : base(loader)
        {
        }

        public ActionResult Index(ShippersPage currentPage)
        {
            var model = new ShippersPageViewModel(currentPage)
            {
                Shippers = _loader.GetChildren<ShipperPage>(currentPage.ContentLink)
            };
            return View(model);
        }
    }
}
