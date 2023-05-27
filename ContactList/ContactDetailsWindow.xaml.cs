using ContactList.Data.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.RightsManagement;
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
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        public Contact selectedContact;
        public List<Contact> contacts;
        public ContactDetailsWindow(Contact selectedContact, List<Contact> contacts)
        {
            InitializeComponent();
            this.contacts = contacts;
            this.selectedContact = selectedContact;
            nameTextBox.Text = this.selectedContact.Name;
            emailTextBox.Text = this.selectedContact.Email;
            phoneTextBox.Text = this.selectedContact.Phone;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {

                connection.Delete(selectedContact);
                selectedContact.Name = nameTextBox.Text;
                selectedContact.Email = emailTextBox.Text;
                selectedContact.Phone = phoneTextBox.Text;
                connection.Insert(selectedContact);
            }

            Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.Delete(selectedContact);
            }

            Close();
        }
    }
}
