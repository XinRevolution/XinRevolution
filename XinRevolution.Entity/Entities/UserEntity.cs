using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Entities
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Account { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Mail { get; set; }
    }
}
