namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
    }
}
