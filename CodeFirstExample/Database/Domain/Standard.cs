﻿using System.Collections.Generic;

namespace CodeFirstExample.Database.Domain
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
