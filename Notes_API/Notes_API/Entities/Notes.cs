using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_API.Entities
{
    public class Notes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedOn { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }        
        public bool IsDeleted { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
    }
}
