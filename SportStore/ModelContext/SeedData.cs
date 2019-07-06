using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;

namespace SportStore.ModelContext
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

           // context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak", Description = "A boat for one Person",
                        Category = "Watersport", Price = 275
                    },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable",
                                Category = "Watersport", Price = 48.95m
                    },
                    new Product
                    {   Name = "Soccer Ball", Description = "FIFA-approved size and weight",
                        Category = "Soccer", Price = 19.50m},

                    new Product
                    {
                        Name = "Corner Flags", Description = "Give your playing field a professional touch",
                        Category = "Soccer", Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium" , Description="Flat-packed 35,000-seat stadium",
                        Category = "Soccer", Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking cap", Description = "Improve brain efficiency by 75%",
                        Category ="Chess", Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair", Description = "Secretly give you oppoent disadventage",
                        Category = "Chess", Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human chess board", Description="A fun game for the Familly",
                        Category = "Chess", Price = 75
                    }

                    );
                context.SaveChanges();
              
                    }
        }
    }
}
