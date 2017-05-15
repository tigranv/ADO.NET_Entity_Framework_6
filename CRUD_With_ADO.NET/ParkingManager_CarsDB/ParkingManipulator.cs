using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

                SqlTransaction transaction = connection.BeginTransaction();

                command.Transaction = transaction;
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

                    //transaction.Commit();
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
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


                SqlTransaction transaction = connection.BeginTransaction();

                command.Transaction = transaction;

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

                    //transaction.Commit();

                }
                catch (Exception e)
                {
                    //transaction.Rollback();
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

        public void Update(Car car)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Cars SET Mark=@Mark, Model=@Model, Year=@Year WHERE ID=@id", connection);
                command.Parameters.AddWithValue("id", car.ID);
                command.Parameters.AddWithValue("Mark", car.Mark);
                command.Parameters.AddWithValue("Model", car.Model);
                command.Parameters.AddWithValue("Year", car.Year);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CreateNew(Car car)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Cars VALUES (@Mark, @Model, @Year)", connection);
                command.Parameters.AddWithValue("Mark", car.Mark);
                command.Parameters.AddWithValue("Model", car.Model);
                command.Parameters.AddWithValue("Year", car.Year);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Cars WHERE ID = @id", connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
