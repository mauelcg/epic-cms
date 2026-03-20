// -------------------------------------------------------------------------------------------------
// <copyright file="FAQListPageController.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    public class FAQListPageController : PageController<FAQListPage>
    {
        private readonly IContentRepository _repo;

        public FAQListPageController(IContentRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index(FAQListPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            var faqs = _repo.GetChildren<FAQItemPage>(currentPage.ContentLink);
            model.CurrentPage.FAQItems = faqs;
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateFAQItem(FAQListPage currentPage, string question)
        {
            var faqItem = _repo.GetDefault<FAQItemPage>(currentPage.ContentLink);

            // If someone is logged in then CreatedBy and ChangedBy will be set, otherwise they will be empty string which is shown as "Installer"
            if (string.IsNullOrEmpty(faqItem.CreatedBy))
            {
                faqItem.CreatedBy = "Anonymous";
            }

            if (string.IsNullOrEmpty(faqItem.ChangedBy))
            {
                faqItem.ChangedBy = "Anonymous";
            }

            faqItem.Question = new XhtmlString(question);
            faqItem.Name = "Q. " + question;
            _repo.Save(faqItem, EPiServer.DataAccess.SaveAction.CheckOut, EPiServer.Security.AccessLevel.Read);

            return RedirectToAction("Index");
        }
    }
}
