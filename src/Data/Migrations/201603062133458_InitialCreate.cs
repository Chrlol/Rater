namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerMatchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                        WinningScore = c.Int(nullable: false),
                        LoosingScore = c.Int(nullable: false),
                        RatingChange = c.Int(nullable: false),
                        LosingEntity_Id = c.Int(),
                        WinningEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.LosingEntity_Id)
                .ForeignKey("dbo.Players", t => t.WinningEntity_Id)
                .Index(t => t.LosingEntity_Id)
                .Index(t => t.WinningEntity_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                        Score_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scores", t => t.Score_Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Score_Id);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                        Score_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scores", t => t.Score_Id)
                .Index(t => t.Id, unique: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Score_Id);
            
            CreateTable(
                "dbo.TeamMatchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchTime = c.DateTime(nullable: false),
                        WinningScore = c.Int(nullable: false),
                        LoosingScore = c.Int(nullable: false),
                        RatingChange = c.Int(nullable: false),
                        LosingEntity_Id = c.Int(),
                        WinningEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.LosingEntity_Id)
                .ForeignKey("dbo.Teams", t => t.WinningEntity_Id)
                .Index(t => t.LosingEntity_Id)
                .Index(t => t.WinningEntity_Id);
            
            CreateTable(
                "dbo.TeamPlayers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Player_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Player_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Player_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMatchResults", "WinningEntity_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamMatchResults", "LosingEntity_Id", "dbo.Teams");
            DropForeignKey("dbo.PlayerMatchResults", "WinningEntity_Id", "dbo.Players");
            DropForeignKey("dbo.PlayerMatchResults", "LosingEntity_Id", "dbo.Players");
            DropForeignKey("dbo.Teams", "Score_Id", "dbo.Scores");
            DropForeignKey("dbo.TeamPlayers", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.TeamPlayers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Players", "Score_Id", "dbo.Scores");
            DropIndex("dbo.TeamPlayers", new[] { "Player_Id" });
            DropIndex("dbo.TeamPlayers", new[] { "Team_Id" });
            DropIndex("dbo.TeamMatchResults", new[] { "WinningEntity_Id" });
            DropIndex("dbo.TeamMatchResults", new[] { "LosingEntity_Id" });
            DropIndex("dbo.Teams", new[] { "Score_Id" });
            DropIndex("dbo.Teams", new[] { "Name" });
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.Players", new[] { "Score_Id" });
            DropIndex("dbo.Players", new[] { "Name" });
            DropIndex("dbo.Players", new[] { "Id" });
            DropIndex("dbo.PlayerMatchResults", new[] { "WinningEntity_Id" });
            DropIndex("dbo.PlayerMatchResults", new[] { "LosingEntity_Id" });
            DropTable("dbo.TeamPlayers");
            DropTable("dbo.TeamMatchResults");
            DropTable("dbo.Teams");
            DropTable("dbo.Scores");
            DropTable("dbo.Players");
            DropTable("dbo.PlayerMatchResults");
        }
    }
}
