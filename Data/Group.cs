using System;
using System.Collections.Generic;

namespace testAvalonia.Data
{
    public partial class Group
    {
        public int IdGroup { get; set; }

        public string? Number { get; set; }

        public int? IdSpeciality { get; set; }

        public virtual Speciality? IdSpecialityNavigation { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
