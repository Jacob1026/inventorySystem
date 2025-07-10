using inventorySystem.Models;

namespace inventorySystem.Repositories;

public interface IProductRepository
{
    List<Product> GetAllProducts();
            
    Product GetProductById(int id);
    void AddProduct(Product product);
    int GetNexProductID();
    void UpdateProduct(object product);
}