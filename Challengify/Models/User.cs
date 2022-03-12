using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Challengify.Models
{
    [Table("User")]
    public class User : IdentityUser
    {
        //public Guid Id { get; set; }

        public bool IsSubcriber { get; set; }

        public int XP { get; set; }

        public List<Challenge> UserChallenges { get; set; }

        //public List<Achievment> Achievments { get; set; }
    }
}
