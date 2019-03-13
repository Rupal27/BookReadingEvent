using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Library;

namespace DAL.Domain
{
    public class Comments : DomainClass
    {
        public int? BookReadingEventID { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string EmailID { get; set; }

        [ForeignKey("BookReadingEventID")]
        public virtual BookReadingEvent BookReadingEvent { get; set; }
    }
}
