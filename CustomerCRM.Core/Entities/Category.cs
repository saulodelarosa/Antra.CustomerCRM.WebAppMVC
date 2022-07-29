using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCRM.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(80)")]
        public string Discription { get; set; }

    }
}
