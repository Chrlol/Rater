using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Player
    {
        [Index(IsUnique = true)]
        public int Id { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public virtual Score Score { get; set; }
        //public virtual List<PlayerMatchResult> MatchHistory { get; set; }
        public virtual List<Team> Teams { get; set; }
    }
}
