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

        [HttpGet]
        public async Task<ActionResult<List<CountryDAO>>> GetMbas()
        {
            var countries = await _iCountry.GetCountriesAsync();

            List<CountryDAO> recordedCountries = await _iDao.RecordCountriesAsync(countries);
            List<CountryDAO> loadedCountries = await _iDao.LoadedCountriesAsync();
            return Ok(loadedCountries);
        }


    }
}
