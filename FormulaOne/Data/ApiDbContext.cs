using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FormulaOne.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Driver> Drivers { get; set; }
    }
}
