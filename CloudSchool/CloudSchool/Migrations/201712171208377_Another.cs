namespace CloudSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Another : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.ClassForStudents",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            year = c.DateTime(nullable: false),
            //            NumberOfSections = c.Int(nullable: false),
            //            SchoolID = c.String(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.ClassSections",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            SectionTitle = c.String(),
            //            ClassName = c.String(),
            //            StartingRegistrationNumber = c.String(),
            //            EndingRegistrationNumber = c.String(),
            //            SchoolID = c.String(),
            //            CourseID = c.Int(nullable: false),
            //            ClassForStudents_ID = c.Int(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.ClassForStudents", t => t.ClassForStudents_ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.ClassForStudents_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.Students",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            LastPassedExam = c.String(),
            //            LastExamTotalMarks = c.Int(nullable: false),
            //            LastExamObtainedMarks = c.String(),
            //            RegistrationNumber = c.String(),
            //            EnrolledClassName = c.String(),
            //            EnrolledSectionName = c.String(),
            //            EmailIDParents = c.String(),
            //            ProfilePicture = c.String(),
            //            SchoolID = c.String(),
            //            CourseID = c.Int(nullable: false),
            //            SectionID = c.Int(nullable: false),
            //            Name = c.String(),
            //            FatherName = c.String(),
            //            DateOfBirth = c.DateTime(nullable: false),
            //            EmailID = c.String(),
            //            CNIC = c.String(),
            //            Password = c.String(),
            //            InstituteName = c.String(),
            //            Address = c.String(),
            //            MobileNumber = c.String(),
            //            Gender = c.String(),
            //            ClassSection_ID = c.Int(),
            //            ClassForStudents_ID = c.Int(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.ClassSections", t => t.ClassSection_ID)
            //    .ForeignKey("dbo.ClassForStudents", t => t.ClassForStudents_ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.ClassSection_ID)
            //    .Index(t => t.ClassForStudents_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.CourseSubjects",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            SubjectTitle = c.String(),
            //            TotalMarks = c.Int(nullable: false),
            //            ObtainedMarks = c.Int(nullable: false),
            //            SchoolID = c.String(),
            //            Student_ID = c.Int(),
            //            Result_ID = c.Int(),
            //            Institute_ID = c.Int(),
            //            Teacher_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Students", t => t.Student_ID)
            //    .ForeignKey("dbo.Results", t => t.Result_ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .ForeignKey("dbo.Teachers", t => t.Teacher_ID)
            //    .Index(t => t.Student_ID)
            //    .Index(t => t.Result_ID)
            //    .Index(t => t.Institute_ID)
            //    .Index(t => t.Teacher_ID);

            //CreateTable(
            //    "dbo.Dashboards",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.Feedbacks",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Subject = c.String(),
            //            Description = c.String(),
            //            SchoolID = c.String(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.Institutes",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            TypeOfInstitute = c.String(),
            //            PhoneNumber = c.String(),
            //            Email = c.String(),
            //            Password = c.String(),
            //            Address = c.String(),
            //            Logo = c.String(),
            //            AccountID = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.Results",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Percentage = c.Double(nullable: false),
            //            RegistrationNumber = c.String(),
            //            SchoolID = c.String(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.Teachers",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Qualification = c.String(),
            //            Experience = c.String(),
            //            ProfilePicture = c.String(),
            //            SchoolID = c.String(),
            //            Name = c.String(),
            //            FatherName = c.String(),
            //            DateOfBirth = c.DateTime(nullable: false),
            //            EmailID = c.String(),
            //            CNIC = c.String(),
            //            Password = c.String(),
            //            InstituteName = c.String(),
            //            Address = c.String(),
            //            MobileNumber = c.String(),
            //            Gender = c.String(),
            //            Institute_ID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Institutes", t => t.Institute_ID)
            //    .Index(t => t.Institute_ID);

            //CreateTable(
            //    "dbo.Notifications",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            EmailIDToNotify = c.String(),
            //            Subject = c.String(),
            //            ContentToNotify = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.CourseSubjects", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.CourseSubjects", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.Students", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.ClassSections", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.Results", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.CourseSubjects", "Result_ID", "dbo.Results");
            DropForeignKey("dbo.Feedbacks", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.ClassForStudents", "Institute_ID", "dbo.Institutes");
            DropForeignKey("dbo.Students", "ClassForStudents_ID", "dbo.ClassForStudents");
            DropForeignKey("dbo.ClassSections", "ClassForStudents_ID", "dbo.ClassForStudents");
            DropForeignKey("dbo.Students", "ClassSection_ID", "dbo.ClassSections");
            DropForeignKey("dbo.CourseSubjects", "Student_ID", "dbo.Students");
            DropIndex("dbo.Teachers", new[] { "Institute_ID" });
            DropIndex("dbo.Results", new[] { "Institute_ID" });
            DropIndex("dbo.Feedbacks", new[] { "Institute_ID" });
            DropIndex("dbo.CourseSubjects", new[] { "Teacher_ID" });
            DropIndex("dbo.CourseSubjects", new[] { "Institute_ID" });
            DropIndex("dbo.CourseSubjects", new[] { "Result_ID" });
            DropIndex("dbo.CourseSubjects", new[] { "Student_ID" });
            DropIndex("dbo.Students", new[] { "Institute_ID" });
            DropIndex("dbo.Students", new[] { "ClassForStudents_ID" });
            DropIndex("dbo.Students", new[] { "ClassSection_ID" });
            DropIndex("dbo.ClassSections", new[] { "Institute_ID" });
            DropIndex("dbo.ClassSections", new[] { "ClassForStudents_ID" });
            DropIndex("dbo.ClassForStudents", new[] { "Institute_ID" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Teachers");
            DropTable("dbo.Results");
            DropTable("dbo.Institutes");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Dashboards");
            DropTable("dbo.CourseSubjects");
            DropTable("dbo.Students");
            DropTable("dbo.ClassSections");
            DropTable("dbo.ClassForStudents");
        }
    }
}
