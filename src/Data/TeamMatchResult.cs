using System;

namespace Data
{
    public class TeamMatchResult
    {
        public int Id { get; set; }
        public DateTime MatchTime { get; set; }
        public virtual Team WinningEntity { get; set; }
        public int WinningScore { get; set; }
        public virtual Team LosingEntity { get; set; }
        public int LoosingScore { get; set; }
        public int RatingChange { get; set; }
    }
}