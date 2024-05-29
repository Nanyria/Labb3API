using Labb3API.Services;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestLinkController : ControllerBase
    {
        private ICombinationTables<InterestLinks> _interestLinks;

        public InterestLinkController(ICombinationTables<InterestLinks> interestLinks)
        {
            _interestLinks = interestLinks;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterestLinks()
        {
            try
            {
                var il = await _interestLinks.GetAll();
                return Ok(il);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInterestLink(int id)
        {
            try
            {
                var result = await _interestLinks.GetSingleByID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewInterestLink(InterestLinks newInterestLinks)
        {
            try
            {
                if (newInterestLinks == null)
                {
                    return BadRequest();
                }
                var createdIL = await _interestLinks.Add(newInterestLinks);
                return CreatedAtAction(nameof(GetInterestLink),
                    new
                    {
                        id = createdIL.InterestLinkID,
                        
                    }, createdIL);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<InterestLinks>> DeleteInterestLink(int id)
        {
            try
            {
                var linkToDelete = await _interestLinks.GetSingleByID(id);
                if (linkToDelete == null)
                {
                    return NotFound($"Link with id {id} not found to delete");
                }
                return await _interestLinks.DeleteByID(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<InterestLinks>> UpdateInterestLink
            (int id, InterestLinks iLink)
        {
            try
            {
                if (id != iLink.InterestLinkID)
                {
                    return BadRequest("Link ID not found/not matching");
                }
                var interestLinkToUpdate = await _interestLinks.GetSingleByID(id);
                if (interestLinkToUpdate == null)
                {
                    return NotFound($"Link with id {id} not found to update");

                }
                return await _interestLinks.Update(iLink);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to retrieve from database.");
            }
        }
    }
}
