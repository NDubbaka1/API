﻿namespace API.Model.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public double lenght { get; set; }

        public Guid RegionID { get; set; }

        public Guid WalkdiffcultyID { get; set; }

        //navigation property

        public Region Region { get; set; }

        public WalkDiffculty WalkDiffculty { get; set; }
    }
}
