using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                MyGrid.ItemsSource = null;
                carList.Clear();
                carList.Add(car);
                MyGrid.ItemsSource = carList;
            }
        }

        private void AddNewBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
