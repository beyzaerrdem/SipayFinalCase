using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DataAccess.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Block { get; set; }

        public bool Status { get; set; }

        public string Type { get; set; }

        public int Floor { get; set; }

        public int ApartmentNo { get; set; }   

        public User User { get; set; }
    }

    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.Block).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true).HasDefaultValue(true);
            builder.Property(x => x.Type).IsRequired(true).HasMaxLength(4);
            builder.Property(x => x.Floor).IsRequired(true);
            builder.Property(x => x.ApartmentNo).IsRequired(true);
        }

    }
}
