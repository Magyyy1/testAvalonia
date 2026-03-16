using System;
using System.Collections.Generic;

namespace testAvalonia.Data
{
    public partial class User
    {
        public int IdUser { get; set; }

        public string? Fname { get; set; }

        public string? Name { get; set; }

        public string? Patronumic { get; set; }

        public DateOnly? DateBirth { get; set; }

        public int? IdLogPass { get; set; }

        public int? IdGroup { get; set; }

        public virtual Group? IdGroupNavigation { get; set; }

        public virtual Login? IdLogPassNavigation { get; set; }
    }
}
