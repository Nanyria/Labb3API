using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Services
{
    public class InterestLinksRepo : ICombinationTables<InterestLinks>
    {
        private AppDbContext _appContext;
        public InterestLinksRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<InterestLinks> Add(InterestLinks newEntity)
        {
            var result = await _appContext.InterestLinks.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<InterestLinks> DeleteByA(int linkID)
        {
            var result = await _appContext.InterestLinks.FirstOrDefaultAsync(
                p => p.LinkID == linkID);
            if(result != null)
            {
                _appContext.InterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<InterestLinks> DeleteByID(int id)
        {
            var result = await _appContext.InterestLinks.FirstOrDefaultAsync
            (p => p.InterestLinkID == id);
            if (result != null)
            {
                _appContext.InterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<InterestLinks> DeleteByB(int interestID)
        {
            var result = await _appContext.InterestLinks.FirstOrDefaultAsync(
                i => i.InterestID == interestID);

            if (result != null)
            {
                _appContext.InterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


        public async Task<IEnumerable<InterestLinks>> GetAll()
        {
            return await _appContext.InterestLinks.ToListAsync();
        }

        public async Task<InterestLinks> GetSingleByA(int linkID)
        {
            return await _appContext.InterestLinks.FirstOrDefaultAsync(p => p.LinkID == linkID);
        }

        public async Task<InterestLinks> GetSingleByID(int id)
        {
            return await _appContext.InterestLinks.FirstOrDefaultAsync(i => i.InterestLinkID == id);
        }

        public async Task<InterestLinks> GetSingleByB(int interestID)
        {
            return await _appContext.InterestLinks.FirstOrDefaultAsync(i => i.InterestID == interestID);
        }



        public async Task<InterestLinks> Update(InterestLinks entity)
        {
            var result = await _appContext.InterestLinks.FirstOrDefaultAsync
                (p => p.InterestLinkID == entity.InterestLinkID);
            if (result != null)
            {
                result.LinkID = entity.LinkID;
                result.InterestID = entity.InterestID;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}

