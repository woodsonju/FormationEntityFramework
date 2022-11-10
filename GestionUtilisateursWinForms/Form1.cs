using GestionUtilisateursWinForms.Metier;
using GestionUtilisateursWinForms.Model;
using GestionUtilisateursWinForms.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionUtilisateursWinForms
{
    public partial class Form1 : Form
    {
        private IUtilisateur service;

        public Form1()
        {
            InitializeComponent();
            service = new UtilisateurService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'gestionUtilisateurs_dbDataSet.Utilisateurs'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //   this.utilisateursTableAdapter.Fill(this.gestionUtilisateurs_dbDataSet.Utilisateurs);
            Remplir();
        }

        public void Remplir()
        {
            lblID.Visible = false;
            txtID.Visible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = service.GetUsers();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            service.AddUser(new Model.Utilisateur()
            {
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text
            });
            Remplir();
            Clear();
        }

        public void Clear()
        {
            txtID.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            service.DeleteUserById(id);
            Remplir();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            Utilisateur userBDD = service.getUserById(id);

            userBDD.Nom = txtNom.Text;
            userBDD.Prenom = txtPrenom.Text;

            service.UpdateUser(userBDD);

            Remplir();
            Clear();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            Utilisateur u = service.getUserById(id);

            txtID.Text = u.Id.ToString();
            txtNom.Text = u.Nom;
            txtPrenom.Text = u.Prenom;
        }
    }
}
