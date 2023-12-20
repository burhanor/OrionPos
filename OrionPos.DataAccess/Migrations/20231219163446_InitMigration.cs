using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrionPos.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "telephoneDirectories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telephoneDirectories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_telephoneDirectories_AspNetUsers_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "f03f1a16-527e-4baf-a751-9e08dae53fe7", "user1@user.com", false, false, null, "Kullanıcı 1", "USER1@USER.COM", "USER1", "AQAAAAIAAYagAAAAEF9rd8g+NbMaWSDWfZk93cowm9GtQ6fG6NnBbBQI3uS+TxQBxjckr6Zoic3aBKtHzQ==", "0543 812 36 80", false, "5a2fd5fa-37d3-4bae-b1d4-b50459effc7c", false, "user1" },
                    { 2, 0, "cdc909c3-bd74-4d87-b177-8954852aa3b2", "user2@user.com", false, false, null, "Kullanıcı 2", "USER2@USER.COM", "USER2", "AQAAAAIAAYagAAAAEEJnMdeo9vO+jYnPxLt0+67NcV8cMiVLQnKOLPk5K2vCWd//Z7NUhRNy2vrSN4wA6g==", "0543 812 36 81", false, "20f0e749-9045-4e1c-b2d4-5334e0317366", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "telephoneDirectories",
                columns: new[] { "Id", "CreatedDateTime", "CreatedUserId", "FirstName", "IsDeleted", "LastName", "TelephoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 4, 16, 38, 33, 716, DateTimeKind.Local).AddTicks(982), 2, "Kerime", false, "Aydoğan Yozgat", "530 307 08 92" },
                    { 2, new DateTime(2023, 9, 17, 11, 22, 31, 190, DateTimeKind.Local).AddTicks(8374), 1, "Hami", false, "Aydoğdu", "534 955 16 09" },
                    { 3, new DateTime(2023, 8, 7, 12, 46, 32, 649, DateTimeKind.Local).AddTicks(3682), 2, "Thomas", false, "Aygen", "533 782 40 15" },
                    { 4, new DateTime(2023, 11, 7, 15, 55, 8, 543, DateTimeKind.Local).AddTicks(4902), 1, "Güneş", false, "Aykan", "546 350 55 98" },
                    { 5, new DateTime(2023, 9, 7, 16, 3, 12, 585, DateTimeKind.Local).AddTicks(2867), 2, "Elif Feyza", false, "Ayrım", "540 494 24 33" },
                    { 6, new DateTime(2023, 4, 5, 18, 42, 57, 841, DateTimeKind.Local).AddTicks(9405), 1, "Uğur Ali", false, "Aysal", "548 817 28 53" },
                    { 7, new DateTime(2023, 3, 5, 7, 58, 46, 201, DateTimeKind.Local).AddTicks(9823), 2, "Osman Yasin", false, "Aysan", "547 431 04 60" },
                    { 8, new DateTime(2023, 4, 16, 0, 5, 29, 683, DateTimeKind.Local).AddTicks(6724), 1, "Adem", false, "Ayvacık", "541 579 92 52" },
                    { 9, new DateTime(2023, 11, 8, 7, 34, 21, 593, DateTimeKind.Local).AddTicks(3019), 2, "Sera Cansın", false, "Azbay", "538 381 91 18" },
                    { 10, new DateTime(2023, 6, 16, 19, 13, 25, 224, DateTimeKind.Local).AddTicks(7790), 1, "Ali İsmail", false, "Babacan", "543 578 19 47" },
                    { 11, new DateTime(2023, 2, 5, 10, 50, 54, 219, DateTimeKind.Local).AddTicks(9713), 2, "Ruhugül", false, "Babadostu", "548 180 60 72" },
                    { 12, new DateTime(2023, 2, 4, 9, 16, 6, 921, DateTimeKind.Local).AddTicks(4920), 1, "Alçiçek", false, "Bad", "541 631 26 74" },
                    { 13, new DateTime(2023, 10, 1, 15, 27, 12, 42, DateTimeKind.Local).AddTicks(1930), 2, "Memet", false, "Bağcı", "531 167 67 76" },
                    { 14, new DateTime(2023, 10, 14, 8, 34, 28, 805, DateTimeKind.Local).AddTicks(8209), 1, "Mercan", false, "Bağçivan", "533 465 65 16" },
                    { 15, new DateTime(2022, 12, 23, 10, 57, 2, 173, DateTimeKind.Local).AddTicks(6726), 2, "Gökay", false, "Bağış", "533 592 75 55" },
                    { 16, new DateTime(2023, 7, 14, 12, 55, 24, 518, DateTimeKind.Local).AddTicks(4537), 1, "Pırıltı", false, "Bahçeli", "536 856 62 00" },
                    { 17, new DateTime(2023, 11, 2, 8, 0, 32, 715, DateTimeKind.Local).AddTicks(7915), 2, "Özgün", false, "Bahtıyar", "535 178 99 84" },
                    { 18, new DateTime(2023, 1, 23, 19, 46, 52, 564, DateTimeKind.Local).AddTicks(5979), 1, "Özgen", false, "Baka", "541 556 39 38" },
                    { 19, new DateTime(2023, 11, 6, 16, 49, 17, 338, DateTimeKind.Local).AddTicks(7076), 2, "Seung Hun", false, "Baki", "543 519 67 24" },
                    { 20, new DateTime(2023, 5, 3, 21, 57, 45, 822, DateTimeKind.Local).AddTicks(2033), 1, "Gülser", false, "Bal", "541 215 21 00" },
                    { 21, new DateTime(2023, 11, 10, 11, 34, 10, 302, DateTimeKind.Local).AddTicks(364), 2, "Yüksel", false, "Balcı", "539 712 93 55" },
                    { 22, new DateTime(2023, 11, 21, 21, 57, 8, 994, DateTimeKind.Local).AddTicks(850), 1, "Ecren", false, "Baldo", "531 831 79 52" },
                    { 23, new DateTime(2023, 5, 13, 18, 48, 47, 875, DateTimeKind.Local).AddTicks(6390), 2, "Muhammet Raşit", false, "Balı", "534 600 55 51" },
                    { 24, new DateTime(2023, 2, 13, 16, 0, 30, 771, DateTimeKind.Local).AddTicks(896), 1, "Sakıp", false, "Balıoğlu", "541 641 99 20" },
                    { 25, new DateTime(2023, 9, 9, 7, 34, 14, 525, DateTimeKind.Local).AddTicks(7227), 2, "Kazım", false, "Balta", "549 594 36 36" },
                    { 26, new DateTime(2023, 7, 19, 23, 14, 3, 778, DateTimeKind.Local).AddTicks(2321), 1, "Abdullah Atakan", false, "Baluken", "533 279 66 32" },
                    { 27, new DateTime(2023, 1, 24, 10, 7, 13, 714, DateTimeKind.Local).AddTicks(5890), 2, "Coşkun", false, "Baran", "538 343 73 88" },
                    { 28, new DateTime(2023, 5, 12, 5, 39, 24, 570, DateTimeKind.Local).AddTicks(2853), 1, "Serdar Kaan", false, "Barbaros", "534 192 65 99" },
                    { 29, new DateTime(2023, 1, 9, 7, 28, 13, 275, DateTimeKind.Local).AddTicks(1295), 2, "Ezel", false, "Bargan", "540 107 21 17" },
                    { 30, new DateTime(2023, 11, 21, 16, 9, 54, 590, DateTimeKind.Local).AddTicks(1213), 1, "Ayşegül", false, "Barutçuoğlu", "544 487 33 21" },
                    { 31, new DateTime(2023, 5, 8, 8, 46, 18, 833, DateTimeKind.Local).AddTicks(9002), 2, "Sefa Kadir", false, "Başar", "534 324 17 99" },
                    { 32, new DateTime(2023, 12, 1, 15, 8, 46, 472, DateTimeKind.Local).AddTicks(5851), 1, "Elif Etga", false, "Başeğmez", "537 619 30 62" },
                    { 33, new DateTime(2023, 12, 3, 10, 52, 16, 244, DateTimeKind.Local).AddTicks(5488), 2, "Balın", false, "Baştepe", "549 448 37 12" },
                    { 34, new DateTime(2023, 2, 14, 7, 28, 37, 360, DateTimeKind.Local).AddTicks(1108), 1, "Mahperi", false, "Baştopçu", "546 268 83 09" },
                    { 35, new DateTime(2023, 9, 4, 7, 33, 34, 572, DateTimeKind.Local).AddTicks(3384), 2, "Erol Özgür", false, "Baştuğ", "537 810 63 52" },
                    { 36, new DateTime(2023, 10, 16, 23, 47, 36, 367, DateTimeKind.Local).AddTicks(1630), 1, "Atak", false, "Batar", "550 479 16 22" },
                    { 37, new DateTime(2023, 10, 16, 5, 46, 28, 795, DateTimeKind.Local).AddTicks(8362), 2, "Safa", false, "Batga", "547 623 44 35" },
                    { 38, new DateTime(2023, 5, 26, 16, 30, 7, 760, DateTimeKind.Local).AddTicks(3386), 1, "Gökmen", false, "Battal", "533 193 99 52" },
                    { 39, new DateTime(2023, 9, 23, 19, 51, 14, 591, DateTimeKind.Local).AddTicks(2467), 2, "Fazıl Erem", false, "Batuk", "544 516 36 53" },
                    { 40, new DateTime(2023, 11, 7, 22, 48, 55, 482, DateTimeKind.Local).AddTicks(2769), 1, "Bensu", false, "Batur", "535 674 70 29" },
                    { 41, new DateTime(2023, 10, 28, 9, 19, 33, 296, DateTimeKind.Local).AddTicks(1551), 2, "Nazım Orhun", false, "Baturalp", "531 312 46 21" },
                    { 42, new DateTime(2022, 12, 29, 2, 49, 48, 672, DateTimeKind.Local).AddTicks(1816), 1, "Safa Ahmet", false, "Baydar", "537 852 43 40" },
                    { 43, new DateTime(2023, 7, 18, 11, 5, 50, 127, DateTimeKind.Local).AddTicks(4991), 2, "Demircan", false, "Baydil", "549 529 62 20" },
                    { 44, new DateTime(2023, 10, 12, 20, 20, 22, 754, DateTimeKind.Local).AddTicks(2227), 1, "Burçin Kübra", false, "Baykal", "534 764 50 69" },
                    { 45, new DateTime(2023, 12, 2, 2, 53, 37, 290, DateTimeKind.Local).AddTicks(8780), 2, "Derviş Haluk", false, "Baykan", "534 289 24 66" },
                    { 46, new DateTime(2023, 6, 25, 7, 16, 38, 274, DateTimeKind.Local).AddTicks(6444), 1, "Taylan Remzi", false, "Baykuş", "542 390 50 23" },
                    { 47, new DateTime(2023, 6, 9, 12, 14, 19, 405, DateTimeKind.Local).AddTicks(8043), 2, "Abdulvahap", false, "Bayrakoğlu", "545 158 79 99" },
                    { 48, new DateTime(2023, 11, 5, 8, 43, 47, 325, DateTimeKind.Local).AddTicks(4644), 1, "Aygün", false, "Bayram", "545 727 84 03" },
                    { 49, new DateTime(2023, 6, 2, 22, 35, 51, 79, DateTimeKind.Local).AddTicks(165), 2, "Ayla", false, "Baytın", "530 440 20 78" },
                    { 50, new DateTime(2023, 4, 27, 10, 53, 50, 139, DateTimeKind.Local).AddTicks(8180), 1, "Kubilay Barış", false, "Begiç", "544 265 58 89" },
                    { 51, new DateTime(2023, 9, 11, 14, 39, 32, 356, DateTimeKind.Local).AddTicks(2707), 2, "Mustafa Samed", false, "Beğenilmiş", "550 995 95 74" },
                    { 52, new DateTime(2023, 6, 29, 0, 21, 15, 71, DateTimeKind.Local).AddTicks(4861), 1, "Berfin Dilay", false, "Bekaroğlu", "531 574 09 65" },
                    { 53, new DateTime(2022, 12, 30, 23, 41, 56, 382, DateTimeKind.Local).AddTicks(493), 2, "İbrahim Onat", false, "Belge", "533 332 03 27" },
                    { 54, new DateTime(2023, 9, 18, 17, 22, 7, 597, DateTimeKind.Local).AddTicks(8363), 1, "Jutenya", false, "Benan", "542 747 47 85" },
                    { 55, new DateTime(2023, 1, 26, 6, 44, 36, 940, DateTimeKind.Local).AddTicks(9473), 2, "Hulki", false, "Bent", "549 216 83 63" },
                    { 56, new DateTime(2023, 12, 1, 3, 22, 52, 519, DateTimeKind.Local).AddTicks(6295), 1, "Mustafa Doğukan", false, "Berberoğlu", "550 548 49 02" },
                    { 57, new DateTime(2023, 2, 11, 23, 53, 11, 186, DateTimeKind.Local).AddTicks(9842), 2, "Hüner", false, "Berk", "536 639 35 15" },
                    { 58, new DateTime(2023, 11, 15, 7, 48, 16, 711, DateTimeKind.Local).AddTicks(1614), 1, "Buse Gizem", false, "Berker", "540 624 28 83" },
                    { 59, new DateTime(2023, 7, 25, 5, 49, 22, 697, DateTimeKind.Local).AddTicks(5526), 2, "Halime", false, "Beydağ", "536 943 36 92" },
                    { 60, new DateTime(2023, 9, 24, 18, 41, 33, 351, DateTimeKind.Local).AddTicks(5623), 1, "Didem", false, "Bıçaksız", "530 685 14 47" },
                    { 61, new DateTime(2023, 10, 28, 0, 3, 36, 820, DateTimeKind.Local).AddTicks(7693), 2, "Mihrinaz", false, "Bilal", "549 834 17 73" },
                    { 62, new DateTime(2023, 2, 24, 9, 13, 31, 566, DateTimeKind.Local).AddTicks(7265), 1, "Lal", false, "Bilgeç", "544 208 71 72" },
                    { 63, new DateTime(2023, 5, 11, 21, 59, 54, 166, DateTimeKind.Local).AddTicks(6547), 2, "Senay", false, "Bilgen", "542 746 00 01" },
                    { 64, new DateTime(2023, 4, 14, 7, 43, 26, 452, DateTimeKind.Local).AddTicks(520), 1, "Remzi", false, "Bilgi", "533 968 21 11" },
                    { 65, new DateTime(2023, 7, 16, 21, 3, 3, 670, DateTimeKind.Local).AddTicks(5490), 2, "Armağan", false, "Bilgiç", "539 302 07 98" },
                    { 66, new DateTime(2023, 1, 18, 12, 58, 3, 865, DateTimeKind.Local).AddTicks(3165), 1, "Çelik", false, "Bilgir", "536 104 98 52" },
                    { 67, new DateTime(2023, 9, 18, 21, 1, 21, 231, DateTimeKind.Local).AddTicks(5712), 2, "Kübra Tansu", false, "Bilgit", "535 579 23 59" },
                    { 68, new DateTime(2023, 3, 17, 18, 26, 41, 955, DateTimeKind.Local).AddTicks(940), 1, "Uluç Emre", false, "Binbay", "542 236 28 01" },
                    { 69, new DateTime(2023, 12, 1, 15, 2, 4, 619, DateTimeKind.Local).AddTicks(8932), 2, "Mehmet Buğrahan", false, "Birgili", "536 151 20 22" },
                    { 70, new DateTime(2023, 1, 19, 2, 50, 53, 602, DateTimeKind.Local).AddTicks(2337), 1, "Doğuşcan", false, "Biriz", "534 619 87 78" },
                    { 71, new DateTime(2023, 1, 6, 2, 22, 48, 528, DateTimeKind.Local).AddTicks(2069), 2, "Altan", false, "Boy", "533 333 03 12" },
                    { 72, new DateTime(2023, 10, 19, 20, 11, 13, 413, DateTimeKind.Local).AddTicks(9627), 1, "Bengisu", false, "Boya", "530 293 40 63" },
                    { 73, new DateTime(2023, 5, 11, 22, 27, 48, 53, DateTimeKind.Local).AddTicks(4239), 2, "Onur Taylan", false, "Boylu", "539 405 50 93" },
                    { 74, new DateTime(2023, 5, 17, 16, 23, 13, 188, DateTimeKind.Local).AddTicks(3128), 1, "Ayseren", false, "Boyuktaş", "536 574 07 33" },
                    { 75, new DateTime(2023, 12, 15, 0, 57, 53, 913, DateTimeKind.Local).AddTicks(4478), 2, "Pekin", false, "Boz", "532 580 25 65" },
                    { 76, new DateTime(2023, 4, 1, 2, 56, 38, 735, DateTimeKind.Local).AddTicks(6845), 1, "Aksu", false, "Bozdağ", "533 403 07 56" },
                    { 77, new DateTime(2023, 10, 25, 10, 34, 5, 689, DateTimeKind.Local).AddTicks(5562), 2, "Arkan", false, "Bozdemir", "543 358 64 18" },
                    { 78, new DateTime(2023, 6, 18, 21, 1, 7, 173, DateTimeKind.Local).AddTicks(7024), 1, "İltem", false, "Boztepe", "533 293 16 26" },
                    { 79, new DateTime(2023, 3, 8, 6, 12, 16, 821, DateTimeKind.Local).AddTicks(19), 2, "Betül", false, "Bozyer", "536 334 16 76" },
                    { 80, new DateTime(2023, 9, 1, 8, 52, 46, 626, DateTimeKind.Local).AddTicks(9919), 1, "Ogün", false, "Bölge", "532 482 54 94" },
                    { 81, new DateTime(2023, 3, 22, 5, 56, 58, 11, DateTimeKind.Local).AddTicks(1371), 2, "İbrahim Hakkı", false, "Bugey", "544 685 12 54" },
                    { 82, new DateTime(2023, 2, 4, 12, 29, 35, 269, DateTimeKind.Local).AddTicks(6651), 1, "Onay", false, "Buğdaypınarı", "543 801 65 88" },
                    { 83, new DateTime(2023, 4, 1, 4, 59, 42, 786, DateTimeKind.Local).AddTicks(4921), 2, "Cankız", false, "Bulgan", "540 709 31 78" },
                    { 84, new DateTime(2023, 6, 19, 17, 2, 36, 285, DateTimeKind.Local).AddTicks(6850), 1, "Arzucan", false, "Bulgur", "545 755 10 25" },
                    { 85, new DateTime(2023, 9, 19, 14, 51, 37, 557, DateTimeKind.Local).AddTicks(1515), 2, "Asiye", false, "Burabak", "538 179 64 18" },
                    { 86, new DateTime(2023, 2, 6, 11, 25, 34, 371, DateTimeKind.Local).AddTicks(333), 1, "Ahmet Yasin", false, "Burak", "533 297 90 13" },
                    { 87, new DateTime(2023, 12, 2, 0, 51, 44, 404, DateTimeKind.Local).AddTicks(6117), 2, "Yaprak", false, "Bural", "540 795 56 87" },
                    { 88, new DateTime(2023, 1, 4, 8, 19, 52, 99, DateTimeKind.Local).AddTicks(533), 1, "Aleda", false, "Buyuran", "534 733 25 66" },
                    { 89, new DateTime(2023, 12, 5, 0, 17, 26, 633, DateTimeKind.Local).AddTicks(3474), 2, "Can Güney", false, "Bülbül", "533 814 96 96" },
                    { 90, new DateTime(2023, 3, 30, 19, 33, 51, 327, DateTimeKind.Local).AddTicks(5269), 1, "Mahmut Bilal", false, "Bülend", "542 874 20 58" },
                    { 91, new DateTime(2023, 3, 5, 18, 1, 22, 770, DateTimeKind.Local).AddTicks(3343), 2, "Saliha Zeynep", false, "Bülent", "534 561 97 07" },
                    { 92, new DateTime(2023, 6, 5, 5, 56, 6, 825, DateTimeKind.Local).AddTicks(9091), 1, "Melike Dilara", false, "Büyükfırat", "546 822 76 87" },
                    { 93, new DateTime(2023, 10, 23, 12, 35, 53, 271, DateTimeKind.Local).AddTicks(7595), 2, "Hayriye", false, "Büyükgüngör", "539 525 22 11" },
                    { 94, new DateTime(2023, 3, 3, 13, 8, 1, 781, DateTimeKind.Local).AddTicks(7237), 1, "Sebiha", false, "Büyüköztürk", "550 776 86 64" },
                    { 95, new DateTime(2023, 8, 31, 11, 26, 49, 664, DateTimeKind.Local).AddTicks(2023), 2, "Mehmet", false, "Can Akçaözoğlu", "539 495 27 54" },
                    { 96, new DateTime(2023, 12, 7, 10, 14, 18, 492, DateTimeKind.Local).AddTicks(203), 1, "Mehmet Enes", false, "Canan", "534 704 24 01" },
                    { 97, new DateTime(2023, 6, 30, 2, 4, 59, 809, DateTimeKind.Local).AddTicks(5162), 2, "Kurtbey", false, "Canbağı", "533 498 43 45" },
                    { 98, new DateTime(2023, 12, 5, 22, 54, 58, 677, DateTimeKind.Local).AddTicks(6057), 1, "Mustafa Taha", false, "Canbek", "538 438 54 10" },
                    { 99, new DateTime(2023, 6, 7, 9, 25, 45, 162, DateTimeKind.Local).AddTicks(2004), 2, "Sena Nur", false, "Candan", "543 417 93 21" },
                    { 100, new DateTime(2023, 1, 30, 22, 49, 34, 775, DateTimeKind.Local).AddTicks(2405), 1, "Abdullah Emirhan", false, "Caner", "549 113 83 96" }
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
                name: "IX_telephoneDirectories_CreatedUserId",
                table: "telephoneDirectories",
                column: "CreatedUserId");
        }

        /// <inheritdoc />
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
                name: "telephoneDirectories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
