namespace WebDoctor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB6 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ClientRecordings",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            Date = c.DateTime(nullable: false),
            //            Time = c.Time(nullable: false, precision: 7),
            //            Specialisation = c.String(nullable: false),
            //            DoctorName = c.String(nullable: false),
            //            AdditionalInfo = c.String(),
            //            Status = c.Boolean(nullable: false),
            //            ClientName = c.String(),
            //            Diagnos = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClientRecordings");
        }
    }
}
