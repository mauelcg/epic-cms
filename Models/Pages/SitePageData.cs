using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace AlloyTraining.Models.Pages;

public abstract class SitePageData : PageData
{
    [CultureSpecific]
    [Display(Name = "Meta title", GroupName = SiteTabNames.SEO, Order = 100)]
    [StringLength(60, MinimumLength = 5)]
    public virtual string MetaTitle { get; set; }

    [CultureSpecific]
    [Display(Name = "Meta keywords", GroupName = SiteTabNames.SEO, Order = 200)]
    public virtual string MetaKeywords { get; set; }

    [CultureSpecific]
    [Display(Name = "Meta description", GroupName = SiteTabNames.SEO, Order = 300)]
    [UIHint(UIHint.Textarea)]
    public virtual string MetaDescription { get; set; }

    [Display(Name = "Page image", GroupName = SystemTabNames.Content, Order = 100)]
    [UIHint(UIHint.Image)]
    public virtual ContentReference PageImage { get; set; }
}
