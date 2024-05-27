using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;

namespace Labb3API.Services
{
    public class InterestRepository : IPersonAndInterests<Interest>
    {
        private AppDbContext _appContext;
        public InterestRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appContext.Interests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync
                (i => i.InterestID == id);
            if (result != null)
            {
                _appContext.Interests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _appContext.Interests.FirstOrDefaultAsync(i => i.InterestID == id);
        }

        public async Task<Interest> Update(Interest entity)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync
                (i => i.InterestID == entity.InterestID);
            if (result != null)
            {
                result.InterestTitle = entity.InterestTitle;
                result.InterestsDescription = entity.InterestsDescription;


                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}

