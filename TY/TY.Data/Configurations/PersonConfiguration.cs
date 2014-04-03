using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TY.Model;

namespace TY.Data.Configurations
{
    public class PersonConfiguration:EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            //Properties
            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(75);

            Property(t => t.MiddleName)
                .HasMaxLength(75);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(75);

            Property(t => t.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
