using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library
{
    public class DomainClass : IDomain
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DataType((DataType.Date))]
        public DateTime ModifiedOn { get; set; }
    }
}
