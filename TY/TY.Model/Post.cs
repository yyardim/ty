using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TY.Model
{
    [Table("Post", Schema = "ty")]
    public class Post
    {
        [Key]
        public long PostId { get; set; }
        public long? ParentPostId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual Person Owner { get; set; }
        public virtual Person Replier { get; set; }
        public virtual Category Category { get; set; }
        public DateTime DateCreated { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }
    }
}
