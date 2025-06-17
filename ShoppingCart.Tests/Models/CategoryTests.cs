using Xunit;
using ShoppingCart.Models;


namespace ShoppingCart.Tests.Models
{
    public class CategoryTests
    {
        [Fact]
        public void Category_DefaultConstructor_ShouldInitializeProperties()
        {
            // Arrange & Act
            var category = new Category();

            // Assert: default Id and Name, and an empty Products list
            Assert.Equal(0, category.Id);
            Assert.Null(category.Description);
            Assert.NotNull(category.Products);
            Assert.Empty(category.Products);
        }

        [Fact]
        public void Category_SetProperties_ShouldPersistValues()
        {
            // Arrange
            var category = new Category();

            // Act: set Id and Name
            category.Id = 10;
            category.Description = "Groceries";

            // Assert: the properties should retain the assigned values
            Assert.Equal(10, category.Id);
            Assert.Equal("Groceries", category.Description);
        }

        [Fact]
        public void Category_AddProduct_ShouldIncreaseProductCount()
        {
            // create a category and a product
            var category = new Category { Products = new List<Product>() };
            var product = new Product { Id = 1, Name = "Item", Description = "Test Item", Price = 5.0m, Quantity = 5 };

            // Act: add the product to the category's product list
            category.Products.Add(product);

            // Assert: the product list should contain the product and have count 1
            Assert.Contains(product, category.Products);
            Assert.Equal(1, category.Products.Count);
        }


        [Fact]
        public void Category_RemoveProduct_ShouldDecreaseProductCount()
        {
            // Arrange: category with one product in the list
            var category = new Category { Products = new List<Product>() };
            var product = new Product { Id = 2, Name = "Item2", Price = 3.5m, Description = "Test Item" , Quantity = 5};
            category.Products.Add(product);

            // Act: remove the product from the category's list
            bool removed = category.Products.Remove(product);

            // Assert: the product should be removed
            Assert.True(removed);  // Remove() returns true if the item was found and removed
            Assert.DoesNotContain(product, category.Products);
            Assert.Empty(category.Products);
        }



    }
}
