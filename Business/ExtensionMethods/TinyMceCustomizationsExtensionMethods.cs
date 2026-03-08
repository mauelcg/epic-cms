using EPiServer.Cms.TinyMce.Core;

namespace AlloyTraining.Business.ExtensionMethods;

public static class TinyMceCustomizationExtensionsMethods
{
    public static IServiceCollection AddTinyMceCustomizations(this IServiceCollection services)
    {
        return services.Configure<TinyMceConfiguration>(config =>
        {
            // customizations
            TinyMceSettings defaultSettings = config.Default();
            defaultSettings.AppendToolbar("styleselect");
            // defaultSettings.ContentCss("/css/site.css");
            // defaultSettings.ContentCss("styleselect");
            // defaultSettings.Toolbar(
            //     // first row, first string
            //     "formatselect | bold italic strikethrough | alignleft aligncenter alignright alignjustify | removeformat",
            //     // second row, second string
            //     "epi-link image epi-image-editor epi-personalized-content | bullist numlist outdent indent | searchreplace fullscreen"
            // );
            // // defaultSettings.AppendToolbar("styleselect");
            // defaultSettings.AppendToolbar("paste");
            // defaultSettings.AddPlugin("code").AppendToolbar("code").AddSetting("code_dialog_height", 400).AddSetting("code_dialog_width", 100);
            // defaultSettings.AddSetting("entity_encoding", "numeric");
            defaultSettings.AddPlugin("table").AppendToolbar("table");
            defaultSettings.AddSetting("table_toolbar", "tabledelete | tableinsertrowbefore tableinsertrowafter tabledeleterow | tableinsertcolbefore tableinsertcolafter tabledeletecol");
            // defaultSettings.AddSetting("table_appearance_options", false);
            defaultSettings.AddSetting("table_row_advtab", false);
            defaultSettings.AddSetting("table_row_advtab", false);
            defaultSettings.AddSetting("table_default_attributes", new
            {
                border = 3
            });

            // TinyMceSettings mainBodyStandardPageSettings = config.For<StandardPage>(page => page.MainBody);

            // mainBodyStandardPageSettings.Toolbar("bold");
            // mainBodyStandardPageSettings.BlockFormats("Normal=p;Main Header=h1;Subheader=h2;Monospace=pre");
        });
    }
}
