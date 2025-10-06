using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowMeet.Annuaire.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAnnuaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupe",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Heritee = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Heritee = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeEntite",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEntite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupe",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    GroupeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupe", x => new { x.RoleId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_RoleGroupe_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroupe_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entite",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    TypeEntiteId = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<string>(type: "text", nullable: true),
                    Adresse_CodePostal = table.Column<string>(type: "text", nullable: false),
                    Adresse_Pays = table.Column<string>(type: "text", nullable: false),
                    Adresse_Rue = table.Column<string>(type: "text", nullable: false),
                    Adresse_Ville = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entite_Entite_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Entite",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entite_TypeEntite_TypeEntiteId",
                        column: x => x.TypeEntiteId,
                        principalTable: "TypeEntite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborateur",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    EntiteId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborateur_Entite_EntiteId",
                        column: x => x.EntiteId,
                        principalTable: "Entite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurGroupe",
                columns: table => new
                {
                    CollaborateurId = table.Column<string>(type: "text", nullable: false),
                    GroupeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurGroupe", x => new { x.GroupeId, x.CollaborateurId });
                    table.ForeignKey(
                        name: "FK_CollaborateurGroupe_Collaborateur_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaborateurGroupe_Groupe_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurRole",
                columns: table => new
                {
                    CollaborateurId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurRole", x => new { x.RoleId, x.CollaborateurId });
                    table.ForeignKey(
                        name: "FK_CollaborateurRole_Collaborateur_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaborateurRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateur_EntiteId",
                table: "Collaborateur",
                column: "EntiteId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborateurGroupe_CollaborateurId",
                table: "CollaborateurGroupe",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborateurRole_CollaborateurId",
                table: "CollaborateurRole",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Entite_ParentId",
                table: "Entite",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entite_TypeEntiteId",
                table: "Entite",
                column: "TypeEntiteId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupe_GroupeId",
                table: "RoleGroupe",
                column: "GroupeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborateurGroupe");

            migrationBuilder.DropTable(
                name: "CollaborateurRole");

            migrationBuilder.DropTable(
                name: "RoleGroupe");

            migrationBuilder.DropTable(
                name: "Collaborateur");

            migrationBuilder.DropTable(
                name: "Groupe");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Entite");

            migrationBuilder.DropTable(
                name: "TypeEntite");
        }
    }
}
