using System.Collections.Generic;

namespace CodeFirstExample.Database.Domain
{
    public class Grade
    {
        public int GradeKey { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
