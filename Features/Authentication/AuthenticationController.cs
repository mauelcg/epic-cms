using Microsoft.AspNetCore.Identity;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.AspNetCore.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Controllers;

namespace AlloyTraining.Features.Authentication
{
    public class AuthenticationController : PageControllerBase<AuthenticationPage>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(
            IContentLoader contentLoader,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager) : base(contentLoader)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("/auth")]
        public ActionResult Index(AuthenticationPage currentPage)
        {
            return User.Identity.IsAuthenticated
                ? Redirect("/")
                : Redirect("/auth/login");
        }

        [HttpGet("/auth/login")]
        public ActionResult Login()
        {
            return View("~/Features/Authentication/Login.cshtml");
        }

        [HttpPost("/auth/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Username, model.Password, false, false);

            if (result.Succeeded)
                return Redirect("/");

            ModelState.AddModelError("", "Invalid username or password.");
            return View("~/Features/Authentication/Login.cshtml", model);
        }

        [HttpGet("/auth/register")]
        public ActionResult Register()
        {
            return View("~/Features/Authentication/Register.cshtml");
        }

        [HttpPost("/auth/register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // 1. Check model annotations first
            if (!ModelState.IsValid)
                return View("~/Features/Authentication/Register.cshtml", model);

            // 2. Build the ApplicationUser
            var user = new ApplicationUser
            {
                UserName  = model.Username,
                Email     = model.Email,
                // Map extra profile fields if your ApplicationUser exposes them:
                // FirstName = model.FirstName,
                // LastName  = model.LastName,
            };

            // 3. Create user via Identity (hashes password, runs validators)
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Redirect("/auth/login");

            // 4. Surface Identity errors (duplicate username, weak password, etc.)
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
    }
}
