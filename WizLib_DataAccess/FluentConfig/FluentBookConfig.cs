using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Models.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //Name of the table

            //Book
            modelBuilder.HasKey(b => b.Book_Id);

            modelBuilder.Property(u => u.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(u => u.Title).IsRequired();
            modelBuilder.Property(u => u.Price).IsRequired();

            //one to one relation beetween book and bookdetail
            modelBuilder
                .HasOne(g => g.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_Id");

            //one to many relation between book and publisher
            modelBuilder
                .HasOne(g => g.Fluent_Publisher)
                .WithMany(b => b.Fluent_Book).HasForeignKey(f => f.Publisher_Id);
        }
    }
}
