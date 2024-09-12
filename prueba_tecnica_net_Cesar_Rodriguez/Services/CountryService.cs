
using prueba_tecnica_net_Cesar_Rodriguez.Models;
using prueba_tecnica_net_Cesar_Rodriguez.Interfaces;
using System.Net.Http;
using Newtonsoft.Json;

namespace prueba_tecnica_net_Cesar_Rodriguez.Services
{
    public class CountryService:ICountry
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://api.opendata.esett.com/EXP13/MBAOptions");
                var jsonResponse = JsonConvert.DeserializeObject<List<Country>>(response);
                return jsonResponse;
            }
            catch (Exception ex) {
                throw new Exception("Error base", ex);
            }
        }
    }
}
