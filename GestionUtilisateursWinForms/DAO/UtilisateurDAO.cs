using GestionUtilisateursWinForms.Metier;
using GestionUtilisateursWinForms.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateursWinForms.DAO
{
    public class UtilisateurDAO : IUtilisateur
    {
        private MyContext context;

        public UtilisateurDAO()
        {
            context = new MyContext();
        }

        public void AddUser(Utilisateur u)
        {
            context.Utilisateurs.Add(u);
            context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            Utilisateur u = context.Utilisateurs.Find(id);

            context.Utilisateurs.Remove(u);

            context.SaveChanges();
           
        }

        public Utilisateur getUserById(int id)
        {
            Utilisateur u = context.Utilisateurs.Find(id);
            if(u == null)
            {
                throw new Exception("Utilisateur introuvable");
            }
            return u;
        }

        public List<Utilisateur> GetUsers()
        {
            return context.Utilisateurs.ToList();
        }

        public void UpdateUser(Utilisateur u)
        {
            context.Entry(u).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
