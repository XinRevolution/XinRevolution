using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Key]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Account { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Mail { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public int Authority { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime ModifyDate { get; set; }
    }
}
