using API.Data;
using API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API.Repo
{
    public class WalkRepo :IWalkRepo
    {
         private readonly APIDBContext aPIDBContext;
        public WalkRepo(APIDBContext aPIDBContext) {

            this.aPIDBContext = aPIDBContext;
        }

        public async Task<List<Walk>> GetWalk(string? filterOn =null, string? filterQuery= null,
            string ? sortBy = null, bool isAscending = true , int pageNumber = 1, int pageSize = 1000)
        {
            var walk =  aPIDBContext.Walks.
                Include(x => x.Region)
                .Include(x => x.WalkDiffculty).
                AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walk = walk.Where(x => x.Name.Contains(filterQuery));
                    
                }
            }

            // sort
            if (string.IsNullOrWhiteSpace(sortBy)==false )
            {
                if (sortBy.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walk = isAscending ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x => x.Name);
                }

                if (sortBy.Equals("lenght", StringComparison.OrdinalIgnoreCase))
                {
                    walk = isAscending ? walk.OrderBy(x => x.lenght) : walk.OrderByDescending(x => x.Name);
                }
            }

            //pagination
            var skipResult = (pageNumber - 1) * pageSize;


            return await  walk.Skip(skipResult).Take(pageSize).ToListAsync();
           
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

        public async Task<Walk> deleteWalk(Guid id)
        {
            var walk = await aPIDBContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }
            aPIDBContext.Walks.Remove(walk);
            await aPIDBContext.SaveChangesAsync();
            return walk;
        }
    }
}
