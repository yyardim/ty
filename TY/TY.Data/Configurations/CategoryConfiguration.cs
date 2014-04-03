using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Model;

namespace TY.Data.Configurations
{
    public class CategoryConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            // Primary Key
            HasKey(t => t.CategoryId);

            // Properties
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            Property(t => t.Description)
                .HasMaxLength(500);

            HasMany(t => t.ChildCategories)
                .WithMany(t => t.ParentCategories)
                .Map(m => m
                    .ToTable("CategoryHierarchy", "ty")
                    .MapRightKey("CategoryId")
                    .MapLeftKey("ParentCategoryId")
                );
        }
    }
}
