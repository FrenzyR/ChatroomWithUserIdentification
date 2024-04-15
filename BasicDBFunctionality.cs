using System;
using System.Data.SqlClient;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sign Up");

            Console.Write("Enter username or create account (NEW): ");
            string username = Console.ReadLine();
            if (username == "NEW" || username == "new")
            {
                CreateNewAccount();
            }

            Console.Write("Enter password or create account (NEW): ");
            string password = Console.ReadLine();

            bool isPasswordValid = VerifyPasswordFromDatabase(username, password);

            if (isPasswordValid)
            {
                Console.WriteLine("Password is valid. Proceed!");
            }
            else if (password == "NEW" || password == "new")
            {
                CreateNewAccount();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Try again.");
            }

            Console.ReadLine();
        }

        private static void CreateNewAccount()
        {
            Console.Write("Enter a new username: ");
            string newUsername = Console.ReadLine();

            Console.Write("Enter a new password: ");
            string newPassword = Console.ReadLine();

            string connectionString = "add database connection string here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO [user] (username, password) VALUES (@Username, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", newUsername);
                    command.Parameters.AddWithValue("@Password", newPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Account created successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create account.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        static bool VerifyPasswordFromDatabase(string username, string password)
        {
            string connectionString = "add database connection string here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM [user] WHERE username = @Username AND password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
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
