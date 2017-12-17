namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSubjects", "CourseID", c => c.String());
            AddColumn("dbo.CourseSubjects", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseSubjects", "CourseName");
            DropColumn("dbo.CourseSubjects", "CourseID");
        }
    }
}
