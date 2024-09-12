
using Newtonsoft.Json;
using prueba_tecnica_net_Cesar_Rodriguez.Interfaces;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Services
{
    public class CountryService : ICountry
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CountryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Consumes, Saves and returns a list of countries from the api.
        /// </summary>
        /// <returns>A country List</returns>
        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(_configuration["ApiSettings:BaseUrl"]);
                var jsonResponse = JsonConvert.DeserializeObject<List<Country>>(response);
                return jsonResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Error base", ex);
            }
        }
    }
}
