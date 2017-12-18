namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "StudentRegistration", c => c.String());
            AddColumn("dbo.Results", "SubjectName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "SubjectName");
            DropColumn("dbo.Results", "StudentRegistration");
        }
    }
}
