using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace NicosApp.API.Helpers
{
    public class DocumentFilter : IDocumentFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DocumentFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            string url;

            var request = _httpContextAccessor.HttpContext?.Request;
            if (request != null)
            {
                url = $"{request.Scheme}://{request.Host}";
            }
            else
            {
                url = "https://localhost";

                // we need to modify the Key, but that is read-only so let's just make a copy of the Paths property
                var copy = new OpenApiPaths();
                foreach (var path in swaggerDoc.Paths)
                {
                    var newKey = Regex.Replace(path.Key, "/api/v[^/]*", string.Empty);
                    copy.Add(newKey, path.Value);
                }
                swaggerDoc.Paths.Clear();
                swaggerDoc.Paths = copy;
            }
            swaggerDoc.Servers.Add(new OpenApiServer { Url = url });
        }
    }
}
