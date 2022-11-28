using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class StudentsClass
    {
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
