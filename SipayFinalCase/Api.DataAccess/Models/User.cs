using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Tc { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public Apartment Apartment { get; set; }

        public List<Invoice> Invoices { get; set; }

        public List<Vehicle> Vehicles { get; set; }
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
            builder.Property(x => x.Role).IsRequired(true);
                 
            builder.HasMany(x => x.Invoices)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true);

            builder.HasMany(x => x.Vehicles)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.UserId)
              .IsRequired(true);
        }

    }
}
