using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PA.NexDev.Migrations
{
    /// <inheritdoc />
    public partial class q1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestimonialTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestimonialDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartnersTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePartners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_HomePages_HomePageId",
                        column: x => x.HomePageId,
                        principalTable: "HomePages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectPages_ProjectPageId",
                        column: x => x.ProjectPageId,
                        principalTable: "ProjectPages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicePageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCards_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_HomePageId",
                table: "ProjectItems",
                column: "HomePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ProjectPageId",
                table: "ProjectItems",
                column: "ProjectPageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCards_ServicePageId",
                table: "ServiceCards",
                column: "ServicePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPages");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "ContactPages");

            migrationBuilder.DropTable(
                name: "HomePartners");

            migrationBuilder.DropTable(
                name: "ProjectDetails");

            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "ProjectMessages");

            migrationBuilder.DropTable(
                name: "ServiceCards");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "ProjectPages");

            migrationBuilder.DropTable(
                name: "ServicePages");
        }
    }
}
