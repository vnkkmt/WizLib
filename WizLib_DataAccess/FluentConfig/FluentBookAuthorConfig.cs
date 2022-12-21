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
    public class FluentBookAuthorConfig: IEntityTypeConfiguration<Fluent_BookAuthor>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthor> modelBuilder)
        {
            //BookAuthor
            //Many to many
            modelBuilder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            modelBuilder
                .HasOne(g => g.Fluent_Book) //one book many authors
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(f => f.Book_Id);


            modelBuilder
                .HasOne(g => g.fluent_Author) //one author many books
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(f => f.Author_Id);
        }
    }
}
