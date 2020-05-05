using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Entities
{
    public class IssueEntity : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string Intro { get; set; }

        public List<IssueItemEntity> IssueItems { get; set; }

        public List<IssueRelativeLinkEntity> IssueRelativeLinks { get; set; }
    }
}
