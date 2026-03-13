using Microsoft.AspNetCore.Identity;
using AlloyTraining.Models.ViewModels;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.AspNetCore.Mvc;
using AlloyTraining.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer.AddOns.Helpers;
using AlloyTraining.Controllers;
using EPiServer.Find.Helpers;

namespace AlloyTraining.Features.Authentication
{
    public class AuthenticationController : PageControllerBase<AuthenticationPage>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(IContentLoader contentLoader, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : base(contentLoader)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet("/auth")]
        public ActionResult Index(AuthenticationPage currentPage)
        {
            if (User.Identity.IsAuthenticated)
            {
                var current = _pageRouteHelper.Service.Page;
                return Redirect("/");
            }
            else
            {
                return Redirect("/auth/login");
            }
        }

        [HttpGet("/auth/login")]
        public ActionResult Login()
        {
            return View("~/Features/Authentication/Login.cshtml");
        }

        [HttpPost("/auth/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);

            Console.WriteLine("Success");

            if (result.Succeeded)
                return Redirect("/");

            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }

        [HttpGet("/auth/register")]
        public ActionResult Register()
        {
            return View("~/Features/Authentication/Register.cshtml");
        }

        [HttpPost("/auth/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Redirect("/auth/login");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
    }
}

