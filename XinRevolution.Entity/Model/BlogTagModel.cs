using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class BlogTagModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long BlogId { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long TagId { get; set; }
    }
}
