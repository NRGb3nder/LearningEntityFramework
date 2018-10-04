using System.Data.Entity.ModelConfiguration;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database.Configurations
{
    public class GradeEntityConfiguration : EntityTypeConfiguration<Grade>
    {
        public GradeEntityConfiguration()
        {
            HasKey(e => e.GradeKey);
            ToTable("GradeInfo");
        }
    }
}
