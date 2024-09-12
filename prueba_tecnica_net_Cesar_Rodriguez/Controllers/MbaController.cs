using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_net_Cesar_Rodriguez.Data;
using prueba_tecnica_net_Cesar_Rodriguez.Interfaces;
using prueba_tecnica_net_Cesar_Rodriguez.Models;

namespace prueba_tecnica_net_Cesar_Rodriguez.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MbaController : Controller
    {
        private readonly ICountry _iCountry;
        private readonly MbaDbContext _mbaDbContext;
        public MbaController(ICountry iCountry, MbaDbContext mbaDbContext)
        {
            _iCountry = iCountry;
            _mbaDbContext = mbaDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetMbas()
        {
            var countries = await _iCountry.GetCountriesAsync();
            return Ok(countries);
        }


    }
}
