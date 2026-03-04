using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Media;

[ContentType(DisplayName = "Portable Document Format", Description = "Use this to upload Portable Document Format (PDF) files.")]
[MediaDescriptor(ExtensionString = "pdf")]
public class PdfFile : MediaData
{
    [Display(Name = "Render preview image")]
    public virtual bool RenderPreviewImage { get; set; }
}
