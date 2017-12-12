namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassForStudents", "SchoolID", c => c.String());
            AddColumn("dbo.ClassSections", "SchoolID", c => c.String());
            AddColumn("dbo.Students", "SchoolID", c => c.String());
            AddColumn("dbo.CourseSubjects", "SchoolID", c => c.String());
            AddColumn("dbo.Feedbacks", "SchoolID", c => c.String());
            AddColumn("dbo.Results", "SchoolID", c => c.String());
            AddColumn("dbo.Teachers", "SchoolID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "SchoolID");
            DropColumn("dbo.Results", "SchoolID");
            DropColumn("dbo.Feedbacks", "SchoolID");
            DropColumn("dbo.CourseSubjects", "SchoolID");
            DropColumn("dbo.Students", "SchoolID");
            DropColumn("dbo.ClassSections", "SchoolID");
            DropColumn("dbo.ClassForStudents", "SchoolID");
        }
    }
}
