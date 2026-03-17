// -------------------------------------------------------------------------------------------------
// <copyright file="SectionExtensions.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using EPiServer.ServiceLocation;

namespace AlloyTraining.Business.ExtensionMethods;

public static class SectionExtensions
{
    public static IContent GetSection(this ContentReference contentLink)
    {
        var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
        var currentContent = loader.Get<IContent>(contentLink);
        if (currentContent.ParentLink != null && currentContent.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
        {
            return currentContent;
        }

        return loader.GetAncestors(contentLink)
                      .OfType<PageData>()
                      .SkipWhile(x => x.ParentLink == null || !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                      .FirstOrDefault();
    }
}
