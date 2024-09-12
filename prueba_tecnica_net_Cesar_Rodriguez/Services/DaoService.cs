using Microsoft.EntityFrameworkCore;
using prueba_tecnica_net_Cesar_Rodriguez.Data;
using prueba_tecnica_net_Cesar_Rodriguez.Interfaces;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Services
{
    public class DaoService : IDao
    {
        private readonly MbaDbContext _mbaDbContext;

        public DaoService(MbaDbContext mbaDbContext)
        {
            _mbaDbContext = mbaDbContext;
        }

        public async Task<List<CountryDAO>> RecordCountriesAsync(List<Country> countries)
        {
            var countriesLoaded = new List<CountryDAO>();
            foreach (var country in countries)
            {
                var countryDao = MapDAO(country);
                await _mbaDbContext.Countries.AddAsync(countryDao);
                countriesLoaded.Add(countryDao);
            }
            await _mbaDbContext.SaveChangesAsync();
            return countriesLoaded;
        }

        private CountryDAO MapDAO(Country country)
        {
            return new CountryDAO
            {
                Name = country.country,
                Code = country.countryCode,
                Mbas = country.Mbas.Select(m => new MbaDAO
                {
                    Code = m.Code,
                    Name = m.Name
                }).ToList()
            };
        }

        public async Task<List<CountryDAO>> LoadedCountriesAsync()
        {
            var countriesLoaded = await _mbaDbContext.Countries.Include(x => x.Mbas).ToListAsync();

            return countriesLoaded;
        }
    }
}
