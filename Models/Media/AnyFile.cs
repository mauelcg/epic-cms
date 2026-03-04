using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Any file", GUID = "6d96977e-cdec-44a6-9e34-9d617a9c85f9", Description = "Use this to upload any type of file.")]
    public class AnyFile : MediaData
    {
    }
}
