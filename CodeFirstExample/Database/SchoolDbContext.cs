using System.Data.Entity;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Standard> Standards { get; set; }

        public SchoolDbContext() : base("name=SchoolDBConnection")
        {
            System.Data.Entity.Database.SetInitializer(new SchoolDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Admin");

            modelBuilder.Entity<Student>().Map(m => 
            {
                m.Properties(p => new { p.StudentID, p.StudentName });
                m.ToTable("StudentInfo");
            }).Map(m =>
            {
                m.Properties(p => new { p.StudentID, p.Height, p.Weight, p.Photo, p.DateOfBirth });
                m.ToTable("StudentInfoDetail");
            });

            modelBuilder.Entity<Grade>().ToTable("GradeInfo");
        }
    }
}
