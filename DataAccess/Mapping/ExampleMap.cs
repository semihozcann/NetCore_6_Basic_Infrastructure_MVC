using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class ExampleMap : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.HasKey(e => e.Id); //Id kolonunun Primary Key olmasını sağlar
            builder.Property(e => e.Id).ValueGeneratedOnAdd(); //Primary Key olan kolonun değerinin bir bir atrmasını sağlar
            builder.Property(e => e.Name).IsRequired(); // //Null olamaz
            builder.Property(e => e.Name).HasMaxLength(50); //50 karakterden uzun olamaz
            builder.Property(e => e.Description).IsRequired(); // NUll olamaz
            builder.Property(e => e.Description).HasMaxLength(250); // 50 karakterden uzun olamaz
            builder.Property(e => e.CreatedDate); 
            builder.Property(e => e.UpdatedDate);
            builder.ToTable("Examples"); //Nesnenin veri tabanındaki oluşacak tablosunun adı
        }
    }
}
