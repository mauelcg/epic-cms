// -------------------------------------------------------------------------------------------------
// <copyright file="StartPage.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using AlloyTraining.Business.Factories;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        DisplayName = "Start",
        GUID = "F56BEFD6-9B80-49E6-8145-6B340CEBA28C",
        GroupName = "Specialized", Order = 10,
        Description = "Homepage for the site")]
    [TemplateDescriptor(Name = "Start")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "If the Heading is not set, the page falls back to showing the Name.",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body uses the XHTML-editor so you can insert, for example text, images, and tables.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main content area",
            Description = "Drag and drop images, blocks, folders, and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData), typeof(ImageData), typeof(ContentFolder), typeof(MediaData), typeof(VideoData))]
        public virtual ContentArea MainContentArea { get; set; }

        [AllowedTypes(typeof(ShippersPage))]
        public virtual ContentReference Shippers { get; set; }

        [CultureSpecific]
        [Display(Name = "Footer text", Description = "The footer text will be shown at the bottom of every page.", GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string FooterText { get; set; }

        [Display(
            Name = "Date list",
            Description = "My property description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual IList<DateTime> ListOfDates { get; set; }

        [Display(
            Name = "Five integers",
            Description = "My property description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [ItemRange(1, 10)]
        [ListItems(5)]
        public virtual IList<int> MaxFiveInts { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Work status",
            Description = "My property description",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [SelectOne(SelectionFactoryType = typeof(ThemeSelectionFactory))]
        // [SelectMany()]
        public virtual string WorkStatus { get; set; }

        // Experimental
        [UIHint(UIHint.Textarea)]
        [UIHint(UIHint.PreviewableText)]
        [RegularExpression("[a-zA-Z]+")]
        [StringLength(50, MinimumLength = 5)]
        [Display(GroupName = SiteTabNames.Contact)]
        public virtual string Phone { get; set; }

        // Experimental
        [UIHint(UIHint.Textarea)]
        [UIHint(UIHint.PreviewableText)]
        [RegularExpression("[a-zA-Z]+")]
        [StringLength(50, MinimumLength = 5)]
        [Display(GroupName = SiteTabNames.About)]
        public virtual string Email { get; set; }
    }
}
