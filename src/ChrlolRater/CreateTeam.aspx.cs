using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater
{
    public partial class CreateTeam : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            if (AvailablePlayers.SelectedItem != null)
            {
                var itemToMove = AvailablePlayers.SelectedItem;
                itemToMove.Selected = false;
                SelectedPlayers.Items.Add(itemToMove);
                AvailablePlayers.Items.Remove(itemToMove);
            }
        }

        protected void RemovePlayer_Click(object sender, EventArgs e)
        {
            if (SelectedPlayers.SelectedItem != null)
            {
                var itemToMove = SelectedPlayers.SelectedItem;
                itemToMove.Selected = false;
                AvailablePlayers.Items.Add(itemToMove);
                SelectedPlayers.Items.Remove(itemToMove);
            }
        }

        protected void CreateTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateTeam())
            {
                CreateTheTeam();
            }
        }

        private void CreateTheTeam()
        {
            using (var db = new ChrlolRaterContext())
            {
                List<Player> members = (from object playerString in SelectedPlayers.Items
                                        select playerString.ToString() into name
                                        select db.Players.First(x => x.Name == name)).ToList();
                Team team = DataFactory.NewTeam(TeamNameBox.Text);
                foreach (var member in members)
                {
                    member.Teams.Add(team);
                    db.Players.AddOrUpdate(member);
                }
                team.Members = members;
                db.Teams.Add(team);
                db.SaveChanges();

                TeamCreationSuccess.Text = $"Team named: {TeamNameBox.Text} has been created members: {members.Select(x => x.Name).Aggregate((x,y) => x + ", " + y)}";
            }
        }

        private bool ValidateTeam()
        {
            if (!ValidateTeamName())
                return false;
            if (SelectedPlayers.Items.Count >= 2)
                return true;
            TeamValidation.Text = "A Team must consist of 2 players or more";
            return false;
        }
        private bool ValidateTeamName()
        {
            var name = TeamNameBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                TeamNameValidation.Text = "Enter a name";
                return false;
            }
            using (var db = new ChrlolRaterContext())
            {
                if (db.Teams.Any(x => x.Name == name))
                {
                    TeamNameValidation.Text = "Team with that name already exists";
                    return false;
                }
            }
            TeamNameValidation.Text = "";
            return true;
        }
    }
}