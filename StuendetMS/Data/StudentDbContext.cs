using Microsoft.EntityFrameworkCore;
using StuendetMS.Entity;

namespace StuendetMS.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> dbContextOptions)
            :base(dbContextOptions) 
        {
            
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
