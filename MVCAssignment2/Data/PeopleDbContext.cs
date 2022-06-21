using Microsoft.EntityFrameworkCore;
using MVCAssignment2.Models;

namespace MVCAssignment2.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }
    }
}