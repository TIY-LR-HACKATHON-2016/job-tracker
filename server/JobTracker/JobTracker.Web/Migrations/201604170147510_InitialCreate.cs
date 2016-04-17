namespace JobTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyTitle = c.String(nullable: false),
                        Url = c.String(),
                        JobTitle = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                        StatusDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Job_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Resume = c.String(nullable: false),
                        CoverLetter = c.String(),
                        Address = c.String(),
                        PhoneNum = c.String(),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Interviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Interviews", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Interviews", new[] { "User_Id" });
            DropIndex("dbo.Interviews", new[] { "Job_Id" });
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Interviews");
            DropTable("dbo.Jobs");
        }
    }
}
