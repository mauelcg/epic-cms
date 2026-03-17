// -------------------------------------------------------------------------------------------------
// <copyright file="IPageViewModel.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using AlloyTraining.Models.Pages;

namespace AlloyTraining.Models.ViewModels;

public interface IPageViewmodel<out T> where T : SitePageData
{
    T CurrentPage { get; }
    StartPage StartPage { get; }
    LayoutModel Layout { get; set; }
    IEnumerable<SitePageData> MenuPages { get; }
    IContent Section { get; }
}
