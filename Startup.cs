using AlloyTraining.Business.ExtensionMethods;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.Cms.DependencyInjection;
using EPiServer.Labs.GridView;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace AlloyTraining;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        // Configure automatic redirection from friend URLs to simple addresses
        services.Configure<RoutingOptions>(options =>
        {
            options.PreferredUrlFormat = PreferredUrlFormat.Simple;
            options.PreferredUrlFormatRedirection = HttpRedirect.Permanent; // Can be None, Temporary, and Permanent
        });

        // Replace the default ContentMediaResolver with site created type
        services.AddSingleton<ContentMediaResolver, CustomPdfContentMediaResolver>();
        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddFind() // Enable Search and Navigation
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>()
            .AddGridView(options =>
            {
                options.IsViewEnabled = true;
            })
            .AddTinyMceCustomizations();

            services.AddContentDeliveryApi(options =>
            {
                options.SiteDefinitionApiEnabled = true;
            }).WithFriendlyUrl();

            services.AddContentSearchApi(options =>
            {
                options.MaximumSearchResults = 10;
            });

            // services.AddContentDeliveryApi(options =>
            // {
            //     options.EnableCors = true;
            // });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        // Required for Content Search API
        app.UseCors();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
