using AlloyTraining.Models.Pages;

namespace AlloyTraining.Models.ViewModels;

public interface IPageViewmodel<out T> where T : SitePageData
{
    T CurrentPage { get; }
    StartPage StartPage { get; }
    IEnumerable<SitePageData> MenuPages { get; }
    IContent Section { get; }
}
