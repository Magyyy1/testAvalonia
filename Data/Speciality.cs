using System;
using System.Collections.Generic;

namespace testAvalonia.Data
{
    public partial class Speciality
    {
        public int IdSpeciality { get; set; }

        public string? NameSpeciality { get; set; }

        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
