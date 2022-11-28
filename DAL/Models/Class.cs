using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public int? ProfessorId { get; set; }
        public int? SubjectId { get; set; }

        public virtual Professor Professor { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
