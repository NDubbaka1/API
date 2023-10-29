using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class APIDBContextAuth :IdentityDbContext
    {
        public APIDBContextAuth(DbContextOptions<APIDBContextAuth> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var ReaderID = "58cdfc1e-0495-4d23-ab45-67f3244d24a7";
            var WriterID = "06649504-7100-4052-9488-8e7e3cd0e696";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id= ReaderID,
                    ConcurrencyStamp= ReaderID,
                    Name ="Reader",
                    NormalizedName ="Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id= WriterID,
                    ConcurrencyStamp= WriterID,
                    Name ="Writer",
                    NormalizedName ="Writer".ToUpper()

                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }


    }
}
