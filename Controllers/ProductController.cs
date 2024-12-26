using JobTaskCrud.requestDTOs;
using JobTaskCrud.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace JobTaskCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region PROPERTIES
        private readonly IProductService _productService;
        #endregion

        #region CONSTRUCTOR
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region FUNCTION
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }
        /// <summary>
        /// this method is used to Add Product.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var result = await _productService.AddProduct(request);
            return Ok(result);
        }
        /// <summary>
        /// This Method is used to Update Product.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id,UpdateProductRequest request)
        {
            var result = await _productService.UpdateProduct(Id,request);
            return Ok(result);
        }
        /// <summary>
        /// This Method is used to Delete Product.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var result = await _productService.deleteProduct(Id);
            return Ok(result);
        }
        #endregion

    }
}
