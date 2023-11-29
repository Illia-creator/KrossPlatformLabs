using Labs6_7.Web.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Labs6_7.Web.Pages;

public class MedicationsModel : PageModel
{
    private readonly IHttpClientFactory _clientFactory;

    public MedicationsModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public List<MedicationResponse> Medications { get; set; }
    public async void OnGet()
    {
        var httpClient = _clientFactory.CreateClient();

        var authData = await httpClient.GetAsync("http://localhost:5000/api/v1/tokens");

        var content = await authData.Content.ReadAsStringAsync();

        AuthResponse parseContent = null;

        if (!string.IsNullOrEmpty(content))
        {
            parseContent = JsonSerializer.Deserialize<AuthResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (parseContent != null && !string.IsNullOrEmpty(parseContent.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", parseContent.AccessToken);
            }
        }

        var response = await httpClient.GetAsync("http://localhost:5000/api/v1/customers/orders");

        if (response.IsSuccessStatusCode) Medications = await response.Content.ReadFromJsonAsync<List<MedicationResponse>>();
        else Medications = new List<MedicationResponse>();
    }
}
