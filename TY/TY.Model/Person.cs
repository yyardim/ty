using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TY.Model
{
    [Table("Person", Schema = "ty")]
    public class Person
    {
        [Key]
        public long PersonId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(30),MinLength(3)]
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool RememberMe { get; set; }
        public string ImageSource { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<Post> OwnedPosts { get; set; }
        [InverseProperty("Replier")]
        public virtual ICollection<Post> RepliedPosts { get; set; }
    }
}
