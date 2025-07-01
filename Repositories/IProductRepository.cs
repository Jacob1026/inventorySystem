using inventorySystem.Models;

namespace inventorySystem.Repositories;

public interface IProductRepository
    {
        List<Product> GetAllProducts();
            
        Product GetProductById(int id);
    }
