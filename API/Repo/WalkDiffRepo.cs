using API.Data;
using API.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Security.Cryptography.X509Certificates;

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

        public async Task<WalkDiffculty> DeleteWalkDiff(Guid id)
        {
           var walkDiff = await aPIDBContext.WalkDiffculty.FirstOrDefaultAsync(x => x.Id == id);
              if (walkDiff == null)
            {
                return null;
            }

              aPIDBContext.WalkDiffculty.Remove(walkDiff);
            await aPIDBContext.SaveChangesAsync();

            return walkDiff;
        }


        public async Task<WalkDiffculty> UpdateWalkDiffculty (WalkDiffculty walkDiffculty, Guid id)
        {
            var oldwalkDiff = await aPIDBContext.WalkDiffculty.FirstOrDefaultAsync(x => x.Id == id);
            if (oldwalkDiff != null)
            {
                oldwalkDiff.Id = walkDiffculty.Id;
                oldwalkDiff.Code = walkDiffculty.Code;
                
                await aPIDBContext.SaveChangesAsync();
                return oldwalkDiff;
            }

            return null;


        } 
    }
}
