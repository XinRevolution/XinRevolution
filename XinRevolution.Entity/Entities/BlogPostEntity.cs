﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using XinRevolution.Entity.Enum;

namespace XinRevolution.Entity.Entities
{
    public class BlogPostEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "smallint")]
        public BlogPostReferenceTypeEnum ReferenceType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string ReferenceContent { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int BlogId { get; set; }

        public BlogEntity Blog { get; set; }
    }
}