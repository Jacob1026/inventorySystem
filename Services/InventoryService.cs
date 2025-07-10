using inventorySystem.Models;
using inventorySystem.Repositories;
using inventorySystem.Utils;

namespace inventorySystem.Services;

public class InventoryService
{
    private readonly IProductRepository _productRepository;
    //注入介面 資料庫相關
    public InventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public List<Product> GetAllProducts()
    {
        try
        {
            //呼叫介面，而非實作(DI)
            List<Product> products = _productRepository.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("No products found");
            }
            return products;
            

        }
        catch (Exception e)
        {
            Console.WriteLine($"讀取產品列表失敗: {e.Message}");
            return new List<Product>();
        }
    }

    public Product GetProductById(int id)
    {
        try
        {
            //呼叫介面，而非實作(DI)
            Product product = _productRepository.GetAllProducts(id);
            if (product==null)
            {
                Console.WriteLine("No products found");
            }
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine($"讀取產品列表失敗: {e.Message}");
            return new Product();
        }
    }

    public void AddProduct(string? name, decimal price, int quantity)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new AggregateException("產品名稱不能為空");
            }
            //價格必須>0
            if (price <= 0)
            {
                throw new AggregateException("價格必須大於0");
            }
            //數量不能等於0
            if (quantity < 0)
            {
                throw new AggregateException("數量不能等於0");
            }
            //嘗試透過repo新增產品
            
            var product = new Product(_productRepository.GetNexProductID(),name, price, quantity);
            _productRepository.AddProduct(product);
            


        }
        catch (Exception e)
        {
            Console.WriteLine($"錯誤: {e.Message}");
            throw;
        }
    }

    public void UpdateProduct(string? name, decimal price, int quantity)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new AggregateException("產品名稱不能為空");
            }
            //價格必須>0
            if (price <= 0)
            {
                throw new AggregateException("價格必須大於0");
            }
            //數量不能等於0
            if (quantity < 0)
            {
                throw new AggregateException("數量不能等於0");
            }
            //執行更新(覆蓋原本prduct 的屬性)
            product.Name = name;
            product.Price = Price;
            product.Quantity = Quantity;
            product.UpdateProduct();
            //呼叫repo
            _productRepository.UpdateProduct(product);
            Console.WriteLine($"產品ID: {Product.Id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}