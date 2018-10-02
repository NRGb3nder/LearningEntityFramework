using System.Data.Entity;

namespace CodeFirstExample
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public SchoolDbContext() : base("name=SchoolDBConnection")
        {
        }
    }
}
