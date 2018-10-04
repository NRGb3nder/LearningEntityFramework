using System.Data.Entity.ModelConfiguration;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database.Configurations
{
    public class StandardEntityConfiguration : EntityTypeConfiguration<Standard>
    {
        public StandardEntityConfiguration()
        {
            HasKey(e => e.StandardKey);
        }
    }
}
