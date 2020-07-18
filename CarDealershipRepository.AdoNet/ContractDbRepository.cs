using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using CarDealershipRepository.Interfaces;

namespace CarDealershipRepository.AdoNet
{
    public class ContractDbRepository : DbRepository, IContractRepository
    {
        public ContractDbRepository(string connectionString) : base(connectionString) { }
        public void AddContract(Contract contract)
        {
            using (SqlConnection connection = GetConnection())
            {
                int isCredit = contract.isCredit ? 1 : 0;
                string insertCommand = $"INSERT INTO Contract VALUES ({contract.Client.Id}, {contract.Car.Id}, {contract.TotalCost}, {contract.FirstPayment},{contract.CreditTerm},{contract.MonthlyPayment}, {isCredit})";
                SqlCommand command = new SqlCommand(insertCommand, connection);
                command.ExecuteNonQuery();
            }
        }

        public LinkedList<Contract> ContractList()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT * FROM Contract INNER JOIN CAR ON Contract.CarId = Car.Id INNER JOIN Client ON Client.Id = Contract.ClientId";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                var contractList = new LinkedList<Contract>();

                while (reader.Read())
                {
                    var contract = new Contract((long)reader["ClientId"], (long)reader["CarId"], (double)reader["TotalCost"], (double)reader["FirstPayment"], (double)reader["CreditTerm"], (double)reader["MonthlyPayment"],(bool)reader["isCredit"]);

                    contract.Car = new Car((long)reader["Id"], (bool)reader["Sold"], reader["Number"].ToString(), reader["Model"].ToString(), (int)reader["Year"], reader["Color"].ToString(), (int)reader["Price"]);
                    contract.Client = new Client((long)reader["ClientId"], reader["PassportId"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString());

                    contractList.AddLast(contract);
                }
                return contractList;
            }
        }

        public int Count()
        {
            using (SqlConnection connection = GetConnection())
            {
                string selectCommand = $"SELECT COUNT(*) AS Count FROM Contract";
                SqlCommand command = new SqlCommand(selectCommand, connection);
                DbDataReader reader = command.ExecuteReader();

                reader.Read();

                return (int)reader["Count"];
            }
        }
    }
}
