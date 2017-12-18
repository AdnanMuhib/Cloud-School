namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserID", c => c.String());
            AddColumn("dbo.Teachers", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "UserID");
            DropColumn("dbo.Students", "UserID");
        }
    }
}
