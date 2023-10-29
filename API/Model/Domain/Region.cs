namespace API.Model.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        public double Area { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public long Pop { get; set; }


        //Navigation property

        // one region have multiple walks (informing EF)
        public IEnumerable<Walk> Walks { get; set; } 



    }
}
