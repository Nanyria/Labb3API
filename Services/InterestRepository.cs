using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Labb3API.Services
{
    public class InterestRepository : IPersonAndInterests<InterestDto>
    {
        private AppDbContext _appContext;
        private IMapper _mapper;
        public InterestRepository(AppDbContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<InterestDto> Add(InterestDto newEntity)
        {

            var interest = _mapper.Map<Interest>(newEntity);
            var result = await _appContext.Interests.AddAsync(interest);
            await _appContext.SaveChangesAsync();
            return _mapper.Map<InterestDto>(result.Entity);

        }

        public async Task<InterestDto> Delete(int id)
        {
            var interest = await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
            if (interest != null)
            {
                _appContext.Interests.Remove(interest);
                await _appContext.SaveChangesAsync();
                return _mapper.Map<InterestDto>(interest);
            }
            return null;
        }

        public async Task<IEnumerable<InterestDto>> GetAll()
        {
            var interest = await _appContext.Interests
                .Include(il => il.InterestLinks)
                    .ThenInclude(l => l.Link)
                .ToListAsync();
            if (interest != null)
            {

                return _mapper.Map<IEnumerable<InterestDto>>(interest);
            }
            return null;

        }

        public async Task<InterestDto> GetSingle(int id)
        {
            var interest = await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestID == id);
            if (interest != null)
            {
                return _mapper.Map<InterestDto>(interest);
            }
            return null;
        }

        public async Task<InterestDto> Update(InterestDto entity)
        {
            var interestToUpdate = await _appContext.Interests.Include(p => p.PersonInterests).ThenInclude(pi => pi.Interests)
                                                .FirstOrDefaultAsync(p => p.InterestID == entity.InterestID);
            if (interestToUpdate != null)
            {
                interestToUpdate.InterestTitle = entity.InterestTitle;
                interestToUpdate.InterestsDescription = entity.InterestsDescription;


                await _appContext.SaveChangesAsync();
                return _mapper.Map<InterestDto>(interestToUpdate);
            }
            return null;
        }


    }
}

