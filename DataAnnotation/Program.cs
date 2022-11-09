using System;
using System.Collections.Generic;
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

            //1- Syntaxe SQL : Convient aux developpeurs Sl 
            Console.WriteLine("*****************************Syntaxe SQL***************************************");


        }
    }
}
