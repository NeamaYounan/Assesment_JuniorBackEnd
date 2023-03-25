using Assesment_Junior_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment_Junior_BE.Repository
{

    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
        public DbSet<User> Users
        {
            get;
            set;
        }
        public DbSet<Joging> Jogings
        {
            get;
            set;
        }
        public DbSet<UserAngular> UserAngulars { get; set; }
    }
}
