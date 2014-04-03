using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Model;

namespace TY.Data.Configurations
{
    public class TyConfiguration:EntityTypeConfiguration<Post>
    {
        public TyConfiguration()
        {
            //HasMany(t=>t.Replier)
            //    .WithMany(t=>t.OwnedPosts)
            //    .Map(t => 
            //    {
            //        t.ToTable("PersonPosts", "ty");
            //        t.MapLeftKey("PostId");
            //        t.MapRightKey("PersonId");
            //    });
        }
    }
}
