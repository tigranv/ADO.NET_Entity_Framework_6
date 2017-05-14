using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace ParkingManager_CarsDB
{
    public partial class MainWindow : Window
    {
        ParkingManipulator Park;
        List<Car> carList;
        public MainWindow()
        {
            InitializeComponent();
            Park = new ParkingManipulator();
            carList = new List<Car>();
        }

        private void Get_All_CarsBt_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.ItemsSource = null;
            carList = Park.GetAllCars();
            MyGrid.ItemsSource = carList;

        }

        private void Get_By_IdBt_Click(object sender, RoutedEventArgs e)
        {
            string text = GetIDTxBox.Text;
            if(!string.IsNullOrEmpty(text) && text.All(char.IsDigit))
            {
                Car car = Park.GetCarById(int.Parse(text));
                if(car != null)
                {
                    MyGrid.ItemsSource = null;
                    carList.Clear();
                    carList.Add(car);
                    MyGrid.ItemsSource = carList;
                }
                else
                {
                    MessageBox.Show($"No car with Id {text}");
                }
                
            }
        }

        private void AddNewBt_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car(MarkTxBox.Text, modeltxtBox.Text, int.Parse(YeartxBox.Text));
            Park.CreateNew(car);
            MessageBox.Show($"New Car created");
            MyGrid.ItemsSource = null;
            carList = Park.GetAllCars();
            MyGrid.ItemsSource = carList;
        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car(carList[MyGrid.SelectedIndex].ID, MarkTxBox.Text,  modeltxtBox.Text, int.Parse(YeartxBox.Text));
            Park.Update(car);
            MessageBox.Show($"Car with id-{carList[MyGrid.SelectedIndex].ID} updated");
            MyGrid.ItemsSource = null;
            carList = Park.GetAllCars();
            MyGrid.ItemsSource = carList;
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            if(MyGrid.SelectedItem != null)
            {
                Park.Delete(carList[MyGrid.SelectedIndex].ID);
                MyGrid.ItemsSource = null;
                carList = Park.GetAllCars();
                MyGrid.ItemsSource = carList;
            }
            else
            {
                MessageBox.Show($"No car with Id {carList[MyGrid.SelectedIndex].ID}");
            }

        }

        private void carBt_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
