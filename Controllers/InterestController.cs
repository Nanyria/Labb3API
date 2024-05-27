using Labb3API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IPersonAndInterests<Interest> _interests;

        public InterestController(IPersonAndInterests<Interest> interests)
        {
            _interests = interests;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interests.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var result = await _interests.GetSingle(id);
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
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest newInterest)
        {
            try
            {
                if(newInterest == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _interests.Add(newInterest);
                return CreatedAtAction(nameof(GetAllInterests), new
                {
                    id = createdInterest.InterestID
                }, createdInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }

            
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var productToDelete = await _interests.GetSingle(id);
                if (productToDelete == null)
                {
                    return NotFound($"Product with id {id} not found to delete");
                }
                return await _interests.Delete(id);
            }
            catch (Exception)
            { 

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if (id != interest.InterestID)
                {
                    return BadRequest("Product ID not found/not matching");
                }
                var interestToUpdate = await _interests.GetSingle(id);
                if ( interestToUpdate == null)
                {
                    return NotFound($"Product with id {id} not found to update");

                }
                return await _interests.Update(interest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error when trying to retrieve from database.");
            }
        }
        
    }
}
