using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataAccess.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public int Block { get; set; }

        public bool Status { get; set; }

        public int Type { get; set; }

        public int Floor { get; set; }

        public int ApartmentNo { get; set; }   

        public virtual User User { get; set; }
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
