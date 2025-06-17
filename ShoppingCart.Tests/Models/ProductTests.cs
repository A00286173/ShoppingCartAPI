using Xunit;
using ShoppingCart.Models;


namespace ShoppingCart.Tests.Models
{
    public class ProductTests
    {
        [Fact]
        public void Product_DefaultConstructor_ShouldInitializeProperties()
        {

            // Act
            var product = new Product();

            // Assert: verify all default property values
            Assert.Equal(0, product.Id);
            Assert.Null(product.Name);
            Assert.Equal(0m, product.Price);
            Assert.Null(product.Description);
            Assert.Equal(0, product.Quantity);

            Assert.Equal(0, product.CategoryId);
            Assert.Null(product.Category);
        }
        [Fact]
        public void Product_CanSetAllProperties_Individually()
        {
            // Arrange
            var product = new Product();

            // Act
            product.Name = "TestProduct";
            product.Price = 9.99m;
            product.Description = "A test item";
            product.Quantity = 5;
            product.CategoryId = 42;
            product.Category = "Gadgets";

            // Assert
            Assert.Equal("TestProduct", product.Name);
            Assert.Equal(9.99m, product.Price);
            Assert.Equal("A test item", product.Description);
            Assert.Equal(5, product.Quantity);
            Assert.Equal(42, product.CategoryId);
            Assert.Equal("Gadgets", product.Category);
        }

        [Fact]
        public void Product_SetProperties_ShouldPersistValues()
        {
            // Arrange
            var product = new Product();

            // Act: set properties individually
            product.Id = 5;
            product.Name = "SampleProduct";
            product.Price = 15.0m;

            // Assert: the product's properties should reflect the changes
            Assert.Equal(5, product.Id);
            Assert.Equal("SampleProduct", product.Name);
            Assert.Equal(15.0m, product.Price);
        }

        [Fact]
        public void Product_CanBeAssignedToCategory()
        {
            // Arrange: create a Category and a Product
            var category = new Category { Id = 100, Description = "Electronics", Products = new List<Product>() };
            var product = new Product { Id = 200, Name = "Smartphone", Price = 500m, Description = "Samsung", Quantity = 5 };

            // Act: associate the product with the category
            product.Category = category.Description;
            product.CategoryId = category.Id;
            category.Products.Add(product);

            // Assert: the associations should be set up correctly
            Assert.Equal(category.Description, product.Category);
            Assert.Contains(product, category.Products);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(99.99)]
        public void Product_PriceProperty_ShouldAcceptPositiveValues(decimal price)
        {
            var product = new Product();
            product.Price = price;
            Assert.Equal(price, product.Price);
        }




    }

}
