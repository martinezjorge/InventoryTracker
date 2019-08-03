using System.Windows;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for Invalid_Entry_Window.xaml
    /// </summary>
    public partial class InvalidEntry : Window
    {
        public InvalidEntry()
        {
            InitializeComponent();
        }
        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}