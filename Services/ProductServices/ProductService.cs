using AutoMapper;
using JobTaskCrud.Common.GenericRepository;
using JobTaskCrud.Models;
using JobTaskCrud.requestDTOs;
using JobTaskCrud.responseDTOs;
using JobTaskCrud.Services.ProductServices;
using JobTaskCrud.Utilities;

namespace JobTaskCrud.Repositories.ProductRepository
{
    public class ProductService : IProductService
    {
        #region PROPERTIES
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public ProductService(IGenericRepository<Product> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region FUNCTION
        public async Task<ApiResponse<Product>> AddProduct(AddProductRequest request)
        {
            try
            {
                var product = new Product
                {
                    name = request.name,
                    price = request.price,
                };
                var result = await _repository.AddAsync(product);
                await _repository.commitAsync();
                return  ApiResponse<Product>.Success(result,message:"Product Added SuccessFully");
            }
            catch (Exception ex)
            {
               return ApiResponse<Product>.Failure(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse<List<GetAllProductResponse>>> GetAllProducts()
        {
            try
            {
                var result = _mapper.Map<List<GetAllProductResponse>>( await _repository.GetAllAsync());
               return ApiResponse<List<GetAllProductResponse>>.Success(result, message: "Get All Product Response");
           
            }
            catch (Exception ex)
            {
                return ApiResponse<List<GetAllProductResponse>>.Failure(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse<Product>> UpdateProduct(int id, UpdateProductRequest request)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    throw new Exception("Product Id Not Found");
                }    
                product.name = request.name;
                product.price = request.price;
             
                var result =await _repository.UpdateAsync(product);
                await _repository.commitAsync();
                return ApiResponse<Product>.Success(result, message: "Product Updated SuccessFully");
            }
            catch (Exception ex)
            {
                return ApiResponse<Product>.Failure(ex.Message.ToString());
            }
        }

        public async Task<ApiResponse<int>> deleteProduct(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    throw new Exception("Product Id Not Found");
                }
                await _repository.DeleteAsync(product);
                return ApiResponse<int>.Success(id, message: "Product Deleted SuccessFully");
            }
            catch (Exception ex)
            {
               return ApiResponse<int>.Failure(ex.Message.ToString());
            }
        }
        #endregion
    }
}
