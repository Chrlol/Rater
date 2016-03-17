using System;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater
{
    public partial class CreatePlayer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreatePlayerButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerNameText.Text))
            {
                using (var db = new ChrlolRaterContext())
                {
                    if (!db.Players.Any(x => x.Name.Equals(PlayerNameText.Text)))
                    {
                        db.Players.Add(DataFactory.NewPlayer(PlayerNameText.Text));
                        db.SaveChanges();
                        Success.Visible = true;
                        Failure.Visible = false;
                        Success.Text = PlayerNameText.Text + " Created";
                    }
                    else
                    {
                        Failure.Visible = true;
                        Success.Visible = false;
                        Failure.Text = "Player with the name '" + PlayerNameText.Text + "' Already Exists";
                    }
                }
            }
            else
            {
                Failure.Visible = true;
                Success.Visible = false;
                Failure.Text = "Invalid Player Name";
            }
        }
    }
}