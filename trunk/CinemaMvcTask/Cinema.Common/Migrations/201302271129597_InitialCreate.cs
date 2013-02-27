namespace CinemaCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        MaxSeats = c.Int(nullable: false),
                        ReservedSeats = c.Int(nullable: false),
                        Name = c.String(),
                        CinemaId = c.Int(nullable: false),
                        MovieId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .Index(t => t.CinemaId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rooms", new[] { "MovieId" });
            DropIndex("dbo.Rooms", new[] { "CinemaId" });
            DropForeignKey("dbo.Rooms", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Rooms", "CinemaId", "dbo.Cinemas");
            DropTable("dbo.Movies");
            DropTable("dbo.Rooms");
            DropTable("dbo.Cinemas");
        }
    }
}
