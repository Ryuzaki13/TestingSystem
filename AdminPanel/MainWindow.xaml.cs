using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminPanel
{
    public partial class MainWindow : Window
    {
        private readonly Database.TestingSystemEntities connection;

        public ObservableCollection<Database.Account> Accounts { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            connection = new Database.TestingSystemEntities();
            if (connection.Database.Exists() == false)
            {
                MessageBox.Show("Подключение к базе данных не было выполнено. Приложение будет завершено.",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                Application.Current.Shutdown();
            }

            Accounts = new ObservableCollection<Database.Account>(connection.Accounts);

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var account = new Database.Account()
            {
                FirstName = "asdasd",
                LastName = "fgfhfd",
                Patronymic = "gfhfgh",
                RoleID = 1
            };

            connection.Accounts.Add(account);
            connection.SaveChanges();

            Accounts.Add(account);
        }
    }
}
