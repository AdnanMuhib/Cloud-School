namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IEnumberable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EnrolledSectionName", c => c.String());
            DropColumn("dbo.Students", "EnrolledClassName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "EnrolledClassName", c => c.String());
            DropColumn("dbo.Students", "EnrolledSectionName");
        }
    }
}
