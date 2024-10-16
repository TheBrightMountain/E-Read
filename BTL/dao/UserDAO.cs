using BTL.model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL.dao
{
    public class UserDAO
    {
        private string strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public void Create(User newUser)
        {
            var passwordHasher = new PasswordHasher<object>();
            string hashedPassword = passwordHasher.HashPassword(null, newUser.Password);
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "INSERT INTO Users (Email, Password, Name, DateOfBirth, Phone, City) VALUES (@Email, @Password, @Name, @DateOfBirth, @Phone, @City)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@Name", newUser.Name);
                    cmd.Parameters.AddWithValue("@DateOfBirth", newUser.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Phone", newUser.Phone);
                    cmd.Parameters.AddWithValue("@City", newUser.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(User updatedUser)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "UPDATE Users SET Name = @Name, DateOfBirth = @DateOfBirth, Phone = @Phone, City = @City WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", updatedUser.Email);
                    cmd.Parameters.AddWithValue("@Name", updatedUser.Name);
                    cmd.Parameters.AddWithValue("@DateOfBirth", updatedUser.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Phone", updatedUser.Phone);
                    cmd.Parameters.AddWithValue("@City", updatedUser.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User Read(string email)
        {
            User user = null;
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "SELECT Email, Password, Name, DateOfBirth, Phone, City FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                            Phone = reader["Phone"].ToString(),
                            City = reader["City"].ToString()
                        };
                    }
                }
            }
            return user;
        }

        public void Delete(string email)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "DELETE FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Verify(string email, string password)
        {
            User user = Read(email); // Retrieve the user from the database

            if (user != null)
            {
                var passwordHasher = new PasswordHasher<object>();
                var verificationResult = passwordHasher.VerifyHashedPassword(null, user.Password, password);

                return verificationResult == PasswordVerificationResult.Success;
            }

            return false;
        }

        public bool EmailExists(string email)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}