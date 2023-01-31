using API.Data;
using API.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Repo
{
    public class RegionRepo : IRegioRepo
    {

        private readonly APIDBContext aPIDBContext;
        public RegionRepo(APIDBContext aPIDBContext)
        {
           this.aPIDBContext = aPIDBContext;
        }

       

        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            return await aPIDBContext.Regions.ToListAsync();
        }


       
        public async Task<Region> GetRegionByIDAsync(Guid id)
        {
            return await aPIDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await aPIDBContext.Regions.AddAsync(region);
            await aPIDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionByID(Guid id)
        {
            var region = await aPIDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region ==null)
            {
                return null;
            }

             aPIDBContext.Regions.Remove(region);
            await aPIDBContext.SaveChangesAsync();
            return region;
        }

    }
}
