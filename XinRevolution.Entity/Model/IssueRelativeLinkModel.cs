using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueRelativeLinkModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public long IssueId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string IssueRelativeLinkResouceName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string IssueRelativeLinkUrl { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string IssueRelativeLinkNote { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string IssueRelativeLinkResouceVirtualPath { get; set; }
    }
}
