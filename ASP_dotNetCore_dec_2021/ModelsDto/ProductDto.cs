using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.ModelsDto
{
    public class ProductDto
    {
        [DisplayName("#")]
        public string P_code { get; set; }
        [DisplayName("Description")]
        public string P_descript { get; set; }
        [DisplayName("Date")]
        public DateTime P_InDate { get; set; }
        // public int P_QOH { get; set; }
        // public int P_Min { get; set; }
        [DisplayName("Price,$")]
        public double P_Price { get; set; }
        [DisplayName("Discount")]
        public double P_Discount { get; set; }
        [DisplayName("Vendor")]
        public int? V_code { get; set; }
    }
}
