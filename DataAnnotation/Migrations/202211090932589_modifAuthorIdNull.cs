namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifAuthorIdNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors");
            DropIndex("dbo.t_Course", new[] { "AuthorId" });
            AlterColumn("dbo.t_Course", "AuthorId", c => c.Int());
            CreateIndex("dbo.t_Course", "AuthorId");
            AddForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors", "AuthId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors");
            DropIndex("dbo.t_Course", new[] { "AuthorId" });
            AlterColumn("dbo.t_Course", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.t_Course", "AuthorId");
            AddForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors", "AuthId", cascadeDelete: true);
        }
    }
}
