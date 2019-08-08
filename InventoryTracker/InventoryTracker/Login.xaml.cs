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
using System.Data.Sql;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        

        // So the idea here is that when they click log in the data has to be validated
        // If the user exists in the user table then we will proceed to inventory view window
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Here I need to get all that data was written into the textboxes

            // Then I need to query the database and see if the user exists

            // If the user exists then this window closes and the main window will open

            // else i need to let the user know that it was the wrong credentials and stay at the login screen
        }

        // Here if the button is clicked then the register window should open
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the register window
            Window Register = new Register();
            // Show the new instance of the register window
            Register.Show();
            // CLose this instance of the login window
            this.Close();
        }
    }
}
