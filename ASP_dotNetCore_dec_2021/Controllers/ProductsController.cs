using ASP_dotNetCore_dec_2021.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo _repository;
        private readonly IVendorRepo _vendorRepo;

        public ProductsController(IProductRepo repo, IVendorRepo vendorRepo)
        {
            _repository = repo;
            _vendorRepo = vendorRepo;
        }

        public List<string> GetProductsByVendorId(int id)
        {
            var res = _repository.GetAllProducts()
                      .Where(p => p.V_code == id)
                      .Select(p => p.P_descript + "\t$" + p.P_Price + "<br>")
                      .ToList();

            if (res == null || res.Count() == 0)
            {
                return new List<string> { "No Products found" };
            }

            return res;
        }


        // GET: ProductsController
        public ActionResult Index()
        {
            return View(_repository.GetAllProducts());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            var vendors = _vendorRepo.GetAllVendors();

            ViewBag.Vendors = new SelectList(vendors, "V_code", "V_name");
            // ViewData["Vendors"] = new SelectList(vendors, "V_code", "V_name");

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
