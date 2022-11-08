namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModelTest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdrId = c.Int(nullable: false, identity: true),
                        NumVoie = c.Int(nullable: false),
                        CodePostale = c.String(),
                        Ville = c.String(),
                        Pays = c.String(),
                    })
                .PrimaryKey(t => t.AdrId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        FullPrice = c.Double(nullable: false),
                        Level = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Author_AuthId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_AuthId)
                .Index(t => t.Author_AuthId);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        TypeUtilisateur = c.Int(nullable: false),
                        AdresseId = c.Int(nullable: false),
                        Adresse_AdrId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.Adresse_AdrId)
                .Index(t => t.Adresse_AdrId);
            
            CreateTable(
                "dbo.UtilisateurCourses",
                c => new
                    {
                        Utilisateur_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Utilisateur_Id, t.Course_Id })
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Utilisateur_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UtilisateurCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.UtilisateurCourses", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Utilisateurs", "Adresse_AdrId", "dbo.Adresses");
            DropForeignKey("dbo.Courses", "Author_AuthId", "dbo.Authors");
            DropIndex("dbo.UtilisateurCourses", new[] { "Course_Id" });
            DropIndex("dbo.UtilisateurCourses", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Utilisateurs", new[] { "Adresse_AdrId" });
            DropIndex("dbo.Courses", new[] { "Author_AuthId" });
            DropTable("dbo.UtilisateurCourses");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
            DropTable("dbo.Adresses");
        }
    }
}
