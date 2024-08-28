//using Microsoft.AspNetCore.Http;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System.Linq;
//using System.Security.Claims;

//public class RoleBasedDocumentFilter : IDocumentFilter
//{
//    private readonly IHttpContextAccessor _httpContextAccessor;

//    public RoleBasedDocumentFilter(IHttpContextAccessor httpContextAccessor)
//    {
//        _httpContextAccessor = httpContextAccessor;
//    }

//    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
//    {
//        var httpContext = _httpContextAccessor.HttpContext;

//        if (httpContext == null)
//        {
//            return;
//        }

//        var user = httpContext.User;

//        if (!user.Identity.IsAuthenticated)
//        {
//            // If the user is not authenticated, show only user APIs
//            var allowedPaths = swaggerDoc.Paths
//                .Where(path => path.Key.StartsWith("/api/Users/login") || path.Key.StartsWith("/api/Users/register")
//                || path.Key.StartsWith("/api/login") ||
//                path.Key.StartsWith("/api/register"))

//                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

//            swaggerDoc.Paths = new OpenApiPaths();
//            foreach (var path in allowedPaths)
//            {
//                swaggerDoc.Paths.Add(path.Key, path.Value);
//            }
//            return;
//        }
//        else
//        {

//        }
//        // Get user role
//        var userRole = user.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role)?.Value;

//        // Filter paths based on role
//        var allowedPathsForRole = swaggerDoc.Paths
//            .Where(path =>
//                path.Key.StartsWith("/api/Users/login") ||
//                path.Key.StartsWith("/api/Users/register") || path.Key.StartsWith("/api/user") || path.Key.StartsWith("/api/login") ||
//                path.Key.StartsWith("/api/register") ||
//                (userRole == "Farmer" && path.Key.StartsWith("/api/Farmers")) ||
//                (userRole == "Fertilizer" && path.Key.StartsWith("/api/Fertilizers")))
//            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

//        swaggerDoc.Paths = new OpenApiPaths();
//        foreach (var path in allowedPathsForRole)
//        {
//            swaggerDoc.Paths.Add(path.Key, path.Value);
//        }
//    }
//}