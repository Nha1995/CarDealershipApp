using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;

namespace CarDealershipRepository.AdoNet
{
    public class CarDbRepository : DbRepository, ICarRepository
    {
        public CarDbRepository(string connectionString) : base(connectionString) { }

        public Car GetCarByNumber(string carNumber)
        {
            using (SqlConnection connection = GetConnection())
            {
                string insertCommand = $"SELECT * FROM Car WHERE Car.Number ='{carNumber}'";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Car.CreateCar((long)reader["Id"], (bool)reader["Sold"], reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]);
                }
                else
                {
                    return null;
                }
            }
        }
        public bool Add(Car car)
        {
            if (GetCarByNumber(car.Number) == null)
            {
                using (SqlConnection connection = GetConnection())
                {
                    int sold = car.Sold ? 1 : 0;
                    string insertCommand = $"INSERT INTO CAR VALUES ('{car.Number}','{car.Model}',{car.Year},'{car.Color}',{car.Price}, {sold}, null)";
                    SqlCommand command = new SqlCommand(insertCommand, connection);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Count()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT COUNT(*) AS Count FROM Car";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                reader.Read();

                return (int)reader["Count"];
            }
        }

        public LinkedList<Car> List(bool sold)
        {
            int Sold = sold ? 1 : 0;
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT * FROM Car LEFT JOIN Client ON Car.ClientId=Client.Id Where Sold = {Sold}";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                var carList = new LinkedList<Car>();

                while (reader.Read())
                {
                    if (Sold == 1)
                    {
                        var car = Car.CreateCar((long)reader["Id"], (bool)reader["Sold"], reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]);
                        car.Client = Client.CreateClient((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());
                        carList.AddLast(car);
                    }
                    else
                    {
                        var car = Car.CreateCar((long)reader["Id"], (bool)reader["Sold"], reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]);
                        carList.AddLast(car);
                    }
                }
                return carList;
            }
        }
        public void Sell(Car car, Client client)
        {
            using (SqlConnection connection = GetConnection())
            {
                string UpdateCommand = $"UPDATE Car SET Sold = 1 , ClientId = {client.Id} WHERE Id = '{car.Id}'";
                SqlCommand command = new SqlCommand(UpdateCommand, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
