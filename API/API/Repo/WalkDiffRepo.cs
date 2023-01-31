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

        public async Task<IEnumerable<WalkDiffculty>> GetAllWalkDiff()
        {
            return await aPIDBContext.WalkDiffculty.ToListAsync();
        }
    }
}
