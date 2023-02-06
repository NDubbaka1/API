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

        public async Task<Walk> AddWalkByID(Walk walk)
        {
            walk.Id = new Guid();
            await aPIDBContext.Walks.AddRangeAsync(walk);
            await aPIDBContext.SaveChangesAsync();
            return walk;
        }

        public async Task <Walk> UpdateWalkById(Guid id ,Walk walk)
        {
            var oldwalk = await aPIDBContext.Walks.FindAsync(id);
            if (oldwalk != null)
            {
                oldwalk.Name = walk.Name;
                oldwalk.WalkdiffcultyID = walk.WalkdiffcultyID;
                oldwalk.lenght = walk.lenght;
                oldwalk.RegionID = walk.RegionID;

                await aPIDBContext.SaveChangesAsync();
                return oldwalk;
            }
            return null;
        }
    }
}
