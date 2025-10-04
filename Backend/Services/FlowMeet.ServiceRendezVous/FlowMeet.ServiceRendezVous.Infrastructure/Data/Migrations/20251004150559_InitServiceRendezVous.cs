using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowMeet.ServiceRendezVous.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitServiceRendezVous : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Adresse_CodePostal = table.Column<string>(type: "text", nullable: false),
                    Adresse_Pays = table.Column<string>(type: "text", nullable: false),
                    Adresse_Rue = table.Column<string>(type: "text", nullable: false),
                    Adresse_Ville = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RendezVousTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Duree = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVousTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupeRendezVousTypes",
                columns: table => new
                {
                    GroupeId = table.Column<string>(type: "text", nullable: false),
                    RendezVousTypeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupeRendezVousTypes", x => new { x.GroupeId, x.RendezVousTypeId });
                    table.ForeignKey(
                        name: "FK_GroupeRendezVousTypes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupeRendezVousTypes_RendezVousTypes_RendezVousTypeId",
                        column: x => x.RendezVousTypeId,
                        principalTable: "RendezVousTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendezVous",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    RendezVousTypeId = table.Column<string>(type: "text", nullable: false),
                    CollaborateurId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendezVous", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RendezVous_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_Collaborateurs_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendezVous_RendezVousTypes_RendezVousTypeId",
                        column: x => x.RendezVousTypeId,
                        principalTable: "RendezVousTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRendezVousTypes",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    RendezVousTypeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRendezVousTypes", x => new { x.RoleId, x.RendezVousTypeId });
                    table.ForeignKey(
                        name: "FK_RoleRendezVousTypes_RendezVousTypes_RendezVousTypeId",
                        column: x => x.RendezVousTypeId,
                        principalTable: "RendezVousTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRendezVousTypes_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupeRendezVousTypes_RendezVousTypeId",
                table: "GroupeRendezVousTypes",
                column: "RendezVousTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_ClientId",
                table: "RendezVous",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_CollaborateurId",
                table: "RendezVous",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_RendezVous_RendezVousTypeId",
                table: "RendezVous",
                column: "RendezVousTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRendezVousTypes_RendezVousTypeId",
                table: "RoleRendezVousTypes",
                column: "RendezVousTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupeRendezVousTypes");

            migrationBuilder.DropTable(
                name: "RendezVous");

            migrationBuilder.DropTable(
                name: "RoleRendezVousTypes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "RendezVousTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
