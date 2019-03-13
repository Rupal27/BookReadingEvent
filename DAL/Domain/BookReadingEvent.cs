using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Shared_Library;

namespace DAL.Domain
{


    public class BookReadingEvent : DomainClass
    {
        [Required]
        public EventType EventType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        [MaxLength(4, ErrorMessage = "Duration must be under 4 hours")]
        public string Description { get; set; }
        [MaxLength(50, ErrorMessage = "Description must be within 50 characters")]
        public string OtherDetails { get; set; }
        [MaxLength(500, ErrorMessage = "Other Details must be within 500 characters")]
        public string InviteByEmail { get; set; }
        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}