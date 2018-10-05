namespace CodeFirstExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Admin.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "Admin.StudentInfo",
                c => new
                    {
                        StudentKey = c.Int(nullable: false, identity: true),
                        StudentName = c.String(maxLength: 50, fixedLength: true),
                        Grade_GradeKey = c.Int(),
                        Standard_StandardKey = c.Int(),
                    })
                .PrimaryKey(t => t.StudentKey)
                .ForeignKey("Admin.GradeInfo", t => t.Grade_GradeKey)
                .ForeignKey("Admin.Standards", t => t.Standard_StandardKey)
                .Index(t => t.Grade_GradeKey)
                .Index(t => t.Standard_StandardKey);
            
            CreateTable(
                "Admin.GradeInfo",
                c => new
                    {
                        GradeKey = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.GradeKey);
            
            CreateTable(
                "Admin.StudentAddresses",
                c => new
                    {
                        StudentAddressId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.StudentAddressId)
                .ForeignKey("Admin.StudentInfo", t => t.StudentAddressId)
                .Index(t => t.StudentAddressId);
            
            CreateTable(
                "Admin.Standards",
                c => new
                    {
                        StandardKey = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StandardKey);
            
            CreateTable(
                "Admin.StudentCourses",
                c => new
                    {
                        Student_StudentKey = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentKey, t.Course_CourseId })
                .ForeignKey("Admin.StudentInfo", t => t.Student_StudentKey, cascadeDelete: true)
                .ForeignKey("Admin.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentKey)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "Admin.StudentInfoDetail",
                c => new
                    {
                        DoB = c.DateTime(precision: 7, storeType: "datetime2"),
                        StudentKey = c.Int(nullable: false),
                        Photo = c.Binary(),
                        Height = c.Decimal(precision: 5, scale: 2),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.StudentKey)
                .ForeignKey("Admin.StudentInfo", t => t.StudentKey)
                .Index(t => t.StudentKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Admin.StudentInfoDetail", "StudentKey", "Admin.StudentInfo");
            DropForeignKey("Admin.StudentInfo", "Standard_StandardKey", "Admin.Standards");
            DropForeignKey("Admin.StudentAddresses", "StudentAddressId", "Admin.StudentInfo");
            DropForeignKey("Admin.StudentInfo", "Grade_GradeKey", "Admin.GradeInfo");
            DropForeignKey("Admin.StudentCourses", "Course_CourseId", "Admin.Courses");
            DropForeignKey("Admin.StudentCourses", "Student_StudentKey", "Admin.StudentInfo");
            DropIndex("Admin.StudentInfoDetail", new[] { "StudentKey" });
            DropIndex("Admin.StudentCourses", new[] { "Course_CourseId" });
            DropIndex("Admin.StudentCourses", new[] { "Student_StudentKey" });
            DropIndex("Admin.StudentAddresses", new[] { "StudentAddressId" });
            DropIndex("Admin.StudentInfo", new[] { "Standard_StandardKey" });
            DropIndex("Admin.StudentInfo", new[] { "Grade_GradeKey" });
            DropTable("Admin.StudentInfoDetail");
            DropTable("Admin.StudentCourses");
            DropTable("Admin.Standards");
            DropTable("Admin.StudentAddresses");
            DropTable("Admin.GradeInfo");
            DropTable("Admin.StudentInfo");
            DropTable("Admin.Courses");
        }
    }
}
