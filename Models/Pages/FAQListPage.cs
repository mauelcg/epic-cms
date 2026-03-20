// -------------------------------------------------------------------------------------------------
// <copyright file="FAQListPage.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "FAQ List", GroupName = SiteGroupNames.Specialized, Description = "Use this page for a list of FAQs entered by visitors, answered by editors")]
    [SiteImageUrl]
    [AvailableContentTypes(Include = new[] { typeof(FAQItemPage) }, IncludeOn = new[] { typeof(StartPage) })]
    public class FAQListPage : SitePageData
    {
        // Having an ignored property avoids needing a view model this property will not be stored in CMS so it does need to be virtual
        [Ignore]
        public IEnumerable<FAQItemPage> FAQItems { get; set; }
    }
}
