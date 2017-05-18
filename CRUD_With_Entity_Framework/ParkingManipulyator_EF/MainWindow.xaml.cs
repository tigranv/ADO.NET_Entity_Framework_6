using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ParkingManipulyator_EF
{
    /// <summary>
    /// TODO: need to add try catch to all methods, change methods to async
    /// </summary>
    public partial class MainWindow : Window
    {
        ParkingEntities Park;
        List<Car> carList;
        public MainWindow()
        {
            InitializeComponent();
            Park = new ParkingEntities();
            carList = new List<Car>();
        }

        private void  Get_All_CarsBt_Click(object sender, RoutedEventArgs e)
        {
            RefreshCarsList();
        }

        private async void Get_By_IdBt_Click(object sender, RoutedEventArgs e)
        {
            string text = GetIDTxBox.Text;
            if (!string.IsNullOrEmpty(text) && text.All(char.IsDigit))
            {
                int id = int.Parse(text);
                carList = null;
                carList = await Park.Cars.Where(p => p.Id == id).ToListAsync();
                MyGrid.ItemsSource = carList;
                if (carList.Count == 0)
                MessageBox.Show($"No car with Id {text}");
            }
        }

        private async void AddNewBt_Click(object sender, RoutedEventArgs e)
        {
            Park.Cars.Add(new Car {
                Mark = MarkTxBox.Text,
                Model = modeltxtBox.Text,
                year = int.Parse(YeartxBox.Text)
            });

            try
            {
                await Park.SaveChangesAsync();
                MessageBox.Show($"New Car created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshCarsList();
        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            if (MyGrid.SelectedItems.Count != 1) return;

            var id = carList[MyGrid.SelectedIndex].Id;
            var car = Park.Cars.Find(id);

            if (car == null) return;

            car.Mark = MarkTxBox.Text;
            car.Model = modeltxtBox.Text;
            car.year = int.Parse(YeartxBox.Text);

            //Park.Entry(car).State = EntityState.Modified; 2 ways to update data
            Park.Cars.AddOrUpdate(car);
            Park.SaveChanges();
            
            RefreshCarsList();
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var id = carList[MyGrid.SelectedIndex].Id;
            var car = Park.Cars.Find(id);

            //Park.Entry(car).State = EntityState.Deleted; 2 ways to delete
            Park.Cars.Remove(car);

            Park.SaveChanges();

            RefreshCarsList();

        }

        private async void RefreshCarsList()
        {
            MyGrid.ItemsSource = null;
            carList = await Park.Cars.ToListAsync();
            MyGrid.ItemsSource = carList;
        }
    }
}
