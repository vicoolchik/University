using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Classes = new HashSet<Class>();
        }

        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
