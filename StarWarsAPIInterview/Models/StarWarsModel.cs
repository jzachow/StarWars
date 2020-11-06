using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsAPIInterview.Models
{
    public class StarWarsModel : PageModel
    {
        
        private readonly IHttpClientFactory _clientFactory;

        public IEnumerable<PlanetModel> Planets { get; set; }

        public StarWarsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://swapi.dev/api/planets/1/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Planets = await JsonSerializer.DeserializeAsync<IEnumerable<PlanetModel>>(responseStream);
            }
            
        }
    }
}
