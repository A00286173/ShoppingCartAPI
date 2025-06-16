using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // All endpoints require authentication
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        // Endpoint that returns all products.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _db.Products
                                    .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _db.Products
                                   .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound("Product not found.");
            return Ok(product);
        }


        // Get endpoint that takes a category Id and returns all products in that category.
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await _db.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found in the specified category.");
            }

            return Ok(products);
        }


        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }
            
            // Model-state validation
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            //category existance exits
            //var cat = await _db.Categories.FindAsync(product.CategoryId);
            //if (cat == null) 
            //    return BadRequest("Invalid category.");


            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

    }
}
