﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "SoccerTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoccerGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameStatus = table.Column<int>(type: "int", nullable: false),
                    ReporterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HomeSoccerTeamId = table.Column<int>(type: "int", nullable: false),
                    GuestSoccerTeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerGames_AspNetUsers_ReporterId",
                        column: x => x.ReporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_GuestSoccerTeamId",
                        column: x => x.GuestSoccerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerGames_SoccerTeams_HomeSoccerTeamId",
                        column: x => x.HomeSoccerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoccerPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoccerPlayerType = table.Column<int>(type: "int", nullable: false),
                    SoccerTeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerPlayers_SoccerTeams_SoccerTeamId",
                        column: x => x.SoccerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoccerEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoccerGameId = table.Column<int>(type: "int", nullable: false),
                    SoccerPlayerId = table.Column<int>(type: "int", nullable: false),
                    SoccerTeamId = table.Column<int>(type: "int", nullable: false),
                    SoccerEventType = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerEvents_SoccerGames_SoccerGameId",
                        column: x => x.SoccerGameId,
                        principalTable: "SoccerGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerEvents_SoccerPlayers_SoccerPlayerId",
                        column: x => x.SoccerPlayerId,
                        principalTable: "SoccerPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoccerEvents_SoccerTeams_SoccerTeamId",
                        column: x => x.SoccerTeamId,
                        principalTable: "SoccerTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b43aaa03-ef03-4ec8-815b-5c79929361e9", "4b61eda1-7c8a-4c6f-affa-6fa5d40b49b6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ab306a9-ff4c-46ca-a6f9-c47383d928d8", 0, "4436f249-2a6b-4d5f-9162-4c7e3c78f050", "berik.assylbekov@gmail.com", true, false, null, null, "BERIK.ASSYLBEKOV@GMAIL.COM", "BERIK.ASSYLBEKOV@GMAIL.COM", "AQAAAAEAACcQAAAAEJFlVU5r6buwHEZ2VrnGYuEV09vowwfbIhX7bjT9g8b2SsSbujP3ooCvEAxBaUp0eA==", null, false, "8724c1b5-123b-4594-8f44-78c2d17b2c2c", false, "berik.assylbekov@gmail.com" });

            migrationBuilder.InsertData(
                table: "SoccerTeams",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 7, 23, 4, 21, 517, DateTimeKind.Local).AddTicks(4530), null, null, null, "Manchester City" },
                    { 2, new DateTime(2020, 12, 7, 23, 4, 21, 532, DateTimeKind.Local).AddTicks(2590), null, null, null, "Barcelona" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b43aaa03-ef03-4ec8-815b-5c79929361e9", "4ab306a9-ff4c-46ca-a6f9-c47383d928d8" });

            migrationBuilder.InsertData(
                table: "SoccerGames",
                columns: new[] { "Id", "Created", "CreatedBy", "GameStatus", "GuestSoccerTeamId", "HomeSoccerTeamId", "LastModified", "LastModifiedBy", "Name", "ReporterId" },
                values: new object[] { 1, new DateTime(2020, 12, 7, 23, 4, 21, 536, DateTimeKind.Local).AddTicks(4420), null, 0, 2, 1, null, null, "Manchester City vs Barcelona", null });

            migrationBuilder.InsertData(
                table: "SoccerPlayers",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name", "SoccerPlayerType", "SoccerTeamId" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7200), null, null, null, "Cancelo Joao", 1, 1 },
                    { 19, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7330), null, null, null, "Trincao", 3, 2 },
                    { 18, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7320), null, null, null, "Messi Lionel", 3, 2 },
                    { 17, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7320), null, null, null, "de Jong Frenkie", 3, 2 },
                    { 16, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7320), null, null, null, "Puig Ricard", 2, 2 },
                    { 15, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7310), null, null, null, "Coutinho Philippe", 2, 2 },
                    { 14, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7310), null, null, null, "Mingueza Oscar", 1, 2 },
                    { 13, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7310), null, null, null, "Firpo Junior", 1, 2 },
                    { 12, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7310), null, null, null, "Alba Jordi", 1, 2 },
                    { 11, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7300), null, null, null, "Neto", 0, 2 },
                    { 20, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7330), null, null, null, "Koeman Ronald", 4, 2 },
                    { 10, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7300), null, null, null, "Guardiola Pep", 4, 1 },
                    { 9, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7300), null, null, null, "Sterling Raheem", 3, 1 },
                    { 8, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7290), null, null, null, "Gabriel Jesus", 3, 1 },
                    { 7, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7290), null, null, null, "Aguero Sergio", 3, 1 },
                    { 6, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7290), null, null, null, "Foden Phil", 2, 1 },
                    { 5, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7280), null, null, null, "De Bruyne Kevin", 2, 1 },
                    { 4, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7210), null, null, null, "Dias Ruben", 1, 1 },
                    { 2, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(7190), null, null, null, "Ake Nathan", 1, 1 },
                    { 1, new DateTime(2020, 12, 7, 23, 4, 21, 533, DateTimeKind.Local).AddTicks(5790), null, null, null, "Ederson", 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_SoccerEvents_SoccerGameId",
                table: "SoccerEvents",
                column: "SoccerGameId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerEvents_SoccerPlayerId",
                table: "SoccerEvents",
                column: "SoccerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerEvents_SoccerTeamId",
                table: "SoccerEvents",
                column: "SoccerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_GuestSoccerTeamId",
                table: "SoccerGames",
                column: "GuestSoccerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_HomeSoccerTeamId",
                table: "SoccerGames",
                column: "HomeSoccerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerGames_ReporterId",
                table: "SoccerGames",
                column: "ReporterId");

            migrationBuilder.CreateIndex(
                name: "IX_SoccerPlayers_SoccerTeamId",
                table: "SoccerPlayers",
                column: "SoccerTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "SoccerEvents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SoccerGames");

            migrationBuilder.DropTable(
                name: "SoccerPlayers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SoccerTeams");
        }
    }
}
