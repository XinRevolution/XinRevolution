using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class BlogModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 1)]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)", Order = 2)]
        public string Date { get; set; }
    }
}
