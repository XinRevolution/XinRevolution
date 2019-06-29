using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class BlogContentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long BlogId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Type { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Reference { get; set; }
    }
}
