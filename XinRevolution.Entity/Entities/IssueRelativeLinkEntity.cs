using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Entities
{
    public class IssueRelativeLinkEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Note { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string LinkUrl { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string ResourceUrl { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int IssueId { get; set; }

        public IssueEntity Issue { get; set; }
    }
}
