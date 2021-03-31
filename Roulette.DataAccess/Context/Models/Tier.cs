using System;
using System.Collections.Generic;

#nullable disable

namespace Roulette.DataAccess.Context.Models
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
