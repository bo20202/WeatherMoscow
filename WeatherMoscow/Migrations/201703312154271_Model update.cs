namespace WeatherMoscow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weathers", "Time", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Weathers", "AirTemp", c => c.Double());
            AlterColumn("dbo.Weathers", "Moisture", c => c.Double());
            AlterColumn("dbo.Weathers", "DewPoint", c => c.Double());
            AlterColumn("dbo.Weathers", "Pressure", c => c.Int());
            AlterColumn("dbo.Weathers", "Cloudness", c => c.Int());
            AlterColumn("dbo.Weathers", "CloudBase", c => c.Int());
            AlterColumn("dbo.Weathers", "HorizontalVisibility", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weathers", "HorizontalVisibility", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "CloudBase", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "Cloudness", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "Pressure", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "DewPoint", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "Moisture", c => c.Int(nullable: false));
            AlterColumn("dbo.Weathers", "AirTemp", c => c.Int(nullable: false));
            DropColumn("dbo.Weathers", "Time");
        }
    }
}
