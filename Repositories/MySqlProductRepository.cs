using inventorySystem.Models;
using MySql.Data.MySqlClient;

namespace inventorySystem.Repositories;

public class MySqlProductRepository : IProductRepository
{
    private readonly string _connectionString;
    public MySqlProductRepository(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string creatTableSql = @"
                 create table if not exists products( 
                     
                 id int primary key auto_increment,
                 name varchar(100) not null,
                 price decimal(10,2) not null,
                 quantity int not null ,
                 status int not null   )";
                // status int not null 使程式碼更通用
                using  (MySqlCommand cmd = new MySqlCommand(creatTableSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("初始化成功、檔案已存在");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"初始化失敗: {e.Message}");
            }
        }
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}