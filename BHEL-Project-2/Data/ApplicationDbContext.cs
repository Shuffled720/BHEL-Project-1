using Microsoft.EntityFrameworkCore;
using BHEL_Project_2.Models;

namespace BHEL_Project_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<BHEL_Project_2.Models.Component> Component { get; set; } = default!;
    }
}
