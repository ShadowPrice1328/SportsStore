using SportsStore.Models;
using Moq;
using SportsStore.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void CanUseRepository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"}
            }).AsQueryable<Product>());

            HomeController controller = new(mock.Object);

            // Act
            IEnumerable<Product>? result = 
            (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Product[] productArray = result?.ToArray()
                ?? Array.Empty<Product>();
            
            Assert.True(productArray.Length == 2);
            Assert.Equal("P1", productArray[0].Name);
            Assert.Equal("P2", productArray[1].Name);
        }
        
        [Fact]
        public void CanPaginate()
        {
            // Arrange
            Mock<IStoreRepository> mock = new();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"},
            }).AsQueryable());
            HomeController controller = new(mock.Object)
            {
                PageSize = 3
            };

            // Act
            IEnumerable<Product> result =
                (controller.Index(2) as ViewResult)?.ViewData.Model
                    as IEnumerable<Product> ?? Enumerable.Empty<Product>();

            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }
    }
}