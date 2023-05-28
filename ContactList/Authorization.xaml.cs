using ContactList.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ContactList
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        User user;
        bool isExist = false;

        public Authorization()
        {
            InitializeComponent();
            user = new User();
            GetUser();
        }

        void GetUser()
        {
            if(File.Exists(App.dbPath))
            {
                using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                {
                    connection.CreateTable<User>();
                    if(connection.Table<User>().First() != null) {
                        user = connection.Table<User>().First();
                        isExist = true;
                    }
                }
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (isExist)
            {
                if(loginTextBox.Text != user.login)
                {
                    MessageBox.Show("Wrong login", "Message", MessageBoxButton.OK);
                    return;
                }

                if(passwordTextBox.Text != user.password)
                {
                    MessageBox.Show("Wrong password", "Message", MessageBoxButton.OK);
                    return;
                }

                Hide();

                MainWindow main = new MainWindow();
                main.ShowDialog();
                Show();
            }
            else
            {
                if(loginTextBox.Text != string.Empty) user.login = loginTextBox.Text;
                else
                {
                    MessageBox.Show("Login is empty", "Message", MessageBoxButton.OK);
                    return;
                }

                if(passwordTextBox.Text != string.Empty) user.password = passwordTextBox.Text;
                else
                {
                    MessageBox.Show("Password is empty", "Message", MessageBoxButton.OK);
                    return;
                }

                isExist = true;

                Hide();
                MainWindow main = new MainWindow();
                main.ShowDialog();
                Show();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}