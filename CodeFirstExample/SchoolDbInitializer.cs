using System.Data.Entity;

namespace CodeFirstExample
{
    public class SchoolDbInitializer : DropCreateDatabaseAlways<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            base.Seed(context);
        }
    }
}
