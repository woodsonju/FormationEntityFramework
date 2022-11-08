using DataBaseFirstExo1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseFirstExo1
{
    public partial class Form1 : Form
    {
        private IEmployeeDAO dao;

        public Form1()
        {
            InitializeComponent();
            dao = new EmployeeDAOImpl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Récuperation des entrées 
            int num = Convert.ToInt32(txtNum.Text);
            int age = Convert.ToInt32(txtAge.Text);
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            string street = txtStreet.Text;

            //Création des objets (Employee et Adresse)
            Employee employee = new Employee() { lastname=lastname, firstname=firstname, age=age};
            employee.Address = new Address() { Num = num, Street = street };

            //Ajout de l'objet Employee dans la base de données 
            dao.AddEmployee(employee);

            
            MessageBox.Show("Employe sauvegardée dans la base de données");


        }
    }
}
