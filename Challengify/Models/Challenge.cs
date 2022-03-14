using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challengify.Models
{
    [Table("Challenge")]
    public class Challenge
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int MaxParticipants { get; set; }

        public int SumOfXP { get; set; }

        public List<User> Participants { get; set; }

        public Challenge() { }

    }
}
