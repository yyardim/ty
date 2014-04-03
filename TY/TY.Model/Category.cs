using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TY.Model
{
    [Table("Category", Schema = "ty")]
    public class Category
    {
        private ICollection<Category> _parentCategories;
        private ICollection<Category> _childCategories;
        private ICollection<Post> _posts;

        public Category()
        {
            _parentCategories = new List<Category>();
            _childCategories = new List<Category>();
            _posts = new List<Post>();
        }

        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateModified { get; set; }
        public virtual ICollection<Category> ParentCategories 
        {
            get { return _parentCategories; }
            set { _parentCategories = value; }
        }
        public virtual ICollection<Category> ChildCategories
        {
            get { return _childCategories; }
            set { _childCategories = value; }
        }
        public virtual ICollection<Post> Posts
        {
            get { return _posts; }
            set { _posts = value; }
        }        
    }
}
