using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString) => _connectionString = connectionString;

        public void AddUser(User user) => ExecuteNonQuery("INSERT", null, user);

        public void UpdateUser(User user) => ExecuteNonQuery("UPDATE", user.Id, user);

        public void DeleteUser(int id) => ExecuteNonQuery("DELETE", id, null);

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_Users_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECT");

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString() ?? "",
                            Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                            Gender = reader["Gender"].ToString() ?? ""
                        });
                    }
                }
            }

            return users;
        }

        private void ExecuteNonQuery(string action, int? id, User? user)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_Users_CRUD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@Id", id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Name", user?.Name ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Birthdate", user?.Birthdate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", user?.Gender ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
