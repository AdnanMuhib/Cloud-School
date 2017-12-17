namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSubjects", "TeacherID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseSubjects", "TeacherID");
        }
    }
}
