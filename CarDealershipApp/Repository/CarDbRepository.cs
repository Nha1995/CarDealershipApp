using CarDealershipApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CarDealershipApp.Repository
{
    public class CarDbRepository : DbRepository, ICarRepository
    {
        public CarDbRepository(string connectionString) : base(connectionString) { }

        public bool Add(Car car)
        {
            using (SqlConnection connection = GetConnection())
            {
                int sold = car.Sold ? 1 : 0;
                string insertCommand = $"INSERT INTO CAR VALUES ('{car.Number}','{car.Model}','{car.YearMaking}','{car.Color}',{car.Price}, {sold})";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                command.ExecuteNonQuery();
            }

            return true;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Car GetCarByNumber(string carNumber)
        {
            throw new NotImplementedException();
        }

        public LinkedList<Car> List()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT * FROM CAR";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                var carList = new LinkedList<Car>();

                while (reader.Read())
                {
                    var car = new Car((long)reader["Id"], (bool)reader["Sold"], reader["Number"].ToString(), reader["Model"].ToString(), reader["YearMaking"].ToString(), reader["Color"].ToString(), (int)reader["Price"]);
                    carList.AddLast(car);
                }

                return carList;
            }
        }

        public void Sell(Car car, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
