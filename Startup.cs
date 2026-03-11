using AlloyTraining.Features.NorthwindPartialRouter;
using AlloyTraining.Features.NorthwindPartialRouter.Entities;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Core.Routing;
using EPiServer.Labs.GridView;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.EntityFrameworkCore;

namespace AlloyTraining;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\shared\episerver-cms");
        _webHostingEnvironment = webHostingEnvironment;
        _configuration = configuration;
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
        // For partial routing
        services.AddSingleton<IPartialRouter, CategoryPartialRouter>();
        services.AddHttpContextAccessor();
        // For EPiServer CMS
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
            .AddDbContext<NorthwindContext>(options =>
            {
                options.UseLazyLoadingProxies(false);
                options.UseSqlServer(
                    _configuration.GetConnectionString("NorthwindDB"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure()
                );
            });

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
