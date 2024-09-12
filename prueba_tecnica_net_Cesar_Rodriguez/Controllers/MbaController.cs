using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_net_Cesar_Rodriguez.Models;
using prueba_tecnica_net_Cesar_Rodriguez.Interfaces;
using prueba_tecnica_net_Cesar_Rodriguez.Services;
using prueba_tecnica_net_Cesar_Rodriguez.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_tecnica_net_Cesar_Rodriguez.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MbaController : Controller
    {
        private readonly ICountry _iCountry;
        private readonly IDao _iDao;
        public MbaController(ICountry iCountry, IDao iDao)
        {
            _iCountry = iCountry;
            _iDao = iDao;
        }

        /// <summary>
        /// Consumes the opendata endpoint and saves it's data.
        /// </summary>
        /// <returns>Returns a list of already procesed countries and mba's.</returns>
        [HttpGet]
        [Route("ConsumeMBAOptions")]
        public async Task<ActionResult<List<CountryDAO>>> ConsumeMBAOptions()
        {
            var countries = await _iCountry.GetCountriesAsync();
            await _iDao.RecordCountriesAsync(countries);

            return Ok(await _iDao.LoadedCountriesAsync());
        }

        /// <summary>
        /// Obtains a Country List from the database
        /// </summary>
        /// <returns>Returns a list of already procesed countries and mba's.</returns>
        [HttpGet]
        [Route("GetLoadedMbas")]
        public async Task<ActionResult<List<CountryDAO>>> GetLoadedMbas()
        {
           return Ok(await _iDao.LoadedCountriesAsync());
        }

        /// <summary>
        /// Obtains a Country from the database using the Guid.
        /// </summary>
        /// <param name="id">Country Id.</param>
        /// <returns>Returns CountryDAO object from the database.</returns>
        [HttpGet]
        [Route("GetCountryById/{id}")]
        public async Task<ActionResult<CountryDAO>> GetCountryByIdAsync(Guid id)
        {
            CountryDAO country = await _iDao.GetCountryByIdAsync(id);

            return Ok(country);
        }        
    }
}
