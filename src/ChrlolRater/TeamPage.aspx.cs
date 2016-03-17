using System;
using System.Linq;
using System.Web.UI;
using Data;

namespace ChrlolRater
{
	public partial class TeamPage : Page
	{
        public Team Team { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
            int id;
		    if (int.TryParse(Request.QueryString["ID"], out id))
		    {
		        using (var db = new ChrlolRaterContext())
		        {
		            Team = db.GetTeam(id);
		            if (Team == null)
                        Team = DataFactory.NewTeam("");
                    else
                    {
                        Team.Score.ToString();
                        MembersRepeater.DataSource = Team.Members;
                        MembersRepeater.DataBind();
                    }
		        }
		    }
		    else
		    {
		        Team = DataFactory.NewTeam("");
		    }
        }
	}
}