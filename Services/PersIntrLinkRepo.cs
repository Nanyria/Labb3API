using SUT23TeknikButikModels;
using Labb3API.Data;
using Microsoft.EntityFrameworkCore;
using SUT23TeknikButikModels.Connections;

namespace Labb3API.Services
{
    public class PersIntrLinkRepo : ICombinationTables<PersonalInterestLinks>
    {
        private AppDbContext _appContext;
        public PersIntrLinkRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<PersonalInterestLinks> Add(PersonalInterestLinks newEntity)
        {
            var result = await _appContext.PersonalInterestLinks.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonalInterestLinks> DeleteByA(int linkID)
        {
            var result = await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(
                p => p.LinkID == linkID);
            {
                _appContext.PersonalInterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PersonalInterestLinks> DeleteByID(int id)
        {
            var result = await _appContext.PersonalInterestLinks.FirstOrDefaultAsync
            (p => p.PersonalLinkID == id);
            if (result != null)
            {
                _appContext.PersonalInterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PersonalInterestLinks> DeleteByB(int interestID)
        {
            var result = await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(
                i => i.InterestID == interestID);

            if (result != null)
            {
                _appContext.PersonalInterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PersonalInterestLinks> DeleteByC(int personId)
        {
            var result = await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(
                i => i.PersonID == personId);

            if (result != null)
            {
                _appContext.PersonalInterestLinks.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<PersonalInterestLinks>> GetAll()
        {
            return await _appContext.PersonalInterestLinks.ToListAsync();
        }

        public async Task<PersonalInterestLinks> GetSingleByA(int linkID)
        {
            return await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(p => p.LinkID == linkID);
        }

        public async Task<PersonalInterestLinks> GetSingleByID(int id)
        {
            return await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(i => i.PersonalLinkID == id);
        }

        public async Task<PersonalInterestLinks> GetSingleByB(int interestID)
        {
            return await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(i => i.InterestID == interestID);
        }
        public async Task<PersonalInterestLinks> GetSingleByC(int personID)
        {
            return await _appContext.PersonalInterestLinks.FirstOrDefaultAsync(i => i.PersonID == personID);
        }


        public async Task<PersonalInterestLinks> Update(PersonalInterestLinks entity)
        {
            var result = await _appContext.PersonalInterestLinks.FirstOrDefaultAsync
                (p => p.PersonalLinkID == entity.PersonalLinkID);
            if (result != null)
            {
                result.LinkID = entity.LinkID;
                result.InterestID = entity.InterestID;
                result.PersonID = entity.PersonID;


                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}

