using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace ChrlolRater
{
    public partial class LogMatch : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //PopulatePlayerListDefault(Team1SelectPlayers);
                //PopulatePlayerListDefault(Team2SelectPlayers);
            }
        }
        protected void PlayerMatchSubmitButton_Click(object sender, EventArgs e)
        {
            int player1Score;
            int player2Score;
            if(!int.TryParse(Player1ScoreBox.Text, out player1Score) || !int.TryParse(Player2ScoreBox.Text, out player2Score))
            {
                // TODO: Show Error Message
                return;
            }
            using (var db = new ChrlolRaterContext())
            {
                Player player1 = db.GetPlayer(Player1DropDown.SelectedValue);
                Player player2 = db.GetPlayer(Player2DropDown.SelectedValue);

                if (player1 == null || player2 == null)
                {
                    // TODO: Show Error Message
                    return;
                }
                PlayerMatchResult result = DataFactory.NewPlayerMatchResult();

                // Player 1 win:
                if (player1Score > player2Score)
                {
                    result.WinningEntity = player1;
                    result.WinningScore = player1Score;

                    result.LosingEntity = player2;
                    result.LoosingScore = player2Score;
                }
                // Player 2 Win:
                else
                {
                    result.WinningEntity = player2;
                    result.WinningScore = player2Score;

                    result.LosingEntity = player1;
                    result.LoosingScore = player1Score;
                }
                result = EloRating.GetResult(result);
                db.PlayerMatchHistory.Add(result);
                db.SaveChanges();
            }
        }

        protected void TeamMatchSubmitButton_Click(object sender, EventArgs e)
        {
            int team1Score;
            int team2Score;
            if (!int.TryParse(Team1Scorebox.Text, out team1Score) || !int.TryParse(Team2Scorebox.Text, out team2Score))
            {
                // TODO: Show Error Message
                return;
            }
            using (var db = new ChrlolRaterContext())
            {
                // Team Rating Handling
                Team team1 = db.GetTeam(Team1DropDown.SelectedValue);
                Team team2 = db.GetTeam(Team1DropDown.SelectedValue);
                if (team1 == null || team2 == null)
                {
                    // TODO: Show Error Message
                    return;
                }
                TeamMatchResult result = DataFactory.NewTeamMatchResult();

                // Team 1 win:
                if (team1Score > team2Score)
                {
                    result.WinningEntity = team1;
                    result.WinningScore = team1Score;
                    
                    result.LosingEntity = team2;
                    result.LoosingScore = team2Score;
                }
                // Team 2 Win:
                else
                {
                    result.WinningEntity = team2;
                    result.WinningScore = team2Score;
                    
                    result.LosingEntity = team1;
                    result.LoosingScore = team1Score;
                }
                result = EloRating.GetResult(result);
                db.TeamMatchHistory.Add(result);

                // Player Rating Handling
                //Log.Items.Add(Team2SelectPlayers.SelectedItem.Value);

                db.SaveChanges();
            }
        }

        protected void Team1DropDown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulatePlayerList(Team1SelectPlayers, Team1DropDown);
        }

        protected void Team2DropDown_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulatePlayerList(Team2SelectPlayers, Team2DropDown);
        }

        private void PopulatePlayerList(CheckBoxList checkBoxList, DropDownList dropDown)
        {
            checkBoxList.Items.Clear();
            using (var db = new ChrlolRaterContext())
            {
                Team team = db.GetTeam(dropDown.SelectedValue);
                if (team == null)
                    return;
                foreach (Player player in team.Members)
                {
                    checkBoxList.Items.Add(player.Name);
                }
            }
        }

        private void PopulatePlayerListDefault(CheckBoxList checkBoxList)
        {
            checkBoxList.Items.Clear();
            using (var db = new ChrlolRaterContext())
            {
                Team team = db.Teams.First();
                if (team == null)
                    return;
                foreach (Player player in team.Members)
                {
                    checkBoxList.Items.Add(player.Name);
                }
            }
        }
    }
}