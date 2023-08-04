using Api.Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.DataAccess.Models
{
    public class UserLogin : IdBaseModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public DateTime LastActivity { get; set; }

        public int PasswordRetryCount { get; set; }

        public int Status { get; set; }
    }

    public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
        }
    }
}
