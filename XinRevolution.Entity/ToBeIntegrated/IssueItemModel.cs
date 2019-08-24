using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueItemModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int", Order = 0)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Reference { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public long IssueId { get; set; }

        public IssueModel Issue { get; set; }
    }
}
