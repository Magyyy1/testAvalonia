using System;
using System.Collections.Generic;

namespace testAvalonia.Data
{
    public partial class Login
    {
        public int IdLogins { get; set; }

        public string? LoginName { get; set; }

        public string? Password { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
