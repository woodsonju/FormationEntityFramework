using GestionUtilisateursWinForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateursWinForms.Metier
{
   public interface IUtilisateur
    { 
        List<Utilisateur> GetUsers();
        Utilisateur getUserById(int id);
        void DeleteUserById(int id);
        void UpdateUser(Utilisateur u);
        void AddUser(Utilisateur u);
    }
}
