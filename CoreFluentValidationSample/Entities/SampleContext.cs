using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}

