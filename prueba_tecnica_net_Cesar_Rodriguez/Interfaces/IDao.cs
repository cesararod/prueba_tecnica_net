using prueba_tecnica_net_Cesar_Rodriguez.Data;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Interfaces
{
    public interface IDao
    {
        Task<List<CountryDAO>> RecordCountriesAsync(List<Country> countries);
        Task<List<CountryDAO>> LoadedCountriesAsync();
        Task<CountryDAO> GetCountryByIdAsync(Guid id);
    }
}
