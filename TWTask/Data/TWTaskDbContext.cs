using Microsoft.EntityFrameworkCore;
using TWTask.Models;

namespace TWTask.Data
{
    public class TWTaskDbContext:DbContext
    {
        public TWTaskDbContext(DbContextOptions<TWTaskDbContext> options) : base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
