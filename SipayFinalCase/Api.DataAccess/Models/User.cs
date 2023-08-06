using Api.Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.DataAccess.Models
{
    public class User : IdBaseModel
    {
        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }

        public int UserLoginId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Tc { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string? PlateNo { get; set; }

        public virtual Apartment Apartment { get; set; }

        public virtual UserLogin UserLogin { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Invoice> Invoices { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
      
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Lastname).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Tc).IsRequired(true).HasMaxLength(11);
            builder.Property(x => x.PhoneNumber).IsRequired(true).HasMaxLength(15);
            builder.Property(x => x.Role).IsRequired(true).HasDefaultValue(0);
                 
            builder.HasMany(x => x.Invoices)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true);
        }

    }
}
