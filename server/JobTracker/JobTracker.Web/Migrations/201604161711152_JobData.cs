namespace JobTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Status");
        }
    }
}
