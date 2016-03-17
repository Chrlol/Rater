using System;

namespace Data
{
    public class PlayerMatchResult
    {
        public int Id { get; set; }
        public DateTime MatchTime { get; set; }
        public virtual Player WinningEntity { get; set; }
        public int WinningScore { get; set; }
        public virtual Player LosingEntity { get; set; }
        public int LoosingScore { get; set; }
        public int RatingChange { get; set; }
    }
}