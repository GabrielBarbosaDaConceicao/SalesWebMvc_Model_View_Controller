﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService ?? throw new ArgumentNullException(nameof(sellerService));
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Seller> sellers = _sellerService.FindAll();

            return View(sellers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.FingAll();
            var viewModel = new SellerFormViewModel
            {
                Departments = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                _sellerService.Insert(seller);

                return RedirectToAction(nameof(Index));
            }

            return BadRequest(ModelState);
        }
    }
}
