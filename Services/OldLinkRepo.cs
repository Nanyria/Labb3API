using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;

namespace Labb3API.Services
{
    public class OldLinkRepo : IPersonAndInterests<Link>
    {
        private AppDbContext _appContext;
        public OldLinkRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Link> Add(Link newEntity)
        {
            var result = await _appContext.Links.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Link> Delete(int id)
        {
            var result = await _appContext.Links.FirstOrDefaultAsync
                (i => i.LinkID == id);
            if (result != null)
            {
                _appContext.Links.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appContext.Links.ToListAsync();
        }

        public async Task<Link> GetSingle(int id)
        {
            return await _appContext.Links.FirstOrDefaultAsync(i => i.LinkID == id);
        }

        public async Task<Link> Update(Link entity)
        {
            var result = await _appContext.Links.FirstOrDefaultAsync
                (i => i.LinkID == entity.LinkID);
            if (result != null)
            {
                result.LinkSite = entity.LinkSite;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

