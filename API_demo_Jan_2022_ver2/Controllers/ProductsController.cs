using API_demo_Jan_2022_ver2.Data;
using API_demo_Jan_2022_ver2.Models;
using API_demo_Jan_2022_ver2.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_demo_Jan_2022_ver2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = _context.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound(); // 404
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(ProductCreateDto value)
        {
            Product productToAdd = new Product { 
                Name = value.Name,
                Price = value.Price
            };

            _context.Products.Add(productToAdd);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")] // Update
        public ActionResult Put(int id, ProductCreateDto value)
        {
            var productFromDb = _context.Products.FirstOrDefault(p => p.Id == id);

            if (productFromDb == null) return NotFound();

            productFromDb.Name = value.Name;
            productFromDb.Price = value.Price;

            _context.SaveChanges();

            return Ok(); // 200
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var productFromDb = _context.Products.FirstOrDefault(p => p.Id == id);

            if (productFromDb == null) return NotFound();

            _context.Products.Remove(productFromDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
