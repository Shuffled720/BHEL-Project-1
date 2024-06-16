using Microsoft.EntityFrameworkCore;
using BHEL_Project_1.Models;

namespace BHEL_Project_1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<ComponentMaster> ComponentMaster { get; set; }
        public DbSet<ComponentTypeMaster> ComponentTypeMaster { get; set; }
    }
}
