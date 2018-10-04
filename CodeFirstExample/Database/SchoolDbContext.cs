using System.Data.Entity;
using CodeFirstExample.Database.Configurations;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public SchoolDbContext() : base("name=SchoolDBConnection")
        {
            System.Data.Entity.Database.SetInitializer(new SchoolDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Admin");
            modelBuilder.Configurations.Add(new GradeEntityConfiguration());
            modelBuilder.Configurations.Add(new StudentEntityConfiguration());
            modelBuilder.Configurations.Add(new StandardEntityConfiguration());
        }
    }
}
