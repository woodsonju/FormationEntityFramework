namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAnnotation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "t_Course");
            RenameColumn(table: "dbo.t_Course", name: "Description", newName: "CoursDescription");
            AddColumn("dbo.t_Course", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Adresses", "CodePostale", c => c.String(nullable: false));
            AlterColumn("dbo.Adresses", "Ville", c => c.String(nullable: false));
            AlterColumn("dbo.Adresses", "Pays", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.t_Course", "CoursDescription", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Utilisateurs", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Utilisateurs", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Utilisateurs", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Utilisateurs", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Utilisateurs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilisateurs", "Password", c => c.String());
            AlterColumn("dbo.Utilisateurs", "Email", c => c.String());
            AlterColumn("dbo.Utilisateurs", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Utilisateurs", "FirstName", c => c.String());
            AlterColumn("dbo.Utilisateurs", "LastName", c => c.String());
            AlterColumn("dbo.t_Course", "CoursDescription", c => c.String());
            AlterColumn("dbo.Authors", "Name", c => c.String());
            AlterColumn("dbo.Adresses", "Pays", c => c.String());
            AlterColumn("dbo.Adresses", "Ville", c => c.String());
            AlterColumn("dbo.Adresses", "CodePostale", c => c.String());
            DropColumn("dbo.t_Course", "Name");
            RenameColumn(table: "dbo.t_Course", name: "CoursDescription", newName: "Description");
            RenameTable(name: "dbo.t_Course", newName: "Courses");
        }
    }
}
