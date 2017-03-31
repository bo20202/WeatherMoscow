namespace WeatherMoscow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        AirTemp = c.Int(nullable: false),
                        Moisture = c.Int(nullable: false),
                        DewPoint = c.Int(nullable: false),
                        Pressure = c.Int(nullable: false),
                        WindDir = c.String(),
                        WindSpeed = c.Int(),
                        Cloudness = c.Int(nullable: false),
                        CloudBase = c.Int(nullable: false),
                        HorizontalVisibility = c.Int(nullable: false),
                        WeatherConditions = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weathers");
        }
    }
}
