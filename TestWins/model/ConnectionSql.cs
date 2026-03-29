namespace TestWins.Model;

//dotnet add package MySql.Data
using MySql.Data.MySqlClient;

public class ConnectionSql
{
    private readonly string _connectionString = "server=localhost;database=student;uid=root;pwd=root";
    private MySqlConnection _conn;

    public MySqlConnection ConnectSql()
    {
        try
        {
            Console.WriteLine("Connecting to DB...");

            _conn = new MySqlConnection(_connectionString);
            _conn.Open();

            Console.WriteLine("Database connection successful");

            return _conn;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database connection failed: " + ex.Message);
            return null;
        }
    }
}
