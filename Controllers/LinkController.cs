﻿using AutoMapper;
using Labb3API.Services;
using Microsoft.AspNetCore.Mvc;
using SUT23TeknikButikModels;

namespace Labb3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private IPersonAndInterests<LinkDto> _links;
        private IMapper _mapper;
        public LinkController(IPersonAndInterests<LinkDto> links, IMapper mapper)
        {
            _links = links;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLinks()
        {
            try
            {
                var links = await _links.GetAll();
                var linksDto = links.Select(l => _mapper.Map<LinkDto>(l)).ToList();
                return Ok(linksDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LinkDto>> GetLink(int id)
        {
            try
            {
                var result = await _links.GetSingle(id);
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
        public async Task<ActionResult<LinkDto>> CreateNewLink(LinkDto newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var createdLink = await _links.Add(newLink);
                return CreatedAtAction(nameof(GetLink),
                new
                {
                    id = createdLink.LinkID
                }, createdLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<LinkDto>> DeleteLink(int id)
        {
            try
            {
                var linkToDelete = await _links.GetSingle(id);
                if (linkToDelete == null)
                {
                    return NotFound($"Link with id {id} not found to delete");
                }
                return await _links.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<LinkDto>> UpdateLink
            (int id, LinkDto link)
        {
            try
            {
                if (id != link.LinkID)
                {
                    return BadRequest("Link ID not found/not matching");
                }
                var interestToUpdate = await _links.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Link with id {id} not found to update");

                }
                return await _links.Update(link);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error when trying to retrieve from database.");
            }
        }
    }

}
