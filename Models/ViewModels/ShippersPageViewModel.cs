// -------------------------------------------------------------------------------------------------
// <copyright file="ShippersPageViewModel.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;

namespace AlloyTraining.Models.ViewModels;

public class ShippersPageViewModel : IPageViewmodel<ShippersPage>
{
    public ShippersPageViewModel(ShippersPage currentPage)
    {
        CurrentPage = currentPage;
    }

    public ShippersPage CurrentPage { get; set; }
    public LayoutModel Layout { get; set; }
    public IContent Section { get; set; }
    public IEnumerable<ShipperPage> Shippers { get; set; }
    StartPage IPageViewmodel<ShippersPage>.StartPage => throw new NotImplementedException();
    IEnumerable<SitePageData> IPageViewmodel<ShippersPage>.MenuPages => throw new NotImplementedException();
}
