﻿using API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class APIDBContext :DbContext
    {
        //cotr is for db context options to base class 
        public APIDBContext(DbContextOptions<APIDBContext> options): base(options) 
        {
                
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDiffculty> WalkDiffculty { get; set; }

        public DbSet<Info> Info { get; set; }

        public DbSet<Image> Image { get; set; }
    }
}
