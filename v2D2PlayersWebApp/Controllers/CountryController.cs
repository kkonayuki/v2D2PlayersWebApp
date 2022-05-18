using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Models.Country;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountry_Service _country_Service;

        public CountryController(ICountry_Service country_Service)
        {
            _country_Service = country_Service;
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCountry(Country_Pass_Object country)
        {
            var result = await _country_Service.AddCountry(country.name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetCountries()
        {
            var result = await _country_Service.GetAllCountries();
            
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> UpdateCountry(CountryUpdate_Pass_Object country)
        {
            var result = await _country_Service.UpdateCountry(country.id, country.name);
            switch (result.success)
            {
                case true:
                    return Ok(result);
                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
