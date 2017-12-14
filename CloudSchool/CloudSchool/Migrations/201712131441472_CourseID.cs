namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "CourseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "CourseID");
        }
    }
}
