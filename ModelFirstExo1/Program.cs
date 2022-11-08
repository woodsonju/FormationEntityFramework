using ModelFirstExo1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstExo1
{
    class Program
    {
        private static IBlogDAO dao = new BlogDaoImpl();

        static void Main(string[] args)
        {
            Console.WriteLine("Récuperation de la liste des blogs");
            List<Blog> blogs =  dao.FindAll();
            foreach (var item in blogs)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
