using AlloyTraining.Models.Pages;
using AlloyTraining.Business.ExtensionMethods;
using AlloyTraining.Models.ViewModels;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Security;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using EPiServer.Web.Routing;
using EPiServer.AddOns.Helpers;


namespace AlloyTraining.Controllers
{
    public abstract class PageControllerBase<T> : PageController<T> where T : SitePageData
    {
        protected readonly Injected<UISignInManager> _UISignInManager;
        protected readonly Injected<IPageRouteHelper> _pageRouteHelper;
        protected readonly IContentLoader _loader;

        public PageControllerBase(IContentLoader loader)
        {
            _loader = loader;
        }

        public async Task<IActionResult> Logout()
        {
            await _UISignInManager.Service.SignOutAsync();

            var currentPage = _pageRouteHelper.Service.Page;

            return Redirect(currentPage.ContentLink.GetPublicUrl());
        }

        protected IPageViewmodel<TPage> CreatePageViewModel<TPage>(TPage currentPage) where TPage : SitePageData
        {
            var viewModel = PageViewModel.Create(currentPage);

            viewModel.StartPage = _loader.Get<StartPage>(ContentReference.StartPage);

            viewModel.MenuPages = FilterForVisitor.Filter(_loader.GetChildren<SitePageData>(ContentReference.StartPage)).Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewModel.Section = currentPage.ContentLink.GetSection();

            return viewModel;
        }
    }
}
