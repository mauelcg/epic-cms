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
