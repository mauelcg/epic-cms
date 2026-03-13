using EPiServer.Core.Routing;
using EPiServer.Core.Routing.Pipeline;
using AlloyTraining.Features.NorthwindConnection.Entities;
using Microsoft.EntityFrameworkCore;
using EPiServer.Web.Routing;

namespace AlloyTraining.Features.NorthwindConnection
{
    public class CategoryPartialRouter : IPartialRouter<CategoriesPage, Entities.Category>
    {
        private readonly IContentLoader _contentLoader;
        private readonly NorthwindContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryPartialRouter(NorthwindContext db, IContentLoader contentLoader, IHttpContextAccessor httpContextAccessor)
        {
            _contentLoader = contentLoader;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        // this method must convert a Category entity into a partial URL path
        // e.g. the category named "Meat/Poultry"
        // into the URL "/Northwind/Meat_Poultry"
        public PartialRouteData GetPartialVirtualPath(Entities.Category content, UrlGeneratorContext urlGeneratorContext)
        {
            var northwindPages = _contentLoader.GetChildren<CategoriesPage>(ContentReference.StartPage);

            // the base of the URL will be the URL for the CategoriesPage instance
            var basePath = ContentReference.EmptyReference;
            if (northwindPages.Count() > 0)
            {
                basePath = northwindPages.First().ContentLink;
            }

            var partialRouteData = new PartialRouteData
            {
                BasePathRoot = basePath,
                PartialVirtualPath = content.CategoryName.Replace('/', '_') + "/"
            };

            return partialRouteData;
        }

        // this method must convert a partial URL path into a Category entity
        // e.g. the URL "/Northwind/Meat_Poultry"
        // into the category named "Meat/Poultry"
        public object RoutePartial(CategoriesPage content, UrlResolverContext urlResolverContext)
        {
            // get the next part from the URL, i.e. what comes after "/Northwind/"
            var categorySegment = urlResolverContext.GetNextSegment(urlResolverContext.RemainingSegments);
            var categoryName = categorySegment.Next.ToString();
            // find the matching Category entity
            var alternativeCategory = categoryName.Replace('_', '/');
            var category = _db.Categories.AsNoTracking()
                .Include(c => c.Products)
                .SingleOrDefault(c =>
                    (c.CategoryName == categoryName) ||
                    (c.CategoryName == alternativeCategory));

            // Console.WriteLine(categoryName);
            if (category != null)
            {
                // store the found Category in the route data
                // so it can be passed into a view
                _httpContextAccessor.HttpContext.Items["category"] = category;
                // store the remaining path so it could be processed
                // by another partial router, perhaps for Products
                urlResolverContext.RemainingSegments = categorySegment.Remaining;
            }

            return category;
        }
    }
}
