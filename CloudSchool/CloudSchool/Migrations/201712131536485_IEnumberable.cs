namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IEnumberable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "EnrolledSectionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "EnrolledSectionName", c => c.String());
        }
    }
}
