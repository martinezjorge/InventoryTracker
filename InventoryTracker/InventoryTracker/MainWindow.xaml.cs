/* Team Mithrandir */

// Jorge Martinez
// Nathan Ray
// Ben Stanke
// Marcial Mendoza

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the inventorylist exists outside mainwindow so that it can be affected by the buttons
        public MainWindow()
        {
            InitializeComponent();
            ListViewPeople.ItemsSource = ReadCSV("example");
        }
        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            ;
        }
        private void Add_Item_Button(object sender, RoutedEventArgs e)
        {
            ;
        }
        private void Full_Inventory_Button(object sender, RoutedEventArgs e)
        {
            ;
        }

        public IEnumerable<Person> ReadCSV(string fileName)
        {
            // We change file extension here to make sure it's a .csv file.
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                // We return a person with the data in order.
                return new Person(data[0], data[1], data[2], data[3]);
            });
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            ;
        }
    }




}
