using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace AdminPanel.AppPages
{
    public partial class AccountEdit : Page
    {
        private readonly Database.TestingSystemEntities database;

        public AccountEdit(Database.TestingSystemEntities entities)
        {
            InitializeComponent();
            database = entities;

            cbRoles.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
            {
                Source = new ObservableCollection<Database.Role>(database.Roles)
            });
        }

        public void SetAccount(Database.Account account)
        {
            DataContext = account;
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
