using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        // Obtener Productos
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string Id);
        Task<IEnumerable<Product>> GetProductByName(string Name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        // Operaciones CRUD
        Task CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string Id);
    }
}
