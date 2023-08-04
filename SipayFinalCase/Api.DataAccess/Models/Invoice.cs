using Api.Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.DataAccess.Models
{
    public class Invoice : IdBaseModel
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public string InvoiceType { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal DeptAmount => InvoiceAmount - PaidDept; //borç = İnvoiceAmount - ödenenAmount

        public decimal PaidDept { get; set; } //ödenen = paymentAmount

        public virtual User User { get; set; }
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
