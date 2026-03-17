// -------------------------------------------------------------------------------------------------
// <copyright file="ShippersPage.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace AlloyTraining.Models.Pages;

[ContentType(DisplayName = "Shippers", Description = "Displays a list of imported shippers.")]
[SiteImageUrl]
[AvailableContentTypes(Availability = Availability.Specific, Include = new[] { typeof(ShipperPage) }, IncludeOn = new[] { typeof(StartPage) })]
public class ShippersPage : SitePageData
{
    public virtual int DefaultShipper { get; set; }
}
