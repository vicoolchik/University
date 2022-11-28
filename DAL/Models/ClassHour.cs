using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class ClassHour
    {
        public int? ClassId { get; set; }
        public TimeSpan? ClassStart { get; set; }
        public TimeSpan? ClassEnd { get; set; }

        public virtual Class Class { get; set; }
    }
}
