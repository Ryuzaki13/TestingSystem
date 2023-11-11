using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminPanel
{
    public partial class AdminCreator : Window
    {
        private readonly Database.TestingSystemEntities database;
        public AdminCreator(Database.TestingSystemEntities database)
        {
            InitializeComponent();
            this.database = database;  

            CheckRoles();
        }

        private void CheckRoles()
        {
            var roles = new Roles();
            var properties = typeof(Roles).GetProperties();
            foreach (var property in properties) {
                string roleName = property.GetValue(roles).ToString();
                if (database.Roles.Count(r => r.Name == roleName) == 0) {
                    Console.WriteLine("Роль {0} отсутствует", roleName);

                    database.Roles.Add(new Database.Role() { Name = roleName });
                }
            }

            database.SaveChanges();
        }
    }
}
