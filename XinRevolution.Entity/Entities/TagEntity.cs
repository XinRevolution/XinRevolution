using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Entities
{
    public class TagEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Enable { get; set; }

        public List<BlogTagEntity> BlogTags { get; set; }
    }
}
