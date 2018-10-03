using System.Data.Entity;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public SchoolDbContext() : base("name=SchoolDBConnection")
        {
            System.Data.Entity.Database.SetInitializer(new SchoolDbInitializer());
        } 
    }
}
