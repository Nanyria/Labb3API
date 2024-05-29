using Labb3API.Services;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInterestController : ControllerBase
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonalInterest(int id)
        {
            try
            {
                var result = await _personalInterests.GetSingleByID(id);
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
        public async Task<IActionResult> CreateNewPersonalInterest(PersonInterests newPersonInterest)
        {
            try
            {
                if (newPersonInterest == null)
                {
                    return BadRequest();
                }
                var createdPI = await _personalInterests.Add(newPersonInterest);
                return CreatedAtAction(nameof(GetPersonalInterest),
                    new
                    {
                        id = createdPI.PersonInterestsID,

                    }, createdPI);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PersonInterests>> DeletePersonalInterest(int id)
        {
            try
            {
                var linkToDelete = await _personalInterests.GetSingleByID(id);
                if (linkToDelete == null)
                {
                    return NotFound($"Link with id {id} not found to delete");
                }
                return await _personalInterests.DeleteByID(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PersonInterests>> UpdatePersonalInterest
            (int id, PersonInterests personInterest)
        {
            try
            {
                if (id != personInterest.PersonInterestsID)
                {
                    return BadRequest("PersonalInterest ID not found/not matching");
                }
                var interestLinkToUpdate = await _personalInterests.GetSingleByID(id);
                if (interestLinkToUpdate == null)
                {
                    return NotFound($"PersonalInterest with id {id} not found to update");

                }
                return await _personalInterests.Update(personInterest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to retrieve from database.");
            }
        }

    }
}
