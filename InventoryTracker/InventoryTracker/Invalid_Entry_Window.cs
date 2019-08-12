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
            string[] errorMessages =
            {
                "Item Name length is not valid", // 0
                "Current Stock is not a valid", // 1
                "Ideal Stock is not a valid", // 2
                "Ideal Stock cannot be 0", // 3
                "Item will be a duplicate", // 4
                "No Item Name match" // 5
            };
            error_message_panel.DataContext = errorMessages[Global.GetErrorIndex()];
        }
        private void Ok_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}