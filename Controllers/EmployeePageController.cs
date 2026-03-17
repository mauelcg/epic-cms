// -------------------------------------------------------------------------------------------------
// <copyright file="EmployeePageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class EmployeePageController : PageController<EmployeePage>
    {
        public Injected<IContentLoader> InjectedLoader;
        protected readonly IContentLoader loader = null; // Best for unit tests via parameter injection

        public EmployeePageController(IContentLoader contentLoader)
        {
            loader = contentLoader;
        }

        public void GetInfo()
        {
            var pages = InjectedLoader.Service.GetChildren<EmployeePage>(ContentReference.StartPage);
            Console.WriteLine(pages.Count());
        }

        public void GetInfoUsingLoader()
        {
            var pages = loader.GetChildren<PageData>(ContentReference.StartPage);
            Console.WriteLine(pages.Count());
        }

        public ActionResult Index(EmployeePage currentPage) =>

            // Implementation of action. You can create your own view model class that you pass to the view or
            // you can pass the page type model directly for simpler templates

            View(currentPage);
    }
}
