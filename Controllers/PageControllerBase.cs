using AlloyTraining.Models.Pages;
using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.ViewModels;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;


namespace AlloyTraining.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        protected readonly Injected<UISignInManager> UISignInManager;
        protected readonly IContentLoader loader;

        public PageControllerBase(IContentLoader loader)
        {
            this.loader = loader;
        }

        public async Task<IActionResult> Logout()
        {
            await UISignInManager.Service.SignOutAsync();
            return RedirectToAction("Index");
        }

        protected IPageViewmodel<TPage> CreatePageViewModel<TPage>(TPage currentPage) where TPage : SitePageData
        {
            var viewModel = PageViewModel.Create(currentPage);

            viewModel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewModel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage)).Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewModel.Section = currentPage.ContentLink.GetSection();

            return viewModel;
        }
    }
}
