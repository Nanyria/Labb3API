using Labb3API.Services;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : Controller
    {
        private IPersonAndInterests<Link> _links;

        public LinkController(IPersonAndInterests<Link> links) 
        {
            _links = links;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _links.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
    }
}
