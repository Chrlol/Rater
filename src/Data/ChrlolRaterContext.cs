using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data
{
    public class ChrlolRaterContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMatchResult> TeamMatchHistory { get; set; }
        public DbSet<PlayerMatchResult> PlayerMatchHistory { get; set; }
        public Player GetPlayer(int id)
        {
            return Players.First(x => x.Id == id);
        }

        public Player GetPlayer(string name)
        {
            return Players.First(x => x.Name == name);
        }

        public Team GetTeam(int id)
        {   
            return Teams.First(x => x.Id == id);
        }

        public Team GetTeam(string name)
        {
            return Teams.First(x => x.Name == name);
        }

        public IQueryable<Player> PlayersNotInTeam(Team team)
        {
            return Players.Where(x => !team.Members.Contains(x));
        }

        public IQueryable<Player> PlayersRatingOver(int rating)
        {
            return Players.Where(x => x.Score.Rating > rating);
        }

        public IQueryable<Player> PlayersPositiveKd()
        {
            return Players.Where(x => x.Score.Wins > x.Score.Losses);
        }

        public IQueryable<Player> PlayersNegativeKd()
        {
            return Players.Where(x => x.Score.Wins < x.Score.Losses);
        }

        public Player PlayerMostWins()
        {
            return Players.OrderByDescending(x => x.Score.Wins).First();
        }

        public Player PlayerFewestWins()
        {
            return Players.OrderBy(x => x.Score.Wins).First();
        }

        public Player PlayerMostLosses()
        {
            return Players.OrderByDescending(x => x.Score.Losses).First();
        }

        public Player PlayerFewestLosses()
        {
            return Players.OrderBy(x => x.Score.Losses).First();
        }

        public Team TeamMostWins()
        {
            return Teams.OrderByDescending(x => x.Score.Wins).First();
        }

        public Team TeamFewestWins()
        {
            return Teams.OrderBy(x => x.Score.Wins).First();
        }

        public Team TeamMostLosses()
        {
            return Teams.OrderByDescending(x => x.Score.Losses).First();
        }

        public Team TeamFewestLosses()
        {
            return Teams.OrderBy(x => x.Score.Losses).First();
        }

        public Player BestPlayer()
        {
            return Players.OrderByDescending(x => x.Score.Rating).First();
        }

        public Player WorstPlayer()
        {
            return Players.OrderBy(x => x.Score.Rating).First();
        }

        public double AverageScore(Player player)
        {
            return PlayerMatchHistory
                .Where(x => x.LosingEntity.Id == player.Id || x.WinningEntity.Id == player.Id)
                .Select(x => x.LosingEntity.Id == player.Id ? x.LoosingScore : x.WinningScore).Average();
        }

        public double AverageScore(Team team)
        {
            return TeamMatchHistory
                .Where(x => x.LosingEntity.Id == team.Id || x.WinningEntity.Id == team.Id)
                .Select(x => x.LosingEntity.Id == team.Id ? x.LoosingScore : x.WinningScore).Average();
        }

        public IEnumerable<PlayerMatchResult> GetMatchHistory(Player player)
        {
            return PlayerMatchHistory
                .Where(x => x.WinningEntity.Id == player.Id || x.LosingEntity.Id == player.Id);
        }

        public IEnumerable<PlayerMatchResult> GetMatchHistory(Team team)
        {
            return PlayerMatchHistory
                .Where(x => x.WinningEntity.Id == team.Id || x.LosingEntity.Id == team.Id);
        }
    }
}