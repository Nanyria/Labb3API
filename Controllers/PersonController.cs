using AutoMapper;
using Labb3API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonAndInterests<PersonDto> _people;
        private IMapper _mapper;

        public PersonController(IPersonAndInterests<PersonDto> people, IMapper mapper)
        {
            _people = people;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<PersonDto>> GetAllPeople()
        {
            try
            {
                var people = await _people.GetAll();
                var peopleDto = people.Select(p => _mapper.Map<PersonDto>(p)).ToList();
                return Ok(peopleDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDto>> GetPeople(int id)
        {
            try
            {
                var result = await _people.GetSingle(id);
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
        public async Task<ActionResult<PersonDto>> CreateNewPerson(PersonDto newPerson)
        {
            try
            {
                if(newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _people.Add(newPerson);
                return CreatedAtAction(nameof(GetPeople), 
                new
                {
                    id = createdPerson.PersonID
                }, createdPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }

            
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PersonDto>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _people.GetSingle(id);
                if (personToDelete == null)
                {
                    return NotFound($"Product with id {id} not found to delete");
                }
                return await _people.Delete(id);
            }
            catch (Exception)
            { 

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PersonDto>> UpdatePerson
            (int id, PersonDto person)
        {
            try
            {
                if (id != person.PersonID)
                {
                    return BadRequest("Person ID not found/not matching");
                }
                var interestToUpdate = await _people.GetSingle(id);
                if ( interestToUpdate == null)
                {
                    return NotFound($"Person with id {id} not found to update");

                }
                return await _people.Update(person);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error when trying to retrieve from database.");
            }
        }
        
    }
}
