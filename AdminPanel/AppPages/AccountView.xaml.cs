using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

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

        public Database.Account GetSelected()
        {
            return lvAccounts.SelectedItem as Database.Account;
        }

        public void Change(Database.Account account)
        {
            ViewManager.AccountEditor.SetAccount(account);
            NavigationService.Navigate(ViewManager.AccountEditor);
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelected();
            if (selectedAccount == null) return;

            Change(selectedAccount);
        }
        private void OnClickDelete(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelected();
            if (selectedAccount == null) return;

            accounts.Remove(selectedAccount);

            database.Accounts.Remove(selectedAccount);
            database.SaveChanges();
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

            Change(selectedAccount);
        }
    }
}
