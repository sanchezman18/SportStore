﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModel;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        //public ViewResult List() => View(repository.Products);
        public ViewResult List(string category, int productPage = 1) 
              => View(new ProductsListViewModel {
                 Products = repository.Products
                 .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
               // TotalItems = repository.Products.Count()
               TotalItems = category == null  ? repository.Products.Count() : 
                    repository.Products.Where(c => c.Category == category).Count()
                    
    },
                CurrentCategory = category
});
    }
}