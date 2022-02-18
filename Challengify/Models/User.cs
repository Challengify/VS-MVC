using System;
using System.Collections.Generic;

namespace Challengify.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsSubcriber { get; set; }

        public int XP { get; set; }

        public List<Achievment> Achievments { get; set; }
    }
}
