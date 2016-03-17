using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater
{
    public partial class RemovePlayerFromTeam : Page
    {
        public Team Team { get; set; }
        public Player Player { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int playerId, teamId;
                if (int.TryParse(Request.QueryString["PlayerID"], out playerId) && int.TryParse(Request.QueryString["TeamID"], out teamId))
                    using (var db = new ChrlolRaterContext())
                    {
                        Team = db.GetTeam(teamId);
                        Player = db.GetPlayer(playerId);
                        Team.Members.ToString();
                        Player.Teams.ToString();
                    }
                else
                {
                    Populate();
                }
            }
            catch (Exception exception)
            {
                Error.Text = "Der er sket en Fejl, ID'er findes nok ikke i databasen" + exception;
                Populate();
            }
        }

        private void Populate()
        {
            YesButton.Visible = false;
            NoButton.Visible = false;
            Team = DataFactory.NewTeam("");
            Player = DataFactory.NewPlayer("");
        }

        protected void YesButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ChrlolRaterContext())
                {
                    Team = db.GetTeam(Team.Id);
                    Player = db.GetPlayer(Player.Id);
                    Team.Members.Remove(Player);
                    Player.Teams.Remove(Team);
                    db.Teams.AddOrUpdate(Team);
                    db.Players.AddOrUpdate(Player);
                    db.SaveChanges();
                    Response.Redirect("/TeamPage.aspx?ID=" + Team.Id);
                }
            }
            catch (Exception)
            {
                Error.Text = "Kunne ikke fjerne spiller";
            }
            finally
            {
                YesButton.Visible = false;
                NoButton.Visible = false;
            }
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TeamPage.aspx?ID=" + Team.Id);
        }
    }
}