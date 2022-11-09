using DataAnnotation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation
{
    class Program
    {
        static void Main(string[] args) 
        {

            /*
             * LINQ : Langage Integrated Query : Langage qui est propre à Microsoft - permet d'interoger n'importe quelle source 
             * de données : Base de données, fichier, des objets en memoire 
             * LINQ fournit un modèle de programmation uniforme (c'est à dire une syntaxe de requête commune) qui nous permet 
             * de travailler avec différentes sources de données
             * 
             */

            /*
             *  Il existe deux façon d'utiliser LINQ : 
             *  1- Syntaxe de la requête 
             *  2- Syntaxe de la méthode : soit via des appels successifs de méthodes 
             */


            MyDbContext context = new MyDbContext();

            //1- Syntaxe SQL : Convient aux developpeurs SQL
            Console.WriteLine("*****************************Syntaxe SQL***************************************");
            var query = from c in context.Courses                   //Initialisation
                        where c.Name.Contains("c#")                     //condition 
                        select c;                                                       //Selection 

            foreach (var course in query)
            {
                Console.WriteLine(course.Name + "    "+ course.Description);
            }

            //2-Chaine de méthode :   Convient aux dev 
            //Utilisation des expressions lambda 
            Console.WriteLine("\n*********************Linq avec des méthodes successives****************************");
            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"));

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name + "    " + course.Description);
            }


            Console.WriteLine("\n*****************************Syntaxe SQL ORDER BY***************************************");
            //Syntaxe SQL - ORDER BY
            //On souhaite récuperer tous les cours de l'auteur dont l'id = 1 (du plus grand au plus petit)
            //Par defaut les resultats sont classés par ordre ascendant
            var query2 = from c in context.Courses
                        where c.AuthorId == 1
                        orderby c.Name descending
                        select c;

            foreach (var course in query2)
            {
                Console.WriteLine(course.Name  + "  " + course.Author.Name);
            }


            Console.WriteLine("\n*********************Linq avec des méthodes successives - ORDER BY****************************");
            var query3 = context.Courses.Where(c => c.AuthorId == 1)
                .OrderByDescending(c => c.Name);

                    foreach (var course in query3)
                    {
                        Console.WriteLine(course.Name + "  " + course.Author.Name);
                    }


            /*
             * Une requête de projection 
             * La projection désigne l'operation de transformation d'un objet en une nouvelle forme qui se compose 
             * souvent uniquement des propriétés à utiliser ensuite 
             * Ces propriétés peuvent contenir par exemple les données venant de la base de données 
             * 
             * A l'aide de la projection, on peut créer un nouveau type qui est généré à partir d'un autre objet 
             * 
             * Avec LINQ on peut projetter des données vers un nouveau type ou même sans avoir besoin de déclarer le type 
             * en utilisant les objets anonymes 
             * 
             * Si on a besoin d'afficher certaines données sans avoir besoin de créer une nouvelle classe on peut utiliser les objets 
             * anonymes 
             * 
             */


            Console.WriteLine("\n*********************Projection avec Syntaxe SQL****************************");
            /*
             * Projection : 2 - option 
             * 1- Créer une classe intermédiaire 
             * 2- Utilisation des objets anonymes
             */
            var query4 = from c in context.Courses
                         where c.AuthorId == 1
                         //select new { AuthorName = c.Author.Name, CourseName = c.Name };  //objet anonyme
                         select new CourseAuthor { AuthorName = c.Author.Name, CourseName = c.Name };  //objet concret
            foreach (var course in query4)
            {
                Console.WriteLine(course.AuthorName + "  |   " + course.CourseName);

            }


            Console.WriteLine("\n*********************Projection avec  les méthodes  successives****************************");
            //Recuperer CourseName + AuthorName :prix = 2000
            //Récuperer les cours dont le prix est à 2000euros
            var courseList2 = context.Courses.Where(c => c.FullPrice == 2000)
                .Select(c => new {AuthorName = c.Author.Name, CourseName = c.Name });
            foreach (var item in courseList2)
            {
                Console.WriteLine(item);
            }



            //GroupBy 
            //Regrouper les cours qui ont le même prix 
            Console.WriteLine("\n*********************GROUP BY avec Syntaxe SQL****************************");
            var query5 = from c in context.Courses
                         group c by c.FullPrice
                         into g     //stock le resultat dans g avec le mot into
                         select g;
            Console.WriteLine("Liste des groupes de cours par prix");
            foreach (var groupe in query5)
            {
                Console.WriteLine(groupe.Key);
                //Pour chaque prix on affiche le nom des cours 
                foreach (var g in groupe)
                {
                    Console.WriteLine("\t{0}", g.Name);
                }
            }


            //Utilisation des fonctions d'aggregation: Count, Min, Sum
            //Regrouper les cours qui ont le même prix et les compter
            var query6 = from c in context.Courses
                         group c by c.FullPrice
                         into g
                         select new { Key = g.Key, Count = g.Count() };
            foreach (var group in query6)
            {
                Console.WriteLine("{0} : {1}", group.Key, group.Count);
            }

            //Jointure : Inner Join, Group Join, Cross Join, Left Join 
            Console.WriteLine("\n*********************INNER JOIN*************************");
            //Selectionner les cours qui ont un auteur
            var query7 = from c in context.Courses
                         join a in context.Authors
                         on c.AuthorId equals a.AuthId
                         select new { CourseName = c.Name, AuthorName = a.Name };
            foreach (var item in query7)
            {
                Console.WriteLine("{0} : {1}", item.CourseName, item.AuthorName);
            }

            Console.WriteLine("\n*********************GROUP JOIN*************************");
            //Group Join : Une jointure de groupe n'a pas d'équivalence en SQL 
            //C'est une jointure interne dont le resultat est organisé en groupe
            //On veut connaitre pour chaque auteur le nombre de cours effectués
            var query8 = from a in context.Authors
                         join c in context.Courses
                         on a.AuthId equals c.AuthorId into g
                         select new { AuthorName = a.Name, NBCourses = g.Count() };
            foreach (var item in query8)
            {
                Console.WriteLine("{0} : {1}", item.AuthorName, item.NBCourses);
            }


            Console.WriteLine("\n*********************LEFT OUTER JOIN*************************");
            //Left Outer Join : Chaque ligne de la table de gauche est envoyée même si aucun élément correspondant ne se trouve 
            //dans la table 
            //1er etape : Faire une jointure interne à l'aide d'une jointure de groupe 
            //2ème étape: Inclure tous les éléments de la table de gauche; que cet élément n'ait ou pas de correspondance 
            //avec la table de droite 
            //Pour ce faire, nous devons utiliser la méthode DefaultIfEmpty() qui sera appelé dans notre exemple sur chaque 
            //objet Author
            var query9 = from c in context.Courses
                         join a in context.Authors
                         on c.AuthorId equals a.AuthId into g
                         from subAuthor in g.DefaultIfEmpty()
                         select new { CourseName = c.Name, AuthorName = subAuthor.Name };
            foreach (var item in query9)
            {
                Console.WriteLine("{0} : {1}", item.CourseName, item.AuthorName);
            }

            //Chargements des collections : 
            //Lazy loading (chargement tardif/differé) - Eager loading (charment Immédiat) 

            Console.WriteLine("\n*******************Chargement des collections **************************");
            //Un cours possède une collection d'utilisateur 
            var cour = context.Courses.Include(c => c.Users).Single(c => c.Id == 2);
            Console.WriteLine("Liste des utilisateur d'un cours");

            foreach (var item in cour.Users)
            {
                Console.WriteLine(item.FirstName + " ---- " + item.LastName);
            }

            Console.ReadLine();
        }
    }
}
