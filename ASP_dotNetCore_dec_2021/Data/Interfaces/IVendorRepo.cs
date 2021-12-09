using ASP_dotNetCore_dec_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_dotNetCore_dec_2021.Data.Interfaces
{
    public interface IVendorRepo
    {
        // CRUD
            IEnumerable<Vendor> GetAllVendors();
            Vendor GetVendorById(int id);

            void CreateVendor(Vendor input);
            void UndateVendor(Vendor input);
            void DeleteVendor(int id);
    }
}
