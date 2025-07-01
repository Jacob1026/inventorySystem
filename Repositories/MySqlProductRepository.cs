using inventorySystem.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Serialization;

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
        var products = new List<Product>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM products";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product(reader.GetInt32("id"), 
                                                reader.GetString("name"), 
                                                reader.GetDecimal("price"), 
                                                reader.GetInt32("quantity"))
                        {
                            Status = (Product.ProductStatus)reader.GetInt32("status")
                        });
                    }
                }
            }
        }

        return products;
    }

    public Product GetProductById(int id)
    {
        Product product = null;
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM products WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {   
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product =new Product (reader.GetInt32("id"), 
                            reader.GetString("name"), 
                            reader.GetDecimal("price"), 
                            reader.GetInt32("quantity"))
                        {
                            Status = (Product.ProductStatus)reader.GetInt32("status")
                        };  
                    }
                }

            }
        }

        return product;
    }
}