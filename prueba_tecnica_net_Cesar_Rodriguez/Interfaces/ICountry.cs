using Newtonsoft.Json;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Interfaces
{
    public interface ICountry
    {
        Task<List<Country>> GetCountriesAsync();
    }
}
