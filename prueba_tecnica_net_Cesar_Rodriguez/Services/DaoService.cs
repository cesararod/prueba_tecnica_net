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

        /// <summary>
        /// Saves  a list of countries from the api.
        /// </summary>
        /// <returns>A CountryDAO List</returns>
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

        /// <summary>
        /// used to map a country from the consumed API to a DAo object fror saving in the database.
        /// </summary>
        /// <returns>A CountryDAO instance</returns>
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

        /// <summary>
        /// used to get the saved countries and mba's from the database.
        /// </summary>
        /// <returns>A CountryDAO List</returns>
        public async Task<List<CountryDAO>> LoadedCountriesAsync()
        {
            return await _mbaDbContext.Countries.Include(x => x.Mbas).ToListAsync();

        }

        /// <summary>
        /// used to get a saved countries and it's mba's from the database filtering by country ID.
        /// </summary>
        /// <param name="id">country Id.</param>
        /// <returns>A CountryDAO instance</returns>
        public async Task<CountryDAO> GetCountryByIdAsync(Guid id)
        {
            var country = await _mbaDbContext.Countries
                .Include(m => m.Mbas) 
                .FirstOrDefaultAsync(c => c.Id == id);

            return country;
        }
    }
}
