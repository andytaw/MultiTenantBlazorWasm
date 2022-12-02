using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MTPA.Server.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet(string tenant)
        {
            Tenant = tenant;
        }

        public string? Tenant { get; set; }

        public string BaseUrl
        {
            get
            {
                var request = this.Request;

                var host = request.Host.ToUriComponent();

                var pathBase = request.PathBase.ToUriComponent();

                return $"{request.Scheme}://{host}{pathBase}/";
            }
        }

        public string TenantedBaseUrl => $"{BaseUrl}{Tenant}/";
    }
}