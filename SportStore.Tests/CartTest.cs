using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SportStore.Models;
using System.Linq;

namespace SportStore.Tests
{
   public class CartTest
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            Product p1 = new Product { ProductId = 1, Name = "P1", Price =100M };
            Product p2 = new Product { ProductId = 2, Name = "p2", Price = 50M};
            Product p3 = new Product { ProductId = 3, Name = "P3" , Price = 25M};

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);//50
            target.AddItem(p1, 10);
            //target.Clear();

            CartLine[] result = target.Lines.ToArray();

            // Assert.Equal(2, result.Length);
            //Assert.Equal(p1, result[0].Product);
            //Assert.Equal(p2, result[1].Product);
            Assert.Equal(11, result[0].Quantity);
            Assert.Equal(1, result[1].Quantity);

            target.AddItem(p3, 4); //100
            target.AddItem(p2, 1);//50
            target.RemoveLine(p1);
            result = target.Lines.ToArray();
            decimal sum = target.ComputeTotalValue();

              //Assert.Equal(0, target.Lines.Where(p => p.Product == p3).Count());
            Assert.Empty(target.Lines.Where(p => p.Product == p1));
            Assert.Equal(2, result.Count());
            Assert.Equal(200M, sum);

            

        }
    }
}
