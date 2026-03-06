
using System.ComponentModel.DataAnnotations;
using AlloyTraining.Business.Factories;
using EPiServer.Shell.ObjectEditing;

namespace AlloyTraining.Models.Pages;

[ContentType(
    DisplayName = "Product",
    GroupName = SiteGroupNames.Specialized, Order = 20,
    Description = "Use this for software products that Alloy sells.")]
[SiteCommerceIcon]
public class ProductPage : StandardPage
{
    public override void SetDefaultValues(ContentType contentType)
    {
        base.SetDefaultValues(contentType);
    }

    [SelectOne(SelectionFactoryType = typeof(ThemeSelectionFactory))]
    [Display(Name = "Color theme", GroupName = SystemTabNames.Content, Order = 310)]
    public virtual string Theme { get; set; }

    [CultureSpecific]
    [Display(Name = "Unique selling points", GroupName = SystemTabNames.Content, Order = 320)]
    [Required]
    public virtual IList<string> UniqueSellingPoints { get; set; }
}
