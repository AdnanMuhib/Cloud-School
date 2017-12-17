namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSubjects", "TeacherRegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseSubjects", "TeacherRegistrationNumber");
        }
    }
}
