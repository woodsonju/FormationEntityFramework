namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNomDeVoieClassAdresse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adresses", "NomDeVoie", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adresses", "NomDeVoie");
        }
    }
}
