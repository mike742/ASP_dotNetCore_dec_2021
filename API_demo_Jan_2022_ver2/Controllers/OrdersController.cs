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
        public ActionResult Get(int id)
        {
            OrderDto order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDto { Id = o.Id, Name = o.Name, Date = o.Date })
                .FirstOrDefault();

            if (order == null) return NotFound();

            var orderProducts = _context.OrderProducts.ToList();

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

            return Ok(order);
        }

        // POST api/<OrdersController>
        /*
         {
          "name": "New Order",
          "date": "2022-01-08",
          "productIds": [
            1, 2
          ]
        }
         */
        [HttpPost]
        public ActionResult Post(OrderCreateDto value)
        {
            Order newOrder = new Order { 
                Name = value.Name,
                Date = value.Date
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach (var item in value.ProductIds)
            {
                var ohp = new OrderProducts
                {
                    OrderId = newOrder.Id,
                    ProductId = item
                };
                _context.OrderProducts.Add(ohp);
            }

            _context.SaveChanges();


            return Ok();

        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, OrderCreateDto value)
        {
            // Searching an order with given id
            var orderFromDb = _context
                .Orders
                .FirstOrDefault(p => p.Id == id);

            if (orderFromDb == null) return NotFound();

            // Update existing Order properties
            orderFromDb.Name = value.Name;
            orderFromDb.Date = value.Date;


            // Updating products
            var rangeProducts = _context.OrderProducts
                    .Where(op => op.OrderId == id).ToList();

            _context.OrderProducts.RemoveRange(rangeProducts);

            foreach (var item in value.ProductIds)
            {
                var ohp = new OrderProducts
                {
                    OrderId = id,
                    ProductId = item
                };
                _context.OrderProducts.Add(ohp);
            }

            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // another way to find an object
            Order orderToDelete = _context.Orders.Find(id);

            if (orderToDelete == null)
            {
                return NotFound();
            }

            var rangeProducts = _context.OrderProducts
                    .Where(op => op.OrderId == id).ToList();

            _context.OrderProducts.RemoveRange(rangeProducts);
            _context.Orders.Remove(orderToDelete);
            _context.SaveChanges();


            return Ok();
        }
    }
}
