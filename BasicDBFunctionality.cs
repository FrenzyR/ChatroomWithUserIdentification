using System;
using System.Data.Common;
using MySqlConnector;

namespace ChatroomWithUserIdentification
{
    public class SignUpAndSignIn
    {


        public bool SignIn(string username, string password)
        {

            

            if (VerifyPasswordFromDatabase(username, password))
            {
                Console.WriteLine("Password is valid. Proceed!");
                return true;
            }
            else
            {

                Console.WriteLine("Invalid username or password. Try again.");
            }

            return false;
        }

        public bool CreateNewAccount(string newUsername, string newPassword)
        {

            string connectionString = "Server=localhost;Database=users;User Id=root;Password=;";

            using (DbConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO user (username, password) VALUES (@Username, @Password)";
                    MySqlCommand command = new MySqlCommand(query,(MySqlConnection) connection);
                    command.Parameters.AddWithValue("@Username", newUsername);
                    command.Parameters.AddWithValue("@Password", newPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        Console.WriteLine("Account created successfully!");
                        return true;
                    }
                    else
                    {
                        
                        Console.WriteLine("Failed to create account.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return false;
                }
            }
            return false;
        }

        private bool VerifyPasswordFromDatabase(string username, string password)
        {
            
            string connectionString = "Server=localhost;Database=users;User Id=root;Password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM users.user WHERE username = @Username AND password = @Password";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}
