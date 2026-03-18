// -------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Mark Lemuel Genita">
// Copyright (c) Mark Lemuel Genita. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------------------------

using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Labs.GridView;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace AlloyTraining;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;
    private readonly IConfiguration _configuration;

    public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
    {
        _webHostingEnvironment = webHostingEnvironment;
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(@"D:\shared\episerver-cms", "App_Data"));
            // AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        // Configure automatic redirection from friend URLs to simple addresses
        services.Configure<RoutingOptions>(options =>
        {
            options.PreferredUrlFormat = PreferredUrlFormat.Simple;
            options.PreferredUrlFormatRedirection = HttpRedirect.Permanent; // Can be None, Temporary, and Permanent
        });

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>()
            .AddGridView(options =>
            {
                options.IsViewEnabled = true;
            });

        services.AddContentDeliveryApi(options =>
        {
            options.SiteDefinitionApiEnabled = true;
        }).WithFriendlyUrl();

        services.AddContentSearchApi(options =>
        {
            options.MaximumSearchResults = 10;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

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
