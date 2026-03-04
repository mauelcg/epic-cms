using System.ComponentModel.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        DisplayName = "All Properties",
        GroupName = "Specialized", Order = 10,
        Description = "Homepage for the site")]
    public class AllPropertyTypesPage : PageData
    {
        [Display(GroupName = "Simple Types")]
        public virtual string SmallString { get; set; }
        [Display(GroupName = "Simple Types")]
        [UIHint(UIHint.Textarea)]
        public virtual string LargeString { get; set; }
        [Display(GroupName = "Simple Types")]
        [EmailAddress]
        public virtual string EmailString { get; set; }
        [Display(GroupName = "Simple Types")]
        [StringLength(40, MinimumLength = 5)]
        public virtual string FiveToFourtyChars { get; set; }
        [Display(GroupName = "Simple Types")]
        [RegularExpression("[A-E]{5}")]
        public virtual string RegExString { get; set; }
        [Display(GroupName = "Simple Types")]
        public virtual bool Boolean { get; set; }
        [Display(GroupName = "Simple Types")]
        public virtual DateTime? DateTime { get; set; }
        [Display(GroupName = "Simple Types")]
        public virtual int? WholeNumber { get; set; }
        [Display(GroupName = "Simple Types")]
        public virtual double? RealNumber { get; set; }
        [Display(GroupName = "CMS Types")]
        public virtual XhtmlString RichText { get; set; }
        [Display(GroupName = "CMS Types")]
        [CultureSpecific]
        public virtual Url SingleLink { get; set; }
        [Display(GroupName = "CMS Types")]
        [UIHint(UIHint.Image)]
        public virtual Url SingleLinkToImage { get; set; }
        [Display(GroupName = "CMS Types")]
        public virtual LinkItemCollection MultipleLinks { get; set; }
        [Display(GroupName = "CMS Types")]
        [UIHint(UIHint.Image)]
        public virtual LinkItemCollection MultipleLinksToImages { get; set; }
        [Display(GroupName = "CMS Types")]
        public virtual CategoryList ExtraCategories { get; set; }
        [Display(GroupName = "CMS Types")]
        public virtual PageType PreferredPageType { get; set; }
        [Display(GroupName = "Content Reference Types")]
        public virtual ContentReference SingleContentReference { get; set; }
        [Display(GroupName = "Content Reference Types")]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SingleContentReferenceToImage { get; set; }
        [Display(GroupName = "Content Reference Types")]
        public virtual PageReference SinglePageReference { get; set; }
        [Display(GroupName = "Content Reference Types")]
        public virtual ContentArea ContentAreaForAnyType { get; set; }
        [Display(GroupName = "Content Reference Types")]
        [UIHint(UIHint.Image)]
        [AllowedTypes(AllowedTypes = new[] { typeof(ImageData) })]
        public virtual ContentArea ContentAreaForImages { get; set; }
        [Display(GroupName = "Content Reference Types")]
        [AllowedTypes(typeof(BlockData))]
        public virtual ContentArea ContentAreaForBlocks { get; set; }
        [Display(GroupName = "Content Reference Types")]
        [AllowedTypes(typeof(PageData))]
        public virtual ContentArea ContentAreaForPages { get; set; }
        [Display(GroupName = "Content Reference Types")]
        public virtual IList<ContentReference> ListOfContentReferences { get; set; }
    }
}
