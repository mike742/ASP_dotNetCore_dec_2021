using API_demo_Jan_2022_ver2.Data;
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
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult Get()
        {
            var orders = _context.Orders
                .Select(o => new OrderDto { Id = o.Id, Name = o.Name, Date = o.Date })
                .ToList();
            var orderProducts = _context.OrderProducts.ToList();

            foreach (var order in orders)
            {
                var productsToAdd = new List<ProductDto>();

                foreach (var op in orderProducts)
                {
                    if (op.OrderId == order.Id)
                    {
                        ProductDto p = _context.Products
                            .Where(p => p.Id == op.ProductId)
                            .Select(p => new ProductDto
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price
                            })
                            .First();
                        productsToAdd.Add(p);
                    }
                }
                order.Products = productsToAdd;
            }

            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
