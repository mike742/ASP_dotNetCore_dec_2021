using ASP_dotNetCore_dec_2021.Data.Interfaces;
using ASP_dotNetCore_dec_2021.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Controllers
{
    public class VendorsController : Controller
    {
        private readonly IVendorRepo _repository;

        public VendorsController(IVendorRepo repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            var data = _repository.GetAllVendors();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vendor input)
        {
            // return Content("HttpPost Create called");
            try
            {
                _repository.CreateVendor(input);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(input);
            }
        }
    }
}
