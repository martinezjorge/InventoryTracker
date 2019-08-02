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

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for InvalidEntry.xaml
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
