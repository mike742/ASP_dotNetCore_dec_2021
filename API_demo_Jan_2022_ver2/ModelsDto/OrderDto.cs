using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_demo_Jan_2022_ver2.ModelsDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
