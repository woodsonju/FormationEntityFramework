using FluentAPI.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace FluentAPI
{
    public class MyDbContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyDbContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « FluentAPI.MyDbContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyDbContext » dans le fichier de configuration de l'application.
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        //Utilisation de Fluent API = Rédefinir la méthode OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Prop name(Course) : non nullable + taille 255
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(256);

            //Prop Description (Course) : non nullable + taille 2000
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            /*
             *Mapping  Association entre entités 
             *  
             *  On commence par identifier les propriétés de navigation qui composent la relation 
             *  HasRequired/HasOptionnel ou HasMany 
             *  
             *  On enchaine ensuite un appel à WithOne ou WithMany pour identifier la navigation inverse
             * 
             */

            //Clé etrangère vers la classe Author - OneToMany
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);  //La suppression d'un cours n'implique pas la suppression d'un Author


            //ManyToMany : Course - Utilisateur 
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Courses)
                .Map(m => m.ToTable("CourseUser")
                .MapLeftKey("CourseId")
                .MapRightKey("UtilisateurId"));

            //OneToOne : Utilisateur - Adresse 
            //Préciser le parent (principal) et l'enfant (Dependant)
            modelBuilder.Entity<Utilisateur>()
                .HasRequired(u => u.Adresse)
               .WithRequiredDependent();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}