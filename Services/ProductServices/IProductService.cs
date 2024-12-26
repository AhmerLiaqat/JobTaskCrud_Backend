using JobTaskCrud.Models;
using JobTaskCrud.requestDTOs;
using JobTaskCrud.responseDTOs;
using JobTaskCrud.Utilities;

namespace JobTaskCrud.Services.ProductServices
{
    public interface IProductService
    {
        Task<ApiResponse<Product>> AddProduct(AddProductRequest request);
        Task<ApiResponse<List<GetAllProductResponse>>> GetAllProducts();
        Task<ApiResponse<Product>> UpdateProduct(int id, UpdateProductRequest request);
        Task<ApiResponse<int>> deleteProduct(int id);
    }
}
