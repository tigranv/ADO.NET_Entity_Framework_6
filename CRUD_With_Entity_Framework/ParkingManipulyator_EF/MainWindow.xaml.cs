using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// TODO: need to add try catch to all methods
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

        private async void  Get_All_CarsBt_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.ItemsSource = null;
            carList = await Park.Cars.ToListAsync();            
            MyGrid.ItemsSource = carList;
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

        private void AddNewBt_Click(object sender, RoutedEventArgs e)
        {
            //Car car = new Car(MarkTxBox.Text, modeltxtBox.Text, int.Parse(YeartxBox.Text));
            //Park.CreateNew(car);
            //MessageBox.Show($"New Car created");
            //MyGrid.ItemsSource = null;
            //carList = Park.GetAllCars();
            //MyGrid.ItemsSource = carList;
        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            //Car car = new Car(carList[MyGrid.SelectedIndex].ID, MarkTxBox.Text, modeltxtBox.Text, int.Parse(YeartxBox.Text));
            //Park.Update(car);
            //MessageBox.Show($"Car with id-{carList[MyGrid.SelectedIndex].ID} updated");
            //MyGrid.ItemsSource = null;
            //carList = Park.GetAllCars();
            //MyGrid.ItemsSource = carList;
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            //if (MyGrid.SelectedItem != null)
            //{
            //    Park.Delete(carList[MyGrid.SelectedIndex].ID);
            //    MyGrid.ItemsSource = null;
            //    carList = Park.GetAllCars();
            //    MyGrid.ItemsSource = carList;
            //}
            //else
            //{
            //    MessageBox.Show($"No car with Id {carList[MyGrid.SelectedIndex].ID}");
            //}

        }
    }
}
