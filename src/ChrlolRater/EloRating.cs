using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ChrlolRater
{
    public class EloRating
    {
        private const int K = 50;
        public static TeamMatchResult GetResult(TeamMatchResult result)
        {
            var winningRating = result.WinningEntity.Score.Rating;
            var loosingRating = result.LosingEntity.Score.Rating;
            var winningScore = result.WinningScore;
            var loosingScore = result.LoosingScore;

            int winningResult, loosingResult;
            double e = 0;

            if (winningScore != loosingScore)
            {
                if (winningScore > loosingScore)
                {
                    e = K - (int)Math.Round(1 / (1 + Math.Pow(10, ((loosingRating - winningRating) / 400))) * K);
                    winningResult = (int)(winningRating + e);
                    loosingResult = (int)(loosingRating - e);
                }
                else
                {
                    e = K - (int)Math.Round(1 / (1 + Math.Pow(10, ((winningRating - loosingRating) / 400))) * K);
                    winningResult = (int)(winningRating - e);
                    loosingResult = (int)(loosingRating + e);
                }
            }
            else
            {
                if (winningRating == loosingRating)
                {
                    winningResult = winningRating;
                    loosingResult = loosingRating;
                }
                else
                {
                    if (winningRating > loosingRating)
                    {
                        e = (K - Math.Round(1 / (1 + Math.Pow(10, ((winningRating - loosingRating) / 400))) * K)) - (K - Math.Round(1 / (1 + Math.Pow(10, ((loosingRating - winningRating) / 400))) * K));
                        winningResult = (int)(winningRating - e);
                        loosingResult = (int)(loosingRating + e);
                    }
                    else
                    {
                        e = (K - Math.Round(1 / (1 + Math.Pow(10, ((loosingRating - winningRating) / 400))) * K)) - (K - Math.Round(1 / (1 + Math.Pow(10, ((winningRating - loosingRating) / 400))) * K));
                        winningResult = (int)(winningRating + e);
                        loosingResult = (int)(loosingRating - e);
                    }
                }
            }
            result.RatingChange = Math.Abs(winningResult - winningRating);

            // Winning Player should not loose rating...
            if (result.WinningEntity.Score.Rating < winningResult)
            {
                result.WinningEntity.Score.Rating = winningResult;
                result.LosingEntity.Score.Rating = loosingResult;
            }
            else
            {
                result.RatingChange = 0;
            }

            result.WinningEntity.Score.Wins++;
            result.LosingEntity.Score.Losses++;

            return result;
        }

        public static PlayerMatchResult GetResult(PlayerMatchResult result)
        {
            var currentRating1 = result.WinningEntity.Score.Rating;
            var currentRating2 = result.LosingEntity.Score.Rating;
            var score1 = result.WinningScore;
            var score2 = result.LoosingScore;

            int winningResult, loosingResult;
            double e = 0;

            if (score1 != score2)
            {
                if (score1 > score2)
                {
                    e = K - (int)Math.Round(1 / (1 + Math.Pow(10, ((currentRating2 - currentRating1) / 400))) * K);
                    winningResult = (int)(currentRating1 + e);
                    loosingResult = (int)(currentRating2 - e);
                }
                else
                {
                    e = K - (int)Math.Round(1 / (1 + Math.Pow(10, ((currentRating1 - currentRating2) / 400))) * K);
                    winningResult = (int)(currentRating1 - e);
                    loosingResult = (int)(currentRating2 + e);
                }
            }
            else
            {
                if (currentRating1 == currentRating2)
                {
                    winningResult = currentRating1;
                    loosingResult = currentRating2;
                }
                else
                {
                    if (currentRating1 > currentRating2)
                    {
                        e = (K - Math.Round(1 / (1 + Math.Pow(10, ((currentRating1 - currentRating2) / 400))) * K)) - (K - Math.Round(1 / (1 + Math.Pow(10, ((currentRating2 - currentRating1) / 400))) * K));
                        winningResult = (int)(currentRating1 - e);
                        loosingResult = (int)(currentRating2 + e);
                    }
                    else
                    {
                        e = (K - Math.Round(1 / (1 + Math.Pow(10, ((currentRating2 - currentRating1) / 400))) * K)) - (K - Math.Round(1 / (1 + Math.Pow(10, ((currentRating1 - currentRating2) / 400))) * K));
                        winningResult = (int)(currentRating1 + e);
                        loosingResult = (int)(currentRating2 - e);
                    }
                }
            }
            result.RatingChange = Math.Abs(winningResult - currentRating1);

            if (result.WinningEntity.Score.Rating < winningResult)
            {
                result.WinningEntity.Score.Rating = winningResult;
                result.LosingEntity.Score.Rating = loosingResult;
            }
            else
            {
                result.RatingChange = 0;
            }

            result.WinningEntity.Score.Wins++;
            result.LosingEntity.Score.Losses++;

            return result;
        }
    }
}
