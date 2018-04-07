﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_API.Entities
{
    public class Category
    {
        public Category()
        {
            Notes = new HashSet<Notes>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Notes> Notes { get; set; }
    }
}
