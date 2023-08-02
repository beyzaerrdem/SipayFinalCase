using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataAccess.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? PlateNo { get; set; }

        public virtual User User { get; set; }
    }

    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.PlateNo).HasMaxLength(10);             
        }

    }
}
