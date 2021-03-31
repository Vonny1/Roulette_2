using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Title> Titles { get; set; }
    }
}
