namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseID2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSections", "CourseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassSections", "CourseID");
        }
    }
}
