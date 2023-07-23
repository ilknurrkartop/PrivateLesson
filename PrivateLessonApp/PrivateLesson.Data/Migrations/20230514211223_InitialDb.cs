using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrivateLesson.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Graduation = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudents", x => new { x.TeacherId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherStudents_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", null, "Öğrenciler", "Öğrenci", "OGRENCI" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", null, "Öğretmenler", "Öğretmen", "OGRETMEN" },
                    { "df6ed406-7cd0-4bea-9e97-2ccc6820dd71", null, "Yöneticiler", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "BranchName", "CreatedDate", "Description", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3539), "Matematik Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3541), "matematik" },
                    { 2, "Fizik", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3544), "Fizik Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3545), "fizik" },
                    { 3, "Kimya", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3546), "Kimya Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3547), "kimya" },
                    { 4, "Biyoloji", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3548), "Biyoloji Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3549), "biyoloji" },
                    { 5, "Tarih", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3550), "Tarih Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3550), "tarih" },
                    { 6, "Coğrafya", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3552), "Coğrafya Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3552), "cografya" },
                    { 7, "İngilizce", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3553), "İngilizce Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3554), "ingilizce" },
                    { 8, "Almanca", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3555), "Almanca Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3556), "almanca" },
                    { 9, "Fransızca", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3557), "Fransızca Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3558), "fransizca" },
                    { 10, "Felsefe", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3559), "Felsefe Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3559), "felsefe" },
                    { 11, "Müzik", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3561), "Müzik Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3561), "muzik" },
                    { 12, "Resim", new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3563), "Resim Dersleri", true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(3563), "resim" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8751), true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8752), "1.jpg" },
                    { 2, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8755), true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8755), "2.jpg" },
                    { 3, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8756), true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8757), "3.jpg" },
                    { 4, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8758), true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8758), "4.jpg" },
                    { 5, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8760), true, new DateTime(2023, 5, 15, 0, 12, 23, 702, DateTimeKind.Local).AddTicks(8760), "5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0371daa7-4382-42dc-ba70-ebcbc6df86c0", 0, "Bursa", "b096af2d-c885-444e-9899-40d5edaaca14", new DateTime(1994, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "asli.yilmaz@example.com", true, "Aslı", "Kadın", 5, "Yılmaz", false, null, "ASLI.YILMAZ@EXAMPLE.COM", "ASLIYILMAZ", "AQAAAAIAAYagAAAAELK2qsfYH5h+ZNvnY6bWGdcz/KMGxuiHvQwbphVQhS5wFpC2cwED9xopiOwgtVNhzA==", "5555556677", null, false, "1c605536-f74b-4d16-8542-6401f419fac7", false, "asliyilmaz" },
                    { "0485dba7-dec1-4ba7-bf63-9d39f8780383", 0, "Ankara", "5f716869-1557-472a-b1a0-1347e68c1af0", new DateTime(1994, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "elif.akyildiz@example.com", true, "Elif", "Kadın", 5, "Akyıldız", false, null, "ELIF.AKYILDIZ@EXAMPLE.COM", "ELIFAKYILDIZ", "AQAAAAIAAYagAAAAEAfOYmWt13qK/hzKoxdllruAW1x2VQdOJK3S0nFfGrAUgQdJBGZmNCTBm/+luWWi7w==", "5558887766", null, false, "52b05c37-c885-4b67-a654-e17dbc11cc5a", false, "elifakyildiz" },
                    { "0eab65f3-afab-4df4-ac32-b00b8df8b279", 0, "İstanbul", "7cfe80c7-4e31-4596-9063-623094582bb4", new DateTime(1992, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "goksu.demir@example.com", true, "Göksu", "Kadın", 5, "Demir", false, null, "GOKSU.DEMIR@EXAMPLE.COM", "GOKSUDEMIR", "AQAAAAIAAYagAAAAEOTUxgH3fz//yXO5371MYV+ghF2YrMcsi8hZOgR5KsUNgtgk6OkmCcujKbTcfNb8Iw==", "5554443322", null, false, "38305d03-36b0-437f-ab99-c2ab85152c01", false, "goksudemir" },
                    { "239f4830-85da-4de5-a376-07e9455429ee", 0, "İzmir", "a290a8bc-3e3b-4bf2-9c58-0e9779a9d1d4", new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.can@example.com", true, "Murat", "Erkek", 5, "Can", false, null, "MURAT.CAN@EXAMPLE.COM", "MURATCAN", "AQAAAAIAAYagAAAAEAorzwI45Rtnh6Gl6c5m9Dko+OaLMVaGg9l7lBS9zZPV/+Sp55XoJQk8jLLTJl43Jg==", "5556667788", null, false, "7b5d21f5-e580-4001-b472-1ab13f774463", false, "muratcan" },
                    { "2821ee6b-8c36-415f-9458-d4a47d6c2422", 0, "İstanbul", "a07933b0-af53-419a-a920-647575c5e32b", new DateTime(1985, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "murat.gunes@example.com", true, "Murat", "Erkek", 5, "Güneş", false, null, "MURAT.GUNES@EXAMPLE.COM", "MURATGUNES", "AQAAAAIAAYagAAAAEIYDH+xC71GBaWwEF/ImvkAtV6HIZKMEICI2m1gNIOHGd+5lh+sBUXaprlZdAqWhfg==", "5558889999", null, false, "d9d79afc-8d81-490a-a24b-cf37c4c8c72e", false, "muratgunes" },
                    { "3573ec57-5790-4259-b5c5-0aeb42553ed5", 0, "İzmir", "836a90c7-8adf-4610-8236-df38b482e1d7", new DateTime(1980, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ercan.ozturk@example.com", true, "Ercan", "Erkek", 5, "Öztürk", false, null, "ERCAN.OZTURK@EXAMPLE.COM", "ERCANOZTURK", "AQAAAAIAAYagAAAAED/dRNbi7QdYb+trAW/zRactp9j5vNadpwBLtpxsHAdXmdGqMT/OW0/QGFmeWZLjOg==", "5552223344", null, false, "ceef9f33-3270-45a5-a71f-a9226b806b81", false, "ercanozturk" },
                    { "35b2a5a4-fffb-4bd0-8c74-162ffa37bfa2", 0, "İstanbul", "6ee5c37a-da8a-445d-9d7a-dd37e5b0fbed", new DateTime(1997, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ilknurkartop@hotmail.com", true, "İlknur", "Kadın", 5, "Kartop", false, null, "ILKNURKARTOP@HOTMAIL.COM", "ILKNURKARTOP", "AQAAAAIAAYagAAAAELtQsALAUcriNm+0C08A025m+FdxMWXdOcg3HM57JHIjLbVoUkJpRxjGGgcOL0uETg==", "5555555555", null, false, "461a508c-7871-4b6e-875c-2e0554676c7e", false, "ilknurkartop" },
                    { "368a87a2-8d48-4ba4-a95b-a30d0c748b75", 0, "Ankara", "ac6a8832-8f94-4099-8487-4ef99efb21e2", new DateTime(1999, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "umut.celik@example.com", true, "Umut", "Erkek", 3, "Çelik", false, null, "UMUT.CELIK@EXAMPLE.COM", "UMUTCELIK", "AQAAAAIAAYagAAAAEK3B85J1UDRDimgDI79VKXHPCGn0H4wanxJqkDHbNhSKnHf+wH0tPL8tiyFJUFHc1A==", "5552223344", null, false, "33636e6e-3c63-4e9f-a710-ad0e69fe1c4c", false, "umutcelik" },
                    { "37edfc59-d932-49c1-8c1f-f316fb5b3a2f", 0, "Ankara", "7dbf3e24-0658-43c2-b649-4e107ca938e2", new DateTime(1987, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mert.kilic@example.com", true, "Mert", "Erkek", 5, "Kılıç", false, null, "MERT.KILIC@EXAMPLE.COM", "MERTKILIC", "AQAAAAIAAYagAAAAEALiCJXato36tqIosj7Z07y/JB7uyCVwhzvf2LP+tO3IbisdIT1Nyn2DMt0N8ro41Q==", "5551112233", null, false, "bf0ad90d-a775-4b85-9ad2-a856a6cd6e85", false, "mertkilic" },
                    { "39b5b831-f183-4207-9943-fddeb972422e", 0, "İstanbul", "4f64b7c0-8a08-4240-ac98-2d28f5cbaa29", new DateTime(1988, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "aylin.demir@example.com", true, "Aylin", "Kadın", 4, "Demir", false, null, "AYLIN.DEMIR@EXAMPLE.COM", "AYLINDEMIR", "AQAAAAIAAYagAAAAEFta6xfSM50LvC/gLrZ+XzZgd+enYjc617n/5BLcUqIs1vt/Qr+G14h1ZMIGocFX+A==", "5557779900", null, false, "64f001cf-4438-4ce4-8ff4-3b1239a9d272", false, "aylindemir" },
                    { "3e4a1f4f-57c3-4aa1-b13c-275c16517135", 0, "İstanbul", "b2605732-f768-4e54-9443-c93d9c4a7ffa", new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "hatice.aydin@example.com", true, "Hatice", "Kadın", 5, "Aydın", false, null, "HATICE.AYDIN@EXAMPLE.COM", "HATICEAYDIN", "AQAAAAIAAYagAAAAEFnaWcsHaegQRbPKlx8qAUKC24wQ4h0h2grcxInkpJ0o8uhoP3ontE81V3ViJJev6g==", "5551234567", null, false, "480dcc2c-fc57-4f09-9cbc-5f84d7ededa4", false, "haticeaydin" },
                    { "3e8a67d0-7d73-4f8a-892a-126b7eabad6e", 0, "İzmir", "1f42797a-9ed0-486c-b8a5-98037df10f45", new DateTime(1991, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildir@example.com", true, "Emre", "Erkek", 1, "Yıldır", false, null, "EMRE.YILDIR@EXAMPLE.COM", "EMREYILDIR", "AQAAAAIAAYagAAAAENz2Vaeefhwb1LgbVsCRVWcN7lti5NnHsFC0vxCiMT4nj4jKN7c0hSfs3TsBDO+akQ==", "5558887744", null, false, "134ee7ef-1d6e-4666-a70d-60d8e54cf4e7", false, "emreyildir" },
                    { "497aca28-adc3-4c73-999d-2d1004ca46f5", 0, "Antalya", "37317556-2bec-4bc1-911b-6b57a9e20511", new DateTime(1985, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebru.ozturk@example.com", true, "Ebru", "Kadın", 2, "Öztürk", false, null, "EBRU.OZTURK@EXAMPLE.COM", "EBRUOZTURK", "AQAAAAIAAYagAAAAEA3iOvZ/8Ln1TG1QjQv870rsrmCGBSvmBYJsAwXgp1ts9wOVt3axIjtMYlMatqvfpw==", "5552221133", null, false, "ddf35b4b-1758-4ef7-bebf-77de5c989b41", false, "ebruozturk" },
                    { "5b2a821e-0881-4136-aa48-8c852c2304d1", 0, "Ankara", "740415d2-f9ee-42ff-9020-a8436ab7a5d7", new DateTime(1985, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre.yildiz@example.com", true, "Emre", "Erkek", 5, "Yıldız", false, null, "EMRE.YILDIZ@EXAMPLE.COM", "EMREYILDIZ", null, "5301234567", null, false, "0f29957d-4b96-4c0c-9471-7323b31d31e0", false, "emreyildiz" },
                    { "a184b20d-fdc7-4171-b0cb-caca41d49917", 0, "İzmir", "ebe9901c-c70b-4f4e-aad3-e72116fad4a0", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "selin.ozcan@example.com", true, "Selin", "Kadın", 5, "Özcan", false, null, "SELIN.OZCAN@EXAMPLE.COM", "SELINOZCAN", "AQAAAAIAAYagAAAAEA9MqZAF3QHua+qg1n0L7HhBspkVDQON0NFREhExmP/IWa/JAIp09EPab8fkjsjJUg==", "5559876543", null, false, "5c1a91c1-b61e-4cdd-a004-202963a137d9", false, "selinozcan" },
                    { "a1bfaac3-0519-42da-a51e-d93ae59a8c0c", 0, "Ankara", "ebe15832-307f-4d37-b6c8-84645a52a361", new DateTime(1991, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayse.yildiz@example.com", true, "Ayşe", "Kadın", 5, "Yıldız", false, null, "AYSE.YILDIZ@EXAMPLE.COM", "AYSEYILDIZ", "AQAAAAIAAYagAAAAEBrovY741CoYf4IYxrL8FXoSUmi9s3QQIkCW6E7nlSkywZu9s2ogo1V5IApUEEy8lA==", "5553334444", null, false, "6fdbc979-3f2c-4bbd-9443-5416920c3450", false, "ayseyildiz" },
                    { "b8d737f9-b2f7-411c-a7d4-8b6298198bb3", 0, "Antalya", "c0a7a642-50c2-4dc4-9e75-4c21019e629d", new DateTime(1990, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmet.kaya@example.com", true, "Mehmet", "Erkek", 5, "Kaya", false, null, "MEHMET.KAYA@EXAMPLE.COM", "MEHMETKAYA", "AQAAAAIAAYagAAAAELr/iAQdbVXazz8tjJKW9ny/1u5/eo54r7+p+pX70AWhteEa1q0NptTRy8FcxgRJhQ==", "5551112233", null, false, "07148fd2-cde7-415c-8988-0e84c044b447", false, "mehmetkaya" },
                    { "bef59f13-af31-490f-b481-965c72690a34", 0, "Ankara", "57a06a85-1cff-4484-a687-a0e352c5a527", new DateTime(1988, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmet.yilmaz@example.com", true, "Ahmet", "Erkek", 5, "Yılmaz", false, null, "AHMET.YILMAZ@EXAMPLE.COM", "AHMETYILMAZ", "AQAAAAIAAYagAAAAEN1X0pJYHI43nH5BVQeMi5ZzItjG+9P+RV668y5cbbsTsaNfi6Rv9nVlbBLnUmYJ7g==", "5551234567", null, false, "737c5950-daea-4e84-a399-f389b286ec14", false, "ahmetyilmaz" },
                    { "c9ead625-4fb6-49f4-b740-6d06b6d5ba65", 0, "Adana", "636701ee-8f8f-4338-845a-856e445997ab", new DateTime(1996, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.guler@example.com", true, "Ali", "Erkek", 5, "Güler", false, null, "ALI.GULER@EXAMPLE.COM", "ALIGULER", "AQAAAAIAAYagAAAAEA9DpYB3v3+jVi2/wHNT2J1IuLxoiluhCFEa5rmcHPtKyOm2S6W7jevLKw3HMF/7bQ==", "5557778899", null, false, "1d9ebb08-2357-44a4-a333-a709ed2411e1", false, "aliguler" },
                    { "cc9cf0a0-761b-4ffb-b325-e5b3fa8cc436", 0, "Bursa", "289d13d8-af06-4340-aa61-14383b1f45b4", new DateTime(1998, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "seda.dogan@example.com", true, "Seda", "Kadın", 5, "Doğan", false, null, "SEDA.DOGAN@EXAMPLE.COM", "SEDADOGAN", "AQAAAAIAAYagAAAAEGhVrC5eeY9ORRu0+4aqyymHGFztOmDyeoRrcOJoJLyltxkgs0x+ZBCJGe0gXOKuWg==", "5554445566", null, false, "ad688c79-7ed5-47ec-9c06-04c57beaab10", false, "sedadogan" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "0371daa7-4382-42dc-ba70-ebcbc6df86c0" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "0485dba7-dec1-4ba7-bf63-9d39f8780383" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "0eab65f3-afab-4df4-ac32-b00b8df8b279" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "239f4830-85da-4de5-a376-07e9455429ee" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "2821ee6b-8c36-415f-9458-d4a47d6c2422" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "3573ec57-5790-4259-b5c5-0aeb42553ed5" },
                    { "df6ed406-7cd0-4bea-9e97-2ccc6820dd71", "35b2a5a4-fffb-4bd0-8c74-162ffa37bfa2" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "368a87a2-8d48-4ba4-a95b-a30d0c748b75" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "37edfc59-d932-49c1-8c1f-f316fb5b3a2f" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "39b5b831-f183-4207-9943-fddeb972422e" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "3e4a1f4f-57c3-4aa1-b13c-275c16517135" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "3e8a67d0-7d73-4f8a-892a-126b7eabad6e" },
                    { "71b19006-559f-428b-a6be-4ea63e22a91e", "497aca28-adc3-4c73-999d-2d1004ca46f5" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "a184b20d-fdc7-4171-b0cb-caca41d49917" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "a1bfaac3-0519-42da-a51e-d93ae59a8c0c" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "b8d737f9-b2f7-411c-a7d4-8b6298198bb3" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "bef59f13-af31-490f-b481-965c72690a34" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "c9ead625-4fb6-49f4-b740-6d06b6d5ba65" },
                    { "423a3281-5f15-4bf2-a926-7fa56c6278d7", "cc9cf0a0-761b-4ffb-b325-e5b3fa8cc436" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "35b2a5a4-fffb-4bd0-8c74-162ffa37bfa2" },
                    { 2, "bef59f13-af31-490f-b481-965c72690a34" },
                    { 3, "a184b20d-fdc7-4171-b0cb-caca41d49917" },
                    { 4, "b8d737f9-b2f7-411c-a7d4-8b6298198bb3" },
                    { 5, "cc9cf0a0-761b-4ffb-b325-e5b3fa8cc436" },
                    { 6, "2821ee6b-8c36-415f-9458-d4a47d6c2422" },
                    { 7, "a1bfaac3-0519-42da-a51e-d93ae59a8c0c" },
                    { 8, "3573ec57-5790-4259-b5c5-0aeb42553ed5" },
                    { 9, "c9ead625-4fb6-49f4-b740-6d06b6d5ba65" },
                    { 10, "3e4a1f4f-57c3-4aa1-b13c-275c16517135" },
                    { 11, "37edfc59-d932-49c1-8c1f-f316fb5b3a2f" },
                    { 12, "0371daa7-4382-42dc-ba70-ebcbc6df86c0" },
                    { 13, "3e8a67d0-7d73-4f8a-892a-126b7eabad6e" },
                    { 14, "497aca28-adc3-4c73-999d-2d1004ca46f5" },
                    { 15, "368a87a2-8d48-4ba4-a95b-a30d0c748b75" },
                    { 16, "39b5b831-f183-4207-9943-fddeb972422e" },
                    { 17, "239f4830-85da-4de5-a376-07e9455429ee" },
                    { 18, "0485dba7-dec1-4ba7-bf63-9d39f8780383" },
                    { 19, "0eab65f3-afab-4df4-ac32-b00b8df8b279" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(960), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(974), null, "bef59f13-af31-490f-b481-965c72690a34" },
                    { 2, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(980), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(981), null, "a184b20d-fdc7-4171-b0cb-caca41d49917" },
                    { 3, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(983), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(984), null, "b8d737f9-b2f7-411c-a7d4-8b6298198bb3" },
                    { 4, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(986), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(986), null, "cc9cf0a0-761b-4ffb-b325-e5b3fa8cc436" },
                    { 5, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(988), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(988), null, "2821ee6b-8c36-415f-9458-d4a47d6c2422" },
                    { 6, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(991), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(992), null, "a1bfaac3-0519-42da-a51e-d93ae59a8c0c" },
                    { 7, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(993), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(994), null, "3573ec57-5790-4259-b5c5-0aeb42553ed5" },
                    { 8, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(996), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(996), null, "c9ead625-4fb6-49f4-b740-6d06b6d5ba65" },
                    { 9, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(998), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(999), null, "3e4a1f4f-57c3-4aa1-b13c-275c16517135" },
                    { 10, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1002), true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1002), null, "37edfc59-d932-49c1-8c1f-f316fb5b3a2f" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedDate", "Graduation", "IsApproved", "UpdatedDate", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1041), "Kırıkkale Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1042), null, "0371daa7-4382-42dc-ba70-ebcbc6df86c0" },
                    { 2, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1047), "Orta Doğu Teknik Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1048), null, "3e8a67d0-7d73-4f8a-892a-126b7eabad6e" },
                    { 3, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1050), "İstanbul Teknik Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1050), null, "497aca28-adc3-4c73-999d-2d1004ca46f5" },
                    { 4, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1052), "Yıldız Teknik Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1053), null, "368a87a2-8d48-4ba4-a95b-a30d0c748b75" },
                    { 5, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1056), "Akdeniz Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1056), null, "39b5b831-f183-4207-9943-fddeb972422e" },
                    { 6, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1059), "Erciyes Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1060), null, "239f4830-85da-4de5-a376-07e9455429ee" },
                    { 7, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1062), "Çukurova Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1062), null, "0485dba7-dec1-4ba7-bf63-9d39f8780383" },
                    { 8, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1064), "Uludağ Üniversitesi", true, new DateTime(2023, 5, 15, 0, 12, 22, 43, DateTimeKind.Local).AddTicks(1064), null, "0eab65f3-afab-4df4-ac32-b00b8df8b279" }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "BranchId", "CreatedDate", "Description", "IsApproved", "Price", "TeacherId", "UpdatedDate", "Url" },
                values: new object[] { 1, 4, new DateTime(2023, 5, 15, 0, 12, 23, 701, DateTimeKind.Local).AddTicks(1253), "dsdasd", true, 45m, 4, new DateTime(2023, 5, 15, 0, 12, 23, 701, DateTimeKind.Local).AddTicks(1256), "dsdds" });

            migrationBuilder.InsertData(
                table: "TeacherBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 7 },
                    { 10, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherStudents",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 6, 3 },
                    { 5, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BranchId",
                table: "Adverts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_TeacherId",
                table: "Adverts",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AdvertId",
                table: "CartItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AdvertId",
                table: "OrderItems",
                column: "AdvertId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherBranches_BranchId",
                table: "TeacherBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudents_StudentId",
                table: "TeacherStudents",
                column: "StudentId");
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TeacherBranches");

            migrationBuilder.DropTable(
                name: "TeacherStudents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
