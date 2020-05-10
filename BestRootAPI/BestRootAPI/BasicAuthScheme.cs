using Microsoft.OpenApi.Models;

namespace BestRootAPI
{
    internal class BasicAuthScheme : OpenApiSecurityScheme
    {
        public string Description { get; set; }
    }
}