using AlloyTraining.Models.Pages;

namespace AlloyTraining.Models.ViewModels;

/// <summary>
/// Defines common characteristics for view models for pages, including properties used by layout files.
/// </summary>
/// <remarks>
/// Views which should handle several page types (T) can use this interface as model type rather than the
/// concrete PageViewModel class, utilizing the that this interface is covariant.
/// </remarks>
public interface IPageViewmodel<out T> where T : SitePageData
{
    T CurrentPage { get; }
    StartPage StartPage { get; }
    LayoutModel Layout { get; set; }
    IEnumerable<SitePageData> MenuPages { get; }
    IContent Section { get; }
}
