using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using CarDealershipDomain;
using CarDealershipRepository.Interfaces;

namespace CarDealershipRepository.AdoNet
{
    public class ClientDbRepository : DbRepository, IClientRepository
    {
        public ClientDbRepository(AdoNetOptions options) : base(options)
        {
            Console.WriteLine("Client DB Repository created");
        }

        public bool AddClient(Client client)
        {
            if (GetClientByPassportId(client.PassportId) == null)
            {
                using (SqlConnection connection = GetConnection())
                {
                    string insertCommand = $"INSERT INTO Clients VALUES ('{client.PassportId}', '{client.Surname}', '{client.Name}')";
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

        public List<Client> ClientList(bool WithCars)
        {
            int withCars = WithCars ? 1:0;
            using (SqlConnection connection = GetConnection())
            {
                string join;
                Client instanceClient;
                if (withCars == 1)
                {
                    join = "inner join";
                }
                else
                {
                    join = "left join";
                }
                string selectCommand = $"select Clients.Id AS ClientId, Cars.Id AS CarId , PassportId, Surname,Name,Number,Model,Year,Color,Price,Sold,ClientId  from Clients {join} Cars on Clients.Id = Cars.ClientId";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                var clientList = new List<Client>();
                reader.Read();
                instanceClient = Client.CreateClient((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());
                if (reader["CarId"] != DBNull.Value)
                {
                    instanceClient.Cars.Add(Car.CreateCar((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                }
                while (reader.Read())
                {
                    if ((long)reader["ClientId"] == instanceClient.Id)
                    {
                        instanceClient.Cars.Add(Car.CreateCar((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                    }
                    else
                    {
                        clientList.Add(instanceClient);

                        instanceClient = Client.CreateClient((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());

                        if (reader["CarId"] != DBNull.Value)
                        {
                            instanceClient.Cars.Add(Car.CreateCar((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                        }
                    }
                }
                clientList.Add(instanceClient);
                return clientList;
            }
        }

        public int Count()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT COUNT(*) AS Count FROM Clients";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                reader.Read();

                return (int)reader["Count"];
            }
        }

        public Client GetClientByPassportId(string passportId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string insertCommand = $"SELECT * FROM Clients WHERE Clients.PassportId ='{passportId}'";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Client.CreateClient((long)reader["Id"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }
    }
}