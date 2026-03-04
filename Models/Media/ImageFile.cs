using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Image file", GUID = "d9c8e1b0-5a3c-4f1e-9c7a-2b6f8e9a1c2d", Description = "Use this to upload image files.")]
    [MediaDescriptor(ExtensionString = "png,gif,jpeg,jpg")]
    public class ImageFile : ImageData
    {
        [CultureSpecific]
        [Editable(true)]
        public virtual string Description { get; set; }
        // [Display(Name = "Copyright", Description = "Enter the copyright information for this image.")]
        // public virtual string Copyright { get; set; }
    }
}
