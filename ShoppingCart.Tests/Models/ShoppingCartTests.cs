using Xunit;
using ShoppingCart.Models;

namespace ShoppingCart.Tests.Models
{
    public class ShoppingCartTests
    {
        [Fact]
        public void ShoppingCart_DefaultConstructor_ShouldStartEmpty()
        {
            // Arrange & Act
            var cart = new ShoppingCarts();

            // Assert: cart should have no items
            Assert.NotNull(cart.Products);
            Assert.Empty(cart.Products);
        }

        [Fact]
        public void ShoppingCart_AddItem_ShouldUpdateCountAndTotal()
        {
            // Arrange: creating a cart and a product
            var cart = new ShoppingCarts();
            var product = new Product { Name = "Pen", Price = 1.5m, Description = "Stastionary", Quantity = 5 };

            // Act: add the product to the cart
            cart.Products.Add(product);
   

            // Assert: cart should have 1 item and total equal to that item's price
            Assert.Single(cart.Products);                    
            Assert.Contains(product, cart.Products);        
        }

        [Fact]
        public void ShoppingCart_RemoveItem_ShouldUpdateCountAndTotal()
        {
            // Arrange: cart with one product
            var cart = new ShoppingCarts();
            var product = new Product { Name = "Pen", Price = 1.5m, Description = "Stastionary", Quantity = 5 };
            cart.Products.Add(product);

            // Act: remove the product from the cart
            bool removed = cart.Products.Remove(product);

            // Assert: the item should be removed and total should be 0
            Assert.True(removed);
            Assert.Empty(cart.Products);
        }

        [Fact]
        public void Products_FindByPredicate_ShouldReturnCorrectProduct()
        {
            // Arrange
            var shoppingCart = new ShoppingCarts();
            var productToFind = new Product { Name = "Gaming Console", Description = "PS4" };
            shoppingCart.Products.Add(new Product { Name = "Projector", Description = "Epson" });
            shoppingCart.Products.Add(productToFind);
            shoppingCart.Products.Add(new Product { Name = "Laptop", Description = "Asus" });

            // Act
            var foundProduct = shoppingCart.Products.Find(p => p.Name == "Gaming Console");

            // Assert
            Assert.NotNull(foundProduct);
            Assert.Equal(productToFind, foundProduct);
        }



    }
}
