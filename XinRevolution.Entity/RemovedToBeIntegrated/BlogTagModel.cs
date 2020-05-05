using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
<<<<<<< HEAD:XinRevolution.Entity/RemovedToBeIntegrated/BlogTagModel.cs
    public class BlogTagModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int", Order = 0)]
        public long Id { get; set; }

=======
    public class BlogTagEntity : BaseEntity
    {
>>>>>>> develop:XinRevolution.Entity/Entities/BlogTagEntity.cs
        [Required]
        [Column(TypeName = "int")]
        public long BlogId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public long TagId { get; set; }

        public BlogModel Blog { get; set; }

        public TagModel Tag { get; set; }
    }
}
