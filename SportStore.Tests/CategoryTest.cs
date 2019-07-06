using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportStore.ModelContext;
using SportStore.Models;
using System.Linq;
using SportStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models.ViewModel;


namespace SportStore.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
                Mock<IProductRepository> mock = new Mock<IProductRepository>();
           // Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
               new Product {ProductId = 1, Name = "P1", Category = "Cat1" },
               new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
               new Product {ProductId =3 , Name = "P3", Category = "Cat1"},
               new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
               new Product {ProductId = 5, Name = "P5", Category = "Cat3"}

            }).AsQueryable<Product>());

            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, ProductsListViewModel> GetModel = result =>
             result?.ViewData?.Model as ProductsListViewModel;

            int? res1 = GetModel(target.List("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.List(null))?.PagingInfo.TotalItems;

            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
                }

    }
}
