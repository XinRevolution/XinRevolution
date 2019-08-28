//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;

//namespace XinRevolution.Entity.Model
//{
//    public class BlogTagModel
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        [Column(TypeName = "int", Order = 0)]
//        public long Id { get; set; }

//        [Required]
//        [Column(TypeName = "int")]
//        public long BlogId { get; set; }

//        [Required]
//        [Column(TypeName = "int")]
//        public long TagId { get; set; }

//        public BlogModel Blog { get; set; }

//        public TagModel Tag { get; set; }
//    }
//}
