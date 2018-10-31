﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApparelStoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApparelStoreWebService.Models.DB;
namespace ApparelStoreApplication.Controllers
{
    public class SearchController : Controller
    {
        SearchService service;
        public SearchController()
        {
            service = new SearchService();
        }
        public IActionResult HomeView()
        {
            return View();
        }
        public IActionResult Search()
        {
            var result=service.GetCategories();
            SelectList list = new SelectList(result, "CategoryId", "CategoryName");
            ViewBag.categories = list;
            return View();
        }
        [HttpPost]
        public IActionResult GetProducts(SubCategory S)
        {
           
            var result = service.GetProducts(S);
            var model = result.Select(c => new ProductViewModel() {
                 CategoryId=c.CategoryId.Value,
                  Description=c.Description,
                   Price=(int)c.Price.Value,
                    ProductId=c.ProductId,
                     ProductImage=c.ProductImage,
                      Quantity=c.Quantity.Value,
                       SubCategoryId=c.SubCategoryId.Value,
                        Title=c.Title,
                         ReorderLevel=c.ReorderLevel.Value

            }).ToList();


            ViewBag.product = model;
            return View();
        }
        public IActionResult PostProducts(List<ProductViewModel> Model)
        {
            return null;
        }
    }
}