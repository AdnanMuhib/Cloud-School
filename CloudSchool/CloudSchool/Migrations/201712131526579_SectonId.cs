namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SectonId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "SectionID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SectionID");
        }
    }
}
