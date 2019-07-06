using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SportStore.Models;
using Moq;
using System.Linq;
using SportStore.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace SportStore.Tests
{
   public class UnitTest2
    {
        [Fact]
        public void Indicates_Selected_Category()
        {
            string categoryToSelect = "Apples";
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name="P1", Category="Apples" },
                new Product {ProductId = 4, Name = "P2", Category="Oranges"},
            }).AsQueryable<Product>());
            NavigationMenuViewComponent target =
                new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            string result = (string)(target.Invoke() as
                ViewViewComponentResult).ViewData["SelectedCategory"];
            Assert.Equal(categoryToSelect, result);
        }
    }
}
