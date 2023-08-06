using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.DataAccess.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO public.\"Apartments\"(\r\n\t \"Block\", \"Status\", \"Type\", \"Floor\", \"ApartmentNo\")\r\n\tVALUES ( 'A', true, '2+1', 3, 10);");
            migrationBuilder.Sql("INSERT INTO public.\"UserLogin\"(\r\n    \"UserName\", \"Email\", \"Password\", \"Role\", \"LastActivity\", \"PasswordRetryCount\", \"Status\")\r\n\tVALUES ('kullanıcı', 'user@gmail.com','32141365', 'user', '2023-08-06 03:42:45.517951+03', 0, 1);");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
