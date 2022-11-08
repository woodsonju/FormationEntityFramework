using CodeFirstExo1.DAO;
using CodeFirstExo1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExo1
{
    class Program
    {
        static IContactDAO dao = new ContactDaoImpl();

        static void Main(string[] args)
        {
            //Ajouter un contact 
            Contact c = new Contact() { Nom = "Dupont", Prenom = "Pierre" };
            Contact c2 = new Contact() { Nom = "Pasdroit", Prenom = "Léo" };
            dao.AddContact(c);
            dao.AddContact(c2);



            try
            {
                //Test Delete 
                Contact contact2 = dao.FindContactById(1);
                dao.DeleteContact(contact2);

                //Mise à jour de contact 
                Contact contact1 = dao.FindContactById(2);
                contact1.Prenom = "Moussah";
                dao.UpdateContact(contact1);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
          


            Console.ReadLine();
        }
    }
}
