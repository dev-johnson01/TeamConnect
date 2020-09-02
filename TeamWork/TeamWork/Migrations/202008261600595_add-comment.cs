namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        EmployeeComment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.EmployeeArticles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.EmployeeArticles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(),
                        gif = c.String(),
                        ArticleBody = c.String(),
                        GifUrl = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ProfileeImageurl = c.String(),
                        EmployeeGender = c.Int(nullable: false),
                        EmployeeDepartment = c.Int(nullable: false),
                        JobRole = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeArticles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.EmployeeArticles");
            DropIndex("dbo.EmployeeArticles", new[] { "EmployeeId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeArticles");
            DropTable("dbo.Comments");
        }
    }
}
