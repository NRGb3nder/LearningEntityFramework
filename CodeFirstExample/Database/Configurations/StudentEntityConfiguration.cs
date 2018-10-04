using System.Data.Entity.ModelConfiguration;
using CodeFirstExample.Database.Domain;

namespace CodeFirstExample.Database.Configurations
{
    public class StudentEntityConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfiguration()
        {
            Map(m =>
            {
                m.Properties(e => new { e.StudentKey, e.StudentName });
                m.ToTable("StudentInfo");
            })
            .Map(m =>
            {
                m.Properties(e => new { e.StudentKey, e.Height, e.Weight, e.Photo, e.DateOfBirth });
                m.ToTable("StudentInfoDetail");
            });

            HasKey(e => e.StudentKey);
            HasRequired(e => e.StudentAddress).WithRequiredPrincipal(e => e.Student);
            Property(e => e.StudentName).HasMaxLength(50).IsFixedLength().IsConcurrencyToken();
            Property(e => e.DateOfBirth).HasColumnName("DoB").HasColumnOrder(3).HasColumnType("datetime2");
            Property(e => e.Height).HasPrecision(5, 2).IsOptional();
            Property(e => e.Weight).IsRequired();
        }
    }
}
