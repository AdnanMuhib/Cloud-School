namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.MailRecipients",
            //    c => new
            //        {
            //            MailRecipientId = c.Int(nullable: false, identity: true),
            //            LastName = c.String(nullable: false),
            //            FirstName = c.String(nullable: false),
            //            Email = c.String(),
            //            Company = c.String(),
            //        })
            //    .PrimaryKey(t => t.MailRecipientId);

            //CreateTable(
            //    "dbo.SentMails",
            //    c => new
            //        {
            //            MailId = c.Int(nullable: false, identity: true),
            //            MailRecipientId = c.Int(nullable: false),
            //            SentToMail = c.String(nullable: false),
            //            SentFromMail = c.String(nullable: false),
            //            SentDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.MailId)
            //    .ForeignKey("dbo.MailRecipients", t => t.MailRecipientId, cascadeDelete: true)
            //    .Index(t => t.MailRecipientId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.SentMails", "MailRecipientId", "dbo.MailRecipients");
            DropIndex("dbo.SentMails", new[] { "MailRecipientId" });
            DropTable("dbo.SentMails");
            DropTable("dbo.MailRecipients");
        }
    }
}
