using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace AdminPanel.AppPages
{


    public partial class AccountView : Page
    {
        private readonly Database.TestingSystemEntities database;
        private ObservableCollection<Database.Account> accounts;

        public AccountView(Database.TestingSystemEntities entities)
        {
            InitializeComponent();
            database = entities;

            accounts = new ObservableCollection<Database.Account>(database.Accounts);
            lvAccounts.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
            {
                Source = accounts,
            });
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            if (lvAccounts.SelectedItem == null) return;

            var selectedAccount = lvAccounts.SelectedItem as Database.Account;
            if (selectedAccount == null) return;

            ViewManager.AccountEditor.SetAccount(selectedAccount);
            NavigationService.Navigate(ViewManager.AccountEditor);
        }

        private void OnClickCreate(object sender, RoutedEventArgs e)
        {
            var selectedAccount = new Database.Account()
            {
                FirstName = "",
                LastName = "",
                Patronymic = "",
                RoleID = 1
            };

            database.Accounts.Add(selectedAccount);
            accounts.Add(selectedAccount);

            ViewManager.AccountEditor.SetAccount(selectedAccount);
            NavigationService.Navigate(ViewManager.AccountEditor);
        }

        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            if (lvAccounts.SelectedItem == null) return;

            var selectedAccount = lvAccounts.SelectedItem as Database.Account;
            if (selectedAccount == null) return;

            accounts.Remove(selectedAccount);

            database.Accounts.Remove(selectedAccount);
            database.SaveChanges();
        }
    }
}
