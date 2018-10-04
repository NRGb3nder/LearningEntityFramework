using CodeFirstExample.Database.Domain;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirstExample.Database
{
    public class SchoolDbInitializer : DropCreateDatabaseAlways<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            IList<Standard> defaultStandards = new List<Standard>();

            defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            context.Standards.AddRange(defaultStandards);

            base.Seed(context);
        }
    }
}
