using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Core.Models
{
    public class VendorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Mobile { get; set; }

        public string EmailId { get; set; }
        public Boolean IsActive { get; set; }
    }
}
