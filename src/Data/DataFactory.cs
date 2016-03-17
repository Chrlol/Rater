using System;
using System.Collections.Generic;

namespace Data
{
    public class DataFactory
    {
        public static Player NewPlayer(string name = "")
        {
            return new Player
            {
                Name = name,
                //MatchHistory = new List<PlayerMatchResult>(),
                Score = NewScore(),
                Teams = new List<Team>()
            };
        }
        public static Score NewScore()
        {
            return new Score
            {
                Losses = 0,
                Wins = 0,
                Rating = 1500
            };
        }
        public static Team NewTeam(string name = "")
        {
            return new Team
            {
                Name = name,
                //MatchHistory = new List<TeamMatchResult>(),
                Members = new List<Player>(),
                Score = NewScore()
            };
        }
        public static TeamMatchResult NewTeamMatchResult()
        {
            return new TeamMatchResult
            {
                MatchTime = DateTime.Now
            };
        }

        public static PlayerMatchResult NewPlayerMatchResult()
        {
            return new PlayerMatchResult
            {
                MatchTime = DateTime.Now
            };
        }
    }
}
