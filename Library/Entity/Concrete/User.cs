using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }=false;
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(250);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Password).IsRequired(true);
        }
    }
}
