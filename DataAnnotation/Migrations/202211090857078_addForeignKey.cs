namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_Course", "Author_AuthId", "dbo.Authors");
            DropForeignKey("dbo.Utilisateurs", "Adresse_AdrId", "dbo.Adresses");
            DropIndex("dbo.t_Course", new[] { "Author_AuthId" });
            DropIndex("dbo.Utilisateurs", new[] { "Adresse_AdrId" });
            DropColumn("dbo.t_Course", "AuthorId");
            DropColumn("dbo.Utilisateurs", "AdresseId");
            RenameColumn(table: "dbo.t_Course", name: "Author_AuthId", newName: "AuthorId");
            RenameColumn(table: "dbo.Utilisateurs", name: "Adresse_AdrId", newName: "AdresseId");
            AlterColumn("dbo.t_Course", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilisateurs", "AdresseId", c => c.Int(nullable: false));
            CreateIndex("dbo.t_Course", "AuthorId");
            CreateIndex("dbo.Utilisateurs", "AdresseId");
            AddForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors", "AuthId", cascadeDelete: true);
            AddForeignKey("dbo.Utilisateurs", "AdresseId", "dbo.Adresses", "AdrId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilisateurs", "AdresseId", "dbo.Adresses");
            DropForeignKey("dbo.t_Course", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Utilisateurs", new[] { "AdresseId" });
            DropIndex("dbo.t_Course", new[] { "AuthorId" });
            AlterColumn("dbo.Utilisateurs", "AdresseId", c => c.Int());
            AlterColumn("dbo.t_Course", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Utilisateurs", name: "AdresseId", newName: "Adresse_AdrId");
            RenameColumn(table: "dbo.t_Course", name: "AuthorId", newName: "Author_AuthId");
            AddColumn("dbo.Utilisateurs", "AdresseId", c => c.Int(nullable: false));
            AddColumn("dbo.t_Course", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Utilisateurs", "Adresse_AdrId");
            CreateIndex("dbo.t_Course", "Author_AuthId");
            AddForeignKey("dbo.Utilisateurs", "Adresse_AdrId", "dbo.Adresses", "AdrId");
            AddForeignKey("dbo.t_Course", "Author_AuthId", "dbo.Authors", "AuthId");
        }
    }
}
