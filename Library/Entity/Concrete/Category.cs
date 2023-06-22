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
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
    }
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.CategoryName).IsRequired(true).HasMaxLength(100);
            builder.HasIndex(x => x.CategoryName).IsUnique();
        }
    }
}
