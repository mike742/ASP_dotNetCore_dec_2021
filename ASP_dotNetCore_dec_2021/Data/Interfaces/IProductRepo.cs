using ASP_dotNetCore_dec_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Data.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct(Product input);
        void UndateProduct(Product input);
        void DeleteProduct(int id);

    }
}
