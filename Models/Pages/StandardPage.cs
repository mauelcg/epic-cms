using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        DisplayName = "Standard",
        GroupName = "Specialized", Order = 10,
        Description = "Standard")]
    public class StandardPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }
    }
}
