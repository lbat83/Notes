using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_API.Entities
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
