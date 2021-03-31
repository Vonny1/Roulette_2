using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Roulette.DataAccess.Context.Models
{
    public partial class Title
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? TierId { get; set; }

        [JsonIgnore]
        public virtual Tier Tier { get; set; }
    }
}
