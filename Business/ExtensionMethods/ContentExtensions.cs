using EPiServer.ServiceLocation;

namespace AlloyTraining.Business.ExtensionMethods;

public static class ContentExtensions
{
    public static TContent Get<TContent>(this ContentReference contentLink) where TContent : IContent
    {
        var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
        return loader.Get<TContent>(contentLink);
    }
}
