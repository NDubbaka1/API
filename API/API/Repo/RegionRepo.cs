﻿using API.Data;
using API.Model.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
