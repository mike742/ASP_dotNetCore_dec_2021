using ASP_dotNetCore_dec_2021.Data.Interfaces;
using ASP_dotNetCore_dec_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Data.SqlRepos
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly AppDBContext _context;

        public SqlProductRepo(AppDBContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product input)
        {
            _context.Add(input);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void UndateProduct(Product input)
        {
            throw new NotImplementedException();
        }
    }
}
