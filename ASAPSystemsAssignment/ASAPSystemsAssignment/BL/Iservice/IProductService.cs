using ASAPSystemsAssignment.BL.DTOs;
using ASAPSystemsAssignment.DAL.Model;

namespace ASAPSystemsAssignment.BL.Iservice
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(ProductAddDto model);
        Task EditProduct(ProductDto model);
        Task RemoveProduct(int id);
    }
}
