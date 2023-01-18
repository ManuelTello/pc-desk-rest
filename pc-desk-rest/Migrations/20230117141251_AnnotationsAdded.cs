using Microsoft.EntityFrameworkCore.Migrations;
using pc_desk_rest.Models;

#nullable disable

namespace pcdeskrest.Migrations
{
    /// <inheritdoc />
    public partial class AnnotationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Users;");

            var users = new List<User>()
            {
                new User(){ UserName="Nina", PhoneNumber=123},
                new User(){ UserName="Michurri", PhoneNumber=321}
            };

            foreach(var u in users)
           {
                migrationBuilder.Sql($"INSERT INTO Users(UserName,PhoneNumber) VALUES('{u.UserName}',{u.PhoneNumber});");
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
