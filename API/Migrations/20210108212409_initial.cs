using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cms_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SurName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    Organization = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    OrganizationLink = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    StartingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Experiences_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Link = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menus_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pages_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pages_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parameters_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parameters_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTechs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Users_DeletedUserId",
                        column: x => x.DeletedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectTechs_Users_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CreatedUserId",
                table: "Contents",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_DeletedUserId",
                table: "Contents",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UpdatedUserId",
                table: "Contents",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CreatedUserId",
                table: "Experiences",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_DeletedUserId",
                table: "Experiences",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UpdatedUserId",
                table: "Experiences",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CreatedUserId",
                table: "Menus",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_DeletedUserId",
                table: "Menus",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_UpdatedUserId",
                table: "Menus",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_CreatedUserId",
                table: "Pages",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DeletedUserId",
                table: "Pages",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UpdatedUserId",
                table: "Pages",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_CreatedUserId",
                table: "Parameters",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_DeletedUserId",
                table: "Parameters",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_UpdatedUserId",
                table: "Parameters",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedUserId",
                table: "Projects",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeletedUserId",
                table: "Projects",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UpdatedUserId",
                table: "Projects",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_CreatedUserId",
                table: "ProjectTechs",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_DeletedUserId",
                table: "ProjectTechs",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_ProjectId",
                table: "ProjectTechs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_SkillId",
                table: "ProjectTechs",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechs_UpdatedUserId",
                table: "ProjectTechs",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CreatedUserId",
                table: "Skills",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DeletedUserId",
                table: "Skills",
                column: "DeletedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UpdatedUserId",
                table: "Skills",
                column: "UpdatedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "ProjectTechs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
