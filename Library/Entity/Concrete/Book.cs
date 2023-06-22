﻿using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int NumberOfBook { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.Publisher).HasMaxLength(100);
        }
    }
}