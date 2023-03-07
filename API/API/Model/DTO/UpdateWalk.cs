namespace API.Model.DTO
{
    public class UpdateWalk
    {
        public string Name { get; set; }
        public double lenght { get; set; }

        public Guid RegionID { get; set; }

        public Guid WalkdiffcultyID { get; set; }

       
    }
}
