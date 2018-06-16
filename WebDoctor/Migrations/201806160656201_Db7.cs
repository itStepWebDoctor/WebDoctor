namespace WebDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientRecordings", "ClientMail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientRecordings", "ClientMail");
        }
    }
}
