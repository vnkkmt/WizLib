using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public  DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //we configure fluent API
            //composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            //Book Details
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(b => b.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(b => b.NumberOfChapters).IsRequired();

            //Book
            modelBuilder.Entity<Fluent_Book>().HasKey(b => b.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(u => u.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(u => u.Price).IsRequired();

            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);

            //publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Location).IsRequired();

            //categories
            modelBuilder.Entity<Category>().ToTable("tbl_Category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");

            //one to one relation beetween book and bookdetail
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(g => g.Fluent_BookDetail)
                .WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_Id");

            //one to many relation between book and publisher
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(g => g.Fluent_Publisher)
                .WithMany(b => b.Fluent_Book).HasForeignKey(f =>f.Publisher_Id);


            //Many to many
            modelBuilder.Entity<Fluent_BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(g => g.Fluent_Book) //one book many authors
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(f => f.Book_Id);


            modelBuilder.Entity<Fluent_BookAuthor>()
                .HasOne(g => g.fluent_Author) //one author many books
                .WithMany(b => b.Fluent_BookAuthors).HasForeignKey(f => f.Author_Id);


        }


    }
}
