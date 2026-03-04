using System.ComponentModel.DataAnnotations;
using EPiServer.Security;

namespace AlloyTraining;

[GroupDefinitions] // show on CMS / Admin / Config / Edit Tabs
public static class SiteTabNames
{
    [Display(Order =10)] // to sort tabs
    [RequiredAccess(AccessLevel.Publish)] // to restrict this tab
    public const string Contact = "Contact Info";


    [Display(Order =10)] //
    [RequiredAccess(AccessLevel.Publish)]
    public const string About = "About";

    [Display(Order =10)] //
    [RequiredAccess(AccessLevel.Publish)]
    public const string SEO = "Search Engine Optimization";
}
