using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace Lab5.Web.Pages
{
    public class LabsSelectModel : PageModel
    {
        public LabsSelectModel(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public bool IsAuth { get; set; }

        private IHttpClientFactory HttpClientFactory { get; }

        public async Task OnGetAsync()
        {
            using var httpClient = HttpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await HttpContext.GetTokenAsync("access_token"));

            var secret = await httpClient.GetAsync("https://localhost:7001/App");

            if (!string.IsNullOrWhiteSpace(secret.Content.ToString()))
                IsAuth = true;
        }
    }
}
