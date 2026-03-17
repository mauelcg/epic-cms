using Microsoft.AspNetCore.Identity;
using EPiServer.Cms.UI.AspNetIdentity;
using Microsoft.AspNetCore.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Controllers;
using EPiServer.Shell.Security;

namespace AlloyTraining.Features.Authentication
{
    public class AuthenticationController : PageControllerBase<AuthenticationPage>
    {
        private readonly UIUserProvider _uiUserProvider;
        private readonly UIRoleProvider _uiRoleProvider;
        private readonly UISignInManager _uiSignInManager;

        public AuthenticationController(IContentLoader contentLoader, UIUserProvider uiUserProvider, UISignInManager uISignInManager, UIRoleProvider uIRoleProvider) : base(contentLoader)
        {
            _uiUserProvider = uiUserProvider;
            _uiSignInManager = uISignInManager;
            _uiRoleProvider = uIRoleProvider;
        }

        [HttpGet("/auth")]
        public ActionResult Index()
        {
            return User.Identity.IsAuthenticated ? Redirect("/") : Redirect("/auth/login");
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
            {
                return View("~/Features/Authentication/Login.cshtml", model);
            }

            var success = await _uiSignInManager.SignInAsync(model.Username, model.Password);

            if (success)
            {
                return Redirect("/");
            }

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
            if (!ModelState.IsValid)
            {
                return View("~/Features/Authentication/Register.cshtml", model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                // Map extra profile fields if your ApplicationUser exposes them:
                // FirstName = model.FirstName,
                // LastName  = model.LastName,
            };

            var result = await _uiUserProvider.CreateUserAsync(user.UserName, model.Password, user.Email, null, null, false);

            if (result.Status == UIUserCreateStatus.Success)
            {
                // Optionally assign a role
                await _uiRoleProvider.AddUserToRolesAsync(result.User.Username, new[] { "WebEditors" });
                return Redirect("/auth/login");
            }

            // Map UIUserCreateStatus errors back to ModelState
            ModelState.AddModelError("", result.Status switch
            {
                UIUserCreateStatus.DuplicateUserName => "Username already exists.",
                UIUserCreateStatus.DuplicateEmail => "Email already registered.",
                UIUserCreateStatus.InvalidPassword => "Password does not meet requirements.",
                UIUserCreateStatus.InvalidUserName => "Username is invalid.",
                _ => "Registration failed. Please try again."
            });

            return View("~/Features/Authentication/Register.cshtml", model);
        }
    }
}
