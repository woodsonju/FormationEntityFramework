using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirstExo1.DAO
{
    public class EmployeeDAOImpl : IEmployeeDAO
    {
        private firstdemo_db_prepaEntities context;  //null

        public EmployeeDAOImpl()
        {
            context = new firstdemo_db_prepaEntities();
        }

        public void AddEmployee(Employee employee)
        {
            context.Employee.Add(employee);  //L'entité est ajouté dans le contexte 
            context.SaveChanges(); //Entité est sauvegardé dans la base de données
        }
    }
}
