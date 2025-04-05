using System;
using System.Data.SQLite;

namespace Database
{

    public class DatabaseManager
    {
        private string connectionString = "Data Source=shop.db;Version=3;";

        public void CreateDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Price REAL)";
                SQLiteCommand command = new SQLiteCommand(createTableQuery, conn);
                command.ExecuteNonQuery();
            }
        }

        public void AddProduct(string name, double price)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Price", price);
                command.ExecuteNonQuery();
            }
        }

        public void DisplayProducts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Products";
                SQLiteCommand command = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]} - {reader["Name"]} - {reader["Price"]} DKK");
                }
            }
        }
    }
}
