using AlloyTraining.Models.Pages;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class AllPropertyTypesPageController : PageController<AllPropertyTypesPage>
    {
        public ActionResult Index(AllPropertyTypesPage currentPage)
        {
            // Implementation of action. You can create your own view model class that you pass to the view or
            // you can pass the page type model directly for simpler templates

            return View(currentPage);
        }
    }
}

