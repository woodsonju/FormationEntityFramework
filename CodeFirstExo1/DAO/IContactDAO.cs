using CodeFirstExo1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExo1.DAO
{
    interface IContactDAO
    {
        void AddContact(Contact contact);
        List<Contact> FindContacts();
        Contact FindContactById(int id);
        void UpdateContact(Contact contact);

        Contact DeleteContact(Contact contact);
    }
}
