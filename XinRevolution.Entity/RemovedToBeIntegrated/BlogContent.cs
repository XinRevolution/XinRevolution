﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
<<<<<<< HEAD:XinRevolution.Entity/RemovedToBeIntegrated/BlogContent.cs
    public class BlogContent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int", Order = 0)]
        public long Id { get; set; }
        
=======
    public class BlogPostEntity : BaseEntity
    {
>>>>>>> develop:XinRevolution.Entity/Entities/BlogPostEntity.cs
        [Required]
        [Column(TypeName = "smallint")]
        public int Type { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Reference { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public long BlogId { get; set; }

        public BlogModel Blog { get; set; }
    }
}