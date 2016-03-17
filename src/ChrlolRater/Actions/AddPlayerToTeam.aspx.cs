using System;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater.Actions
{
    public partial class AddPlayerToTeam : Page
    {
        public Team Team { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int teamId;
            if (int.TryParse(Request.QueryString["TeamID"], out teamId))
            {
                using (var db = new ChrlolRaterContext())
                {
                    Team = db.GetTeam(teamId);
                    foreach (Player player in db.PlayersNotInTeam(Team))
                    {
                        AvailablePlayers.Items.Add(player.Name);
                    }
                }
            }
        }

        protected void AddPlayerToTeam_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AvailablePlayers.SelectedValue))
            {
                using (var db = new ChrlolRaterContext())
                {
                    Player player = db.GetPlayer(AvailablePlayers.SelectedValue);

                    Team = db.GetTeam(Team.Id);

                    Team.Members.Add(player);
                    player.Teams.Add(Team);

                    db.SaveChanges();
                    Response.Redirect("/TeamPage.aspx?ID=" + Team.Id);
                }
            }
        }
    }
}