using GestionUtilisateursWinForms.DAO;
using GestionUtilisateursWinForms.Metier;
using GestionUtilisateursWinForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateursWinForms.Service
{
    public class UtilisateurService : IUtilisateur
    {
        IUtilisateur dao;

        public UtilisateurService()
        {
            dao = new UtilisateurDAO();
        }

        public void AddUser(Utilisateur u)
        {
            dao.AddUser(u);
        }

        public void DeleteUserById(int id)
        {
            dao.DeleteUserById(id);
        }

        public Utilisateur getUserById(int id)
        {
            return dao.getUserById(id);
        }

        public List<Utilisateur> GetUsers()
        {
            return dao.GetUsers();
        }

        public void UpdateUser(Utilisateur u)
        {
            dao.UpdateUser(u);
        }
    }
}
