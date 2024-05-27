using AutoMapper;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SUT23TeknikButikModels;

namespace Labb3API.Services
{
    public class PersonRepository : IPersonAndInterests<PersonDto>
    {
        private AppDbContext _appContext;
        private IMapper _mapper;
        public PersonRepository(AppDbContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<PersonDto> Add(PersonDto newEntity)
        {
            var person = _mapper.Map<Person>(newEntity);
            var result = await _appContext.People.AddAsync(person);
            await _appContext.SaveChangesAsync();
            return _mapper.Map<PersonDto>(result.Entity);

        }

        public async Task<PersonDto> Delete(int id)
        {
            var person = await _appContext.People.Include(p => p.PersonInterests).ThenInclude(pi => pi.Interests)
                                                  .FirstOrDefaultAsync(p => p.PersonID == id);
            if (person != null)
            {
                _appContext.People.Remove(person);
                await _appContext.SaveChangesAsync();
                return _mapper.Map<PersonDto>(person);
            }
            return null;
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var people = await _appContext.People
            .Include(p => p.personalInterestLinks)
                .ThenInclude(pi => pi.Interest)
                    .ThenInclude(i => i.personalInterestLinks)
                        .ThenInclude(il => il.Link)
            .ToListAsync();
            return _mapper.Map<List<PersonDto>>(people);
        }

        //public async Task<IEnumerable<PersonDto>> GetAll()
        //{
        //    var people = await _appContext.People
        //    .Include(p => p.personalInterestLinks)
        //        .ThenInclude(pi => pi.Interest)
        //            .ThenInclude(i => i.personalInterestLinks)
        //                .ThenInclude(il => il.Link)
        //    .ToListAsync();
        //    return _mapper.Map<List<PersonDto>>(people);
        //}

        public async Task<PersonDto> GetSingle(int id)
        {
            var person = await _appContext.People
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interests)
                        .ThenInclude(i => i.personalInterestLinks)
                            .ThenInclude(il => il.Link)
                .FirstOrDefaultAsync(p => p.PersonID == id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> Update(PersonDto entity)
        {
            var person = await _appContext.People
                .Include(p => p.PersonInterests)
                    .ThenInclude(pi => pi.Interests)
                        .ThenInclude(i => i.personalInterestLinks)
                            .ThenInclude(il => il.Link)
                .FirstOrDefaultAsync(p => p.PersonID == entity.PersonID);

            if (person != null)
            {
                person.FirstName = entity.FirstName;
                person.LastName = entity.LastName;
                person.PhoneNumber = entity.PhoneNumber;

                await _appContext.SaveChangesAsync();
                return _mapper.Map<PersonDto>(person);
            }
            return null;
        }


    }
}
