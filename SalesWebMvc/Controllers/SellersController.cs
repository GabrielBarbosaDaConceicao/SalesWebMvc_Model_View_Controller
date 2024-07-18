using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService ?? throw new ArgumentNullException(nameof(sellerService));
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
            return View();
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
