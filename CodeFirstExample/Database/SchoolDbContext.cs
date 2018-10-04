using System.Data.Entity;
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

            modelBuilder.Entity<Student>().HasKey(e => e.StudentKey);
            modelBuilder.Entity<Grade>().HasKey(e => e.GradeKey);
            modelBuilder.Entity<Standard>().HasKey(e => e.StandardKey);

            modelBuilder.Entity<Student>()
                .HasRequired(e => e.StudentAddress)
                .WithRequiredPrincipal(e => e.Student);

            modelBuilder.Entity<Student>().Map(m => 
            {
                m.Properties(e => new { e.StudentKey, e.StudentName });
                m.ToTable("StudentInfo");
            }).Map(m =>
            {
                m.Properties(e => new { e.StudentKey, e.Height, e.Weight, e.Photo, e.DateOfBirth });
                m.ToTable("StudentInfoDetail");
            });

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsFixedLength()
                .IsConcurrencyToken();
            modelBuilder.Entity<Student>()
                .Property(e => e.DateOfBirth)
                .HasColumnName("DoB")
                .HasColumnOrder(3)
                .HasColumnType("datetime2");
            modelBuilder.Entity<Student>()
                .Property(e => e.Height)
                .HasPrecision(5, 2)
                .IsOptional();
            modelBuilder.Entity<Student>()
                .Property(e => e.Weight)
                .IsRequired();

            modelBuilder.Entity<Grade>().ToTable("GradeInfo");
        }
    }
}
