using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater
{
    public partial class PlayerPage : Page
    {
        public Player Player { get; set; }
        public List<Team> Teams { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(Request.QueryString["ID"], out id))
                using (var db = new ChrlolRaterContext())
                {
                    Player = db.GetPlayer(id);
                    if (Player == null)
                        Player = DataFactory.NewPlayer("");
                    else
                        Player.Score.ToString();
                    Teams = Player.Teams.ToList();
                    TeamsRepeater.DataSource = Teams;
                    TeamsRepeater.DataBind();
                    //HistoryRepeater.DataSource = Player.MatchHistory;
                    //HistoryRepeater.DataBind();
                }
            else
            {
                Player = DataFactory.NewPlayer("");
            }
        }
    }
}