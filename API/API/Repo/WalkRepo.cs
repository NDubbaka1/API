using API.Data;
using API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class WalkRepo :IWalkRepo
    {
         private readonly APIDBContext aPIDBContext;
        public WalkRepo(APIDBContext aPIDBContext) {

            this.aPIDBContext = aPIDBContext;   
        }

        public async Task<IEnumerable<Walk>> GetWalkByID()
        {
            var walk = await aPIDBContext.Walks.
                Include(x => x.Region)
                .Include(x => x.WalkDiffculty).
                ToListAsync();
           
            return walk;
           
        }

        public async Task<Walk> GetWalkByID(Guid id)
        {
            return await aPIDBContext.Walks.Include(x => x.Region)
                .Include(x => x.WalkDiffculty).FirstOrDefaultAsync(x => x.Id == id);
            
        }
    }
}
