using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class TagModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string TagName { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Enable { get; set; }
    }
}
