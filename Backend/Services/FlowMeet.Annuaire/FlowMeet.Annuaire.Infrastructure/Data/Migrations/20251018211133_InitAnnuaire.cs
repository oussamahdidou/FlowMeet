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
                name: "TypeEntites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEntites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entites",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    TypeEntiteId = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Adresse_CodePostal = table.Column<string>(type: "text", nullable: false),
                    Adresse_Pays = table.Column<string>(type: "text", nullable: false),
                    Adresse_Rue = table.Column<string>(type: "text", nullable: false),
                    Adresse_Ville = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entites_Entites_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Entites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entites_TypeEntites_TypeEntiteId",
                        column: x => x.TypeEntiteId,
                        principalTable: "TypeEntites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborateurs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Prenom = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telephone = table.Column<string>(type: "text", nullable: false),
                    EntiteId = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborateurs_Entites_EntiteId",
                        column: x => x.EntiteId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Heritee = table.Column<bool>(type: "boolean", nullable: false),
                    EntiteId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Entites_EntiteId",
                        column: x => x.EntiteId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    Heritee = table.Column<bool>(type: "boolean", nullable: false),
                    EntiteId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Entites_EntiteId",
                        column: x => x.EntiteId,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurGroupes",
                columns: table => new
                {
                    CollaborateurId = table.Column<string>(type: "text", nullable: false),
                    GroupeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurGroupes", x => new { x.GroupeId, x.CollaborateurId });
                    table.ForeignKey(
                        name: "FK_CollaborateurGroupes_Collaborateurs_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaborateurGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollaborateurRoles",
                columns: table => new
                {
                    CollaborateurId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateurRoles", x => new { x.RoleId, x.CollaborateurId });
                    table.ForeignKey(
                        name: "FK_CollaborateurRoles_Collaborateurs_CollaborateurId",
                        column: x => x.CollaborateurId,
                        principalTable: "Collaborateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaborateurRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupes",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    GroupeId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupes", x => new { x.RoleId, x.GroupeId });
                    table.ForeignKey(
                        name: "FK_RoleGroupes_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroupes_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaborateurGroupes_CollaborateurId",
                table: "CollaborateurGroupes",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_CollaborateurRoles_CollaborateurId",
                table: "CollaborateurRoles",
                column: "CollaborateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborateurs_EntiteId",
                table: "Collaborateurs",
                column: "EntiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entites_ParentId",
                table: "Entites",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entites_TypeEntiteId",
                table: "Entites",
                column: "TypeEntiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_EntiteId",
                table: "Groupes",
                column: "EntiteId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupes_GroupeId",
                table: "RoleGroupes",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EntiteId",
                table: "Roles",
                column: "EntiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborateurGroupes");

            migrationBuilder.DropTable(
                name: "CollaborateurRoles");

            migrationBuilder.DropTable(
                name: "RoleGroupes");

            migrationBuilder.DropTable(
                name: "Collaborateurs");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Entites");

            migrationBuilder.DropTable(
                name: "TypeEntites");
        }
    }
}
