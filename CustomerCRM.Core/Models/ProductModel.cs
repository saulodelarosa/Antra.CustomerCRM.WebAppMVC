using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CustomerCRM.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int QuantityId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public Boolean Discontinued { get; set; }

        public int VendorID { get; set; }

    }
}
