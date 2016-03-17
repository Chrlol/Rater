using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChrlolRater.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = DataFactory.NewTeamMatchResult();
            result.WinningScore = 10;
            result.LoosingScore = 5;
            result.WinningEntity = DataFactory.NewTeam("Winning Team");
            result.LosingEntity = DataFactory.NewTeam("Loosing Team");
            result.WinningEntity.Score.Rating = 2100;
            result.LosingEntity.Score.Rating = 100;

            EloRating.GetResult(result);
        }
    }
}
