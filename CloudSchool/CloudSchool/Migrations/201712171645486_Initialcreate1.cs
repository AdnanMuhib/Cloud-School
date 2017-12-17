namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseSubjects", "TeacherRegNo", c => c.String());
            AddColumn("dbo.Teachers", "RegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "RegistrationNumber");
            DropColumn("dbo.CourseSubjects", "TeacherRegNo");
        }
    }
}
