using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueRelativeLinkModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Url { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Note { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Reference { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public long IssueId { get; set; }

        public IssueModel Issue { get; set; }
    }
}
