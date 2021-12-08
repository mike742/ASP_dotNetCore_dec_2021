using ASP_dotNetCore_dec_2021.Data.Interfaces;
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
    }
}
