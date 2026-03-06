using AlloyTraining.Models.Pages;
using EPiServer.Cms.Shell.UI.Rest.Models.Internal;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class StartPageController : PageControllerBase<StartPage>
    {
        public StartPageController(IContentLoader loader) : base(loader)
        {}
        public ActionResult Index(StartPage currentPage)
        {
            // Implementation of action. You can create your own view model class that you pass to the view or
            // you can pass the page type model directly for simpler templates

            return View(CreatePageViewModel(currentPage));
        }
    }
}

