using ASAPSystemsAssignment.BL.DTOs;
using ASAPSystemsAssignment.BL.Iservice;
using ASAPSystemsAssignment.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASAPSystemsAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
             _productService = productService;
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddDto product)
        {

           await _productService.AddProduct(product);

            //return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            return Ok(product);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto product)
        {
             
           await _productService.EditProduct(product);

            return Ok(product);
        }

        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
             
            await _productService.RemoveProduct(id);
            return Ok(new { success = true });


        }
    }
}
