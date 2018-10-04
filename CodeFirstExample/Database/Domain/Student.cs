using System;
using System.Collections.Generic;

namespace CodeFirstExample.Database.Domain
{
    public class Student
    {
        public int StudentKey { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public Grade Grade { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}
