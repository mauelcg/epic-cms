// -------------------------------------------------------------------------------------------------
// <copyright file="SiteTabNames.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using EPiServer.Security;

namespace AlloyTraining;

[GroupDefinitions] // show on CMS / Admin / Config / Edit Tabs
public static class SiteTabNames
{
    [Display(Order = 10)] // to sort tabs
    [RequiredAccess(AccessLevel.Publish)] // to restrict this tab
    public const string Contact = "Contact Info";

    [Display(Order = 10)]
    [RequiredAccess(AccessLevel.Publish)]
    public const string About = "About";

    [Display(Order = 10)]
    [RequiredAccess(AccessLevel.Administer)]
    public const string SiteSettings = "Site Settings";

    [Display(Order = 10)]
    [RequiredAccess(AccessLevel.Edit)]
    public const string SEO = "SEO";
}
