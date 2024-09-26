using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stratosphere.Migrations
{
    /// <inheritdoc />
    public partial class queuesnapshotmessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadyMessageCount",
                table: "QueueSnapshot",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnacknowledgedMessageCount",
                table: "QueueSnapshot",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadyMessageCount",
                table: "QueueSnapshot");

            migrationBuilder.DropColumn(
                name: "UnacknowledgedMessageCount",
                table: "QueueSnapshot");
        }
    }
}
