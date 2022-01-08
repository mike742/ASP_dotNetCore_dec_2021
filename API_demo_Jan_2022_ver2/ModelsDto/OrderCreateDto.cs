using System;
using System.Collections.Generic;

namespace API_demo_Jan_2022_ver2.ModelsDto
{
    public class OrderCreateDto
    {
        /*
         No need to send a collection of Product to create an Order.
         Just a collection of existing product ids.
         */
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<int> ProductIds { get; set; }

    }
}
