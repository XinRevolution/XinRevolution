using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueRelativeLinkModel
    {
        [Required]
        [Column(TypeName = "int")]
        public long IssueId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string ResourceName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Url { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string Note { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string ResourceVirtualPath { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string ResourcePhysicalPath { get; set; }
    }
}
