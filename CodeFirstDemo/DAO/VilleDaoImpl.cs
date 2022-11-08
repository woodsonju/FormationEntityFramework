using CodeFirstDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.DAO
{
    public class VilleDaoImpl : IVilleDao
    {
        //Contexte de persistence 
        private MyContext context;

        public VilleDaoImpl()
        {
            context = new MyContext();
        }


        public Ville FindVilleById(int id)
        {
            Ville ville = context.Villes.Find(id);
            if(ville == null)
            {
                Console.WriteLine("La ville recherchée n'existe pas");
            }
            return ville;
        }
        

        public List<Ville> FindVilles()
        {
            return context.Villes.ToList();

        }
    }
}
