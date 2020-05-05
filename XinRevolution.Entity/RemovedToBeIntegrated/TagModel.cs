using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinRevolution.Entity.Model
{
<<<<<<< HEAD:XinRevolution.Entity/RemovedToBeIntegrated/TagModel.cs
    public class TagModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int", Order = 0)]
        public long Id { get; set; }

=======
    public class TagEntity : BaseEntity
    {
>>>>>>> develop:XinRevolution.Entity/Entities/TagEntity.cs
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool Enable { get; set; }

        public List<BlogTagModel> BlogTags { get; set; }
    }
}
