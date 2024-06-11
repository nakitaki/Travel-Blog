using BlogTravel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogTravel.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
