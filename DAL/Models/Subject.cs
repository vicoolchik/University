using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string OffsetOrExam { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
