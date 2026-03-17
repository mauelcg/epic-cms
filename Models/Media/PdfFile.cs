// -------------------------------------------------------------------------------------------------
// <copyright file="PdfFile.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media;

[ContentType(DisplayName = "Portable Document Format", Description = "Use this to upload Portable Document Format (PDF) files.")]
[MediaDescriptor(ExtensionString = "pdf")]
public class PdfFile : MediaData
{
    [Display(Name = "Render preview image")]
    public virtual bool RenderPreviewImage { get; set; }
}
