using System.ComponentModel.DataAnnotations;
using AlloyTraining.Models.Pages;

namespace AlloyTraining.Models.ViewModels
{
    public class LoginViewModel : IPageViewmodel<LoginPage>
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public LoginPage CurrentPage { get; set; }

        public StartPage StartPage { get; }

        public LayoutModel Layout { get; set; }

        public IEnumerable<SitePageData> MenuPages { get; set; }

        public IContent Section { get; set; }
    }
}
