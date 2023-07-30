using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }

        public User User { get; set; }
    }

    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn(); //pk  
            builder.Property(x => x.InvoiceType).IsRequired(true).HasMaxLength(50);   
            builder.Property(x => x.InvoiceAmount).IsRequired(true).HasPrecision(10, 4).HasDefaultValue(0);                 
        }

    }
}
