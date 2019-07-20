using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class IssueModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string IssueName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(300)")]
        public string IssueIntro { get; set; }
    }
}
