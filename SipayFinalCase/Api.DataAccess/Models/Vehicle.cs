using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api.Base.BaseModel;

namespace Api.DataAccess.Models
{
    public class Vehicle : IdBaseModel
    {
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
