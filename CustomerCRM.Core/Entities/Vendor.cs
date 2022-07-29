using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Emailid { get; set; }

        [Column(TypeName = "bit")]
        public Boolean IsActive { get; set; }

    }
}
