// -------------------------------------------------------------------------------------------------
// <copyright file="VideoFile.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType]
    [MediaDescriptor(ExtensionString = "mpg,mpeg")]
    public class VideoFile : VideoData
    {
        // You can add custom properties here if needed
    }
}
