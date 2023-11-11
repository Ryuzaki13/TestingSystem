using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.AppPages
{
    public class ViewManager
    {
        private static Database.TestingSystemEntities database;

        private static Authorization authorization;
        private static AccountView accountView;
        private static AccountEdit accountEditor;

        public static Authorization Authorization
        {
            get
            {
                if (authorization == null)
                {
                    authorization = new Authorization(Database);
                }
                return authorization;
            }
        }

        public static AccountView AccountView
        {
            get
            {
                if (accountView == null)
                {
                    accountView = new AccountView(Database);
                }
                return accountView;
            }
        }

        public static AccountEdit AccountEditor
        {
            get
            {
                if (accountEditor == null)
                {
                    accountEditor = new AccountEdit(Database);
                }
                return accountEditor;
            }
        }

        public static void Reset()
        {
            database = null;
            authorization = null;
            accountView = null;
            accountEditor = null;
        }

        private static Database.TestingSystemEntities Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database.TestingSystemEntities();
                    if (database.Database.Exists() == false)
                    {
                        MessageBox.Show("Подключение к базе данных не было выполнено. Приложение будет завершено.",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                        Application.Current.Shutdown();
                    }
                }
                return database;
            }
        }
    }
}
