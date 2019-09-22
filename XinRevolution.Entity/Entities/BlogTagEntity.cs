﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Entities
{
    public class BlogTagEntity : BaseEntity
    {
        [Required]
        [Column(TypeName = "int")]
        public int BlogId { get; set; }

        public BlogEntity Blog { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int TagId { get; set; }

        public TagEntity Tag { get; set; }
    }
}
