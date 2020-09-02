namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gifdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeArticles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeArticles", new[] { "EmployeeId" });
            CreateTable(
                "dbo.EmployeeGifs",
                c => new
                    {
                        EmployeeGifId = c.Int(nullable: false, identity: true),
                        GifTitle = c.String(),
                        PostedBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        GifUrl = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeGifId);
            
            CreateTable(
                "dbo.GifComments",
                c => new
                    {
                        GifCommentId = c.Int(nullable: false, identity: true),
                        EmployeeGifComment = c.String(nullable: false),
                        PostedBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        EmployeeGifId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GifCommentId)
                .ForeignKey("dbo.EmployeeGifs", t => t.EmployeeGifId, cascadeDelete: true)
                .Index(t => t.EmployeeGifId);
            
            AddColumn("dbo.Comments", "PostedBy", c => c.String());
            AddColumn("dbo.EmployeeArticles", "PostedBy", c => c.String());
            AddColumn("dbo.EmployeeArticles", "Image", c => c.String());
            AlterColumn("dbo.Comments", "EmployeeComment", c => c.String(nullable: false));
            DropColumn("dbo.EmployeeArticles", "gif");
            DropColumn("dbo.EmployeeArticles", "GifUrl");
            DropColumn("dbo.EmployeeArticles", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeArticles", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeArticles", "GifUrl", c => c.String());
            AddColumn("dbo.EmployeeArticles", "gif", c => c.String());
            DropForeignKey("dbo.GifComments", "EmployeeGifId", "dbo.EmployeeGifs");
            DropIndex("dbo.GifComments", new[] { "EmployeeGifId" });
            AlterColumn("dbo.Comments", "EmployeeComment", c => c.String());
            DropColumn("dbo.EmployeeArticles", "Image");
            DropColumn("dbo.EmployeeArticles", "PostedBy");
            DropColumn("dbo.Comments", "PostedBy");
            DropTable("dbo.GifComments");
            DropTable("dbo.EmployeeGifs");
            CreateIndex("dbo.EmployeeArticles", "EmployeeId");
            AddForeignKey("dbo.EmployeeArticles", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
