using API.Data;
using API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repo
{
    public class WalkDiffRepo:IWalkDiffRepo
    {
        private readonly APIDBContext aPIDBContext;

        public WalkDiffRepo(APIDBContext aPIDBContext) { 
            this.aPIDBContext = aPIDBContext;
        }

        public async Task<WalkDiffculty> AddWalkDiffculty(WalkDiffculty walkDiffculty)
        {
            walkDiffculty.Id = new Guid();
            await aPIDBContext.AddAsync(walkDiffculty);
            await aPIDBContext.SaveChangesAsync();
            return walkDiffculty;
        }

        public async Task<IEnumerable<WalkDiffculty>> GetAllWalkDiff()
        {
            return await aPIDBContext.WalkDiffculty.ToListAsync();
        }

        public async Task<WalkDiffculty> GetWalkDiffculty(Guid id)
        {
            return await aPIDBContext.WalkDiffculty.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
