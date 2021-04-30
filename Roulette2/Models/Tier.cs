using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#nullable disable

namespace Roulette.Models
{
    public partial class Tier
    {
        public Tier()
        {
            Titles = new HashSet<Title>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }

        public virtual ICollection<Title> Titles { get; set; }
    }
}
