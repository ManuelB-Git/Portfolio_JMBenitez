using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace Portfolio_JMBenitez
{
    public static class StaticAssetsExtensions
    {
        public static void MapStaticAssets(this WebApplication app)
        {
            // Configure static file middleware to serve PDF files
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".pdf"] = "application/pdf";

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            // Map Resources folder to be accessible
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    Path.Combine(app.Environment.ContentRootPath, "Resources")),
                RequestPath = "/Resources",
                ContentTypeProvider = provider
            });
        }
    }
}