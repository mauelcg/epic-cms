public class CustomPdfContentMediaResolver : ContentMediaResolver
{
    // Override the method that finds the first matching type for an extension
    public override Type GetFirstMatching(string extension)
    {
        var type = base.GetFirstMatching(extension);

        if(extension.Equals("pdf", StringComparison.OrdinalIgnoreCase) && type != null && type.FullName.StartsWith("EPiServer.PdfPreview"))
        // if(extension.Equals("pdf", StringComparison.OrdinalIgnoreCase))
        {
            // Return the custom PDF type instead of the default one
            // By returning null in the filter, you signal to the CMS that it should continue searching for a matching type. It will then find your custom class that is decorated with [MediaDescriptor(ExtensionString = "pdf")].
            return null;
        }

        return type;
    }
}
