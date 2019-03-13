using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library
{
    public interface IDomain
    {
        [Required]
        int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        DateTime CreatedOn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        DateTime ModifiedOn {get; set;}
    }
}
