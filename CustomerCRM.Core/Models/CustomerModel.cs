using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerCRM.Core.Models
{
    public class CustomerModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public int RegionId { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

    }
}
