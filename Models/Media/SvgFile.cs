using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "SVG file", GUID = "d9c8e1b0-5a3c-4f1e-9c7a-2b6f8e9a1c2e", Description = "Use this to upload Scalable Vector Graphics (SVG)")]
    [MediaDescriptor(ExtensionString = "svg")]
    public class SvgFile : ImageData
    {
        public override Blob Thumbnail { get => base.BinaryData; }
    }
}
