using CodeFirstExo1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExo1.DAO
{
    public class ContactDaoImpl : IContactDAO
    {

        private MyContext context;

        public ContactDaoImpl()
        {
            context = new MyContext();
        }
        

        public void AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges(); 
        }

        public Contact DeleteContact(Contact contact)
        {
            Contact c = context.Contacts.Remove(contact);
            context.SaveChanges();
            return c;
        }

        public Contact FindContactById(int id)
        {
            Contact c = context.Contacts.Find(id);
          
            if(c == null)
             {
                throw new Exception("Le contact n'existe pas !!!");
             }

            return c;
        }

        public List<Contact> FindContacts()
        {
            return context.Contacts.ToList();
        }

        public void UpdateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
