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
    public class FluentPublisherConfig:IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {

            //publisher
            modelBuilder.HasKey(b => b.Publisher_Id);
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Location).IsRequired();
        }
    }
}
