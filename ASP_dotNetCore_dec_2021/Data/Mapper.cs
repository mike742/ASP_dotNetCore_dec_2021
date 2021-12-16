using ASP_dotNetCore_dec_2021.Models;
using ASP_dotNetCore_dec_2021.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Data
{
    public class Mapper
    {
        public Product Map(ProductDto input)
        {
            return new Product
            {
                P_code = input.P_code,
                P_descript = input.P_descript,
                P_Discount = input.P_Discount,
                P_InDate = input.P_InDate,
                P_Min = 0,
                P_Price = input.P_Price,
                P_QOH = 0,
                V_code = input.V_code
            };
        }

        public ProductDto Map(Product input)
        {
            return new ProductDto
            {
                P_code = input.P_code,
                P_descript = input.P_descript,
                P_Discount = input.P_Discount,
                P_InDate = input.P_InDate,
                P_Price = input.P_Price,
                V_code = input.V_code
            };
        }
    }
}
