using System.Data.Entity;

namespace CodeFirstExample
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public SchoolContext() : base("SchoolDBConnection")
        {
        }
    }
}
