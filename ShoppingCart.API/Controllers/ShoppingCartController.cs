using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // Require authentication for all actions 
    public class ShoppingCartController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(AppDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // GET: api/ShoppingCart
        // Method to return all products in the user's shopping cart
        [HttpGet]
        public async Task<ActionResult<ShoppingCarts>> GetCurrentUserCart()
        {
            // Get the currently logged-in user (IdentityUser) from the Identity framework
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                // return an unauthorized response/  User not found
                return Unauthorized();  

            // Find the shopping cart for this user (by user's email)
            var cart = await _db.ShoppingCarts
                                 .Include(c => c.Products)
                                 .ThenInclude(p => p.Category)    // include category info for each product
                                 .FirstOrDefaultAsync(c => c.User == user.Email);

            if (cart == null)
            {
                return NotFound("No shopping cart found for this user.");
            }

            return Ok(cart);
        }

        // POST: api/ShoppingCart/add/5
        // Method to add a product by ID to the shopping cart
        [HttpPost("add/{productId}")]
        public async Task<IActionResult> AddProductToCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            // Find the product to add
            var product = await _db.Products.FindAsync(productId);
            if (product == null)
                return NotFound($"Product with ID {productId} not found.");

            // Get or create the user's cart
            var cart = await _db.ShoppingCarts
                                .Include(c => c.Products)
                                .FirstOrDefaultAsync(c => c.User == user.Email);
            if (cart == null)
            {
                // No cart exists for this user yet, create a new one
                cart = new ShoppingCarts { User = user.Email };
                _db.ShoppingCarts.Add(cart);
            }

            // Add product to cart and save
            cart.Products.Add(product);
            await _db.SaveChangesAsync();

            return NoContent();  // 204: successfully added, no content to return
        }

        // POST: api/ShoppingCart/remove/5
        // Method to remove a product by ID in the shopping cart
        [HttpPost("remove/{productId}")]
        public async Task<IActionResult> RemoveProductFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();  // User not found

            var cart = await _db.ShoppingCarts
                                .Include(c => c.Products)
                                .FirstOrDefaultAsync(c => c.User == user.Email);
            if (cart == null)
            {
                return NotFound("Shopping cart not found.");
            }

            // Find the product in the cart's product list
            var productInCart = cart.Products.FirstOrDefault(p => p.Id == productId);
            if (productInCart == null)
            {
                return NotFound("Product not present in cart.");
            }

            cart.Products.Remove(productInCart);
            await _db.SaveChangesAsync();

            return NoContent();  // item removed successfully
        }

    }
}
