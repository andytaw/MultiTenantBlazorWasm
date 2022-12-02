using System.Runtime.CompilerServices;

namespace MTPA.Server
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .Use(async (context, next) =>
                {
                    var url = context.Request.Path.Value ?? "";

                    if (url.Contains('.')) // request is for a file, not a defined endpoint
                    {
                        // remove the 'tenant' part of the route
                        context.Request.Path = "/" + string.Join('/', url.Split('/').Skip(2));
                    }

                    await next();
                })
                .UseDeveloperExceptionPage()
                .UseBlazorFrameworkFiles()
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                });
        }
    }
}
