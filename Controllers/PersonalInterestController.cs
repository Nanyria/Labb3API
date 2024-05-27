using Labb3API.Services;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInterestController : Controller
    {
        private ICombinationTables<PersonInterests> _personalInterests;
        public PersonalInterestController(ICombinationTables<PersonInterests> personalInterests) 
        {
            _personalInterests = personalInterests;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersonInterests()
        {
            try
            {
                return Ok(await _personalInterests.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }

        
    }
}
