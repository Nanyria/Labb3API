using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Services
{
    public class PersonalInterestRepository : ICombinationTables<PersonInterests>
    {
        private AppDbContext _appContext;
        public PersonalInterestRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<PersonInterests> Add(PersonInterests newEntity)
        {
            var result = await _appContext.PersonInterests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonInterests> DeleteByA(int idA)
        {
            var result = await _appContext.PersonInterests.FirstOrDefaultAsync(
                p => p.PersonID == idA);
            {
                _appContext.PersonInterests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PersonInterests> DeleteByID(int id)
        {
            var result = await _appContext.PersonInterests.FirstOrDefaultAsync
            (p => p.PersonInterestsID == id);
            if (result != null)
            {
                _appContext.PersonInterests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PersonInterests> DeleteByB(int idB)
        {
            var result = await _appContext.PersonInterests.FirstOrDefaultAsync(
                i => i.InterestID == idB);

            if (result != null)
            {
                _appContext.PersonInterests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<PersonInterests>> GetAll()
        {
            return await _appContext.PersonInterests.ToListAsync();
        }

        public async Task<PersonInterests> GetSingleByA(int idA)
        {
            return await _appContext.PersonInterests.FirstOrDefaultAsync(p => p.PersonID == idA);
        }

        public async Task<PersonInterests> GetSingleByID(int id)
        {
            return await _appContext.PersonInterests.FirstOrDefaultAsync(i => i.PersonInterestsID == id);
        }

        public async Task<PersonInterests> GetSingleByB(int idB)
        {
            return await _appContext.PersonInterests.FirstOrDefaultAsync(i => i.InterestID == idB);
        }

        public async Task<PersonInterests> Update(PersonInterests entity)
        {
            var result = await _appContext.PersonInterests.FirstOrDefaultAsync
                (p => p.PersonInterestsID == entity.PersonInterestsID);
            if (result != null)
            {
                result.PersonID = entity.PersonID;
                result.InterestID = entity.InterestID;


                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }

}

