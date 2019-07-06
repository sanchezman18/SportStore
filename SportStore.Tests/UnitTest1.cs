using System;
using Xunit;
using Moq;
using SportStore.Models;
using SportStore.Controllers;
using System.Linq;
using System.Collections.Generic;
using SportStore.Models.ViewModel;

namespace SportStore.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1" , Category = "cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "cat3"},
                new Product {ProductId = 5, Name = "P5", Category = "cat2"}

            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //   ProductsListViewModel result =
            //      controller.List(null, 2).ViewData.Model as ProductsListViewModel ;

            Product[] result = (controller.List("cat1", 1).ViewData.Model as ProductsListViewModel).Products.ToArray();

            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P1" && result[0].Category == "cat1");
            Assert.True(result[1].Name == "P3" && result[1].Category == "cat1");
        }
    }
}
