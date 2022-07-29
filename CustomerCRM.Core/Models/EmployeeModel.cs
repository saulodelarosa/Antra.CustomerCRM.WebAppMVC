using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CustomerCRM.Core.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string TitleOfCourtesy { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int RegionId { get; set; }

        public int PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public int ReportsTo { get; set; }

        public string PhotoPath { get; set; }
    }
}
