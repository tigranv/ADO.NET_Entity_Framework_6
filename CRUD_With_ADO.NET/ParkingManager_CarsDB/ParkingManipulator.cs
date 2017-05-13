using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParkingManager_CarsDB
{
    class ParkingManipulator
    {
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            SqlDataReader reader = null;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Cars", connection);
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Car car = new Car()
                        {
                            ID = (int)reader[0],
                            Mark = reader[1].ToString(),
                            Model = reader[2].ToString(),
                            Year = (int)reader[3]
                        };
                        cars.Add(car);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
            return cars;
        }

        public Car GetCarById(int id)
        {
            Car car = null;
            SqlDataReader reader = null;

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Cars where Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                try
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    car = new Car()
                    {
                        ID = (int)reader[0],
                        Mark = reader[1].ToString(),
                        Model = reader[2].ToString(),
                        Year = (int)reader[3]
                    };
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
                return car;
            }
        }

        public void Update(int id, string mark, string model, int year)
        {

        }

        public void CreateNew(string mark, string model, int year)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
