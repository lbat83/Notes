﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_API.Entities
{
    public class User
    {   [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }

        public ICollection<Notes> Notes { get; set; }
    }
}
