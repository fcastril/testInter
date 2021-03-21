using Microsoft.EntityFrameworkCore;
using testInter.Data;

namespace testInter.Repo
{
    public class testInterContext : DbContext
    {
        public testInterContext(DbContextOptions<testInterContext> options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new EmployeeMap(modelBuilder.Entity<Employee>());

        }
    }
}
