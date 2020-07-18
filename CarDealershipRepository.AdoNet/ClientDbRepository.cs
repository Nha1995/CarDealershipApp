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
        public ClientDbRepository(string connectionString) : base(connectionString) { }

        public bool AddClient(Client client)
        {
            if (GetClientByPassportId(client.PassportId) == null)
            {
                using (SqlConnection connection = GetConnection())
                {
                    string insertCommand = $"INSERT INTO Client VALUES ('{client.PassportId}', '{client.Surname}', '{client.Name}')";
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

        public LinkedList<Client> ClientList()
        {
            using (SqlConnection connection = GetConnection())
            {
                Client instanceClient;
                string selectCommand = $"select Client.Id AS ClientId, Car.Id AS CarId , PassportId, Surname,Name,Number,Model,Year,Color,Price,Sold,ClientId  from Client left join Car on Client.Id = Car.ClientId";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                var clientList = new LinkedList<Client>();
                reader.Read();
                instanceClient = new Client((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());

                if (reader["CarId"] != DBNull.Value)
                {
                    instanceClient.Cars.Add(new Car((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                }
                while (reader.Read())
                {
                    if((long)reader["ClientId"] == instanceClient.Id)
                    {
                        instanceClient.Cars.Add(new Car((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                    }
                    else
                    {
                        clientList.AddLast(instanceClient);

                        instanceClient = new Client((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());

                        if (reader["CarId"] != DBNull.Value)
                        {
                            instanceClient.Cars.Add(new Car((long)reader["CarId"], true, reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]));
                        }
                    }
                }
                clientList.AddLast(instanceClient);
                return clientList;
            }
        }

        public int Count()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT COUNT(*) AS Count FROM Client";
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
                string insertCommand = $"SELECT * FROM Client WHERE Client.PassportId ='{passportId}'";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Client((long)reader["Id"], reader["PassportId"].ToString(),reader["Surname"].ToString(),reader["Name"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
