using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stratosphere.Migrations
{
    /// <inheritdoc />
    public partial class queueprovideradd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QueueProviderDetailId",
                table: "VirtualHost",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "QueueProviderDetailId",
                table: "Queue",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QueueProviderDto",
                columns: table => new
                {
                    QueueProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ConnectionProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueProviderDto", x => x.QueueProviderId);
                    table.ForeignKey(
                        name: "FK_QueueProviderDto_ConnectionProfile_ConnectionProfileId",
                        column: x => x.ConnectionProfileId,
                        principalTable: "ConnectionProfile",
                        principalColumn: "ConnectionProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueProviderDetailDto",
                columns: table => new
                {
                    QueueProviderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QueueProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueProviderDetailDto", x => x.QueueProviderDetailId);
                    table.ForeignKey(
                        name: "FK_QueueProviderDetailDto_QueueProviderDto_QueueProviderId",
                        column: x => x.QueueProviderId,
                        principalTable: "QueueProviderDto",
                        principalColumn: "QueueProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VirtualHost_QueueProviderDetailId",
                table: "VirtualHost",
                column: "QueueProviderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Queue_QueueProviderDetailId",
                table: "Queue",
                column: "QueueProviderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueProviderDetailDto_QueueProviderId",
                table: "QueueProviderDetailDto",
                column: "QueueProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueProviderDto_ConnectionProfileId",
                table: "QueueProviderDto",
                column: "ConnectionProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Queue_QueueProviderDetailDto_QueueProviderDetailId",
                table: "Queue",
                column: "QueueProviderDetailId",
                principalTable: "QueueProviderDetailDto",
                principalColumn: "QueueProviderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_VirtualHost_QueueProviderDetailDto_QueueProviderDetailId",
                table: "VirtualHost",
                column: "QueueProviderDetailId",
                principalTable: "QueueProviderDetailDto",
                principalColumn: "QueueProviderDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queue_QueueProviderDetailDto_QueueProviderDetailId",
                table: "Queue");

            migrationBuilder.DropForeignKey(
                name: "FK_VirtualHost_QueueProviderDetailDto_QueueProviderDetailId",
                table: "VirtualHost");

            migrationBuilder.DropTable(
                name: "QueueProviderDetailDto");

            migrationBuilder.DropTable(
                name: "QueueProviderDto");

            migrationBuilder.DropIndex(
                name: "IX_VirtualHost_QueueProviderDetailId",
                table: "VirtualHost");

            migrationBuilder.DropIndex(
                name: "IX_Queue_QueueProviderDetailId",
                table: "Queue");

            migrationBuilder.DropColumn(
                name: "QueueProviderDetailId",
                table: "VirtualHost");

            migrationBuilder.DropColumn(
                name: "QueueProviderDetailId",
                table: "Queue");
        }
    }
}
