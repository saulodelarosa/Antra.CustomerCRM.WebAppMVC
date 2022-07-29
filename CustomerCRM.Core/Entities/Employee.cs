using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string FirstName { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "Varchar(5)")]
        public string TitleOfCourtesy { get; set; }

        [Column(TypeName = "datetime2(7")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "datetime2(7)")]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "Varchar(80)")]
        public string Address { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string City { get; set; }

        public int RegionId { get; set; }

        public int PostalCode { get; set; }

        [Column(TypeName = "Varchar(20)")]
        public string Country { get; set; }

        [Column(TypeName = "Varchar(15)")]
        public string Phone { get; set; }

        public int ReportsTo { get; set; }

        public string PhotoPath{ get; set; }

    }
}
