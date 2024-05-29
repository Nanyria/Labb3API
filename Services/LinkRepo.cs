using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Labb3API.Services
{
    public class LinkRepo : IPersonAndInterests<LinkDto>
    {
        private AppDbContext _appContext;
        private IMapper _mapper;
        public LinkRepo(AppDbContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
        public async Task<LinkDto> Add(LinkDto newEntity)
        {
            var link = _mapper.Map<Link>(newEntity);
            var result = await _appContext.Links.AddAsync(link);
            await _appContext.SaveChangesAsync();
            return _mapper.Map<LinkDto>(result.Entity);
        }

        public async Task<LinkDto> Delete(int id)
        {
            var result = await _appContext.Links.FirstOrDefaultAsync(i => i.LinkID == id);

            if (result != null)
            {
                _appContext.Links.Remove(result);
                await _appContext.SaveChangesAsync();
                return _mapper.Map<LinkDto>(result);
            }
            return null;
        }

        public async Task<IEnumerable<LinkDto>> GetAll()
        {
            var links = await _appContext.Links
                .Include(il => il.InterestLinks)
                    .ThenInclude(i => i.Interest)
                .ToListAsync();
            if (links != null)
            {

                return _mapper.Map<IEnumerable<LinkDto>>(links);
            }
            return null;

        }

        public async Task<LinkDto> GetSingle(int id)
        {
            var link = await _appContext.Links.FirstOrDefaultAsync(i => i.LinkID == id);
            return _mapper.Map<LinkDto>(link);
        }


        public async Task<LinkDto> Update(LinkDto entity)
        {
            var link = await _appContext.Links.FirstOrDefaultAsync(i => i.LinkID == entity.LinkID);
            if (link != null)
            {
                link.LinkSite = entity.LinkSite;

                await _appContext.SaveChangesAsync();
                return _mapper.Map<LinkDto>(link);
            }
            return null;
        }
    }
}

