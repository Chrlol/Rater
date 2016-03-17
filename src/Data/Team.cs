using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Team
    {
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public virtual List<Player> Members { get; set; }
        public virtual Score Score { get; set; }
        //public virtual List<TeamMatchResult> MatchHistory { get; set; }

    }
}