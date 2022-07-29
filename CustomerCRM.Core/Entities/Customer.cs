using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Column(TypeName = "Varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(30)")]
        public string Title { get; set; }

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


    }
}
