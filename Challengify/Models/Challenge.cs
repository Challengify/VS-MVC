using System;
using System.Collections.Generic;

namespace Challengify.Models
{
    public class Challenge
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public int MaxParticipants { get; set; }

        public int SumOfXP { get; set; }

        public List<User> Participants { get; set; }

    }
}
