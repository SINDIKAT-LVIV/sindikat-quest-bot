using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SINDIKAT.QuestBot.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Quest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpirationTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    HintDelayTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("QuestID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestStep",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestID = table.Column<Guid>(type: "uuid", nullable: false),
                    PreviousQuestStepID = table.Column<Guid>(type: "uuid", nullable: true),
                    NextQuestStepID = table.Column<Guid>(type: "uuid", nullable: true),
                    Answer = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageContent = table.Column<string>(type: "text", nullable: true),
                    QuestStepID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("QuestStepID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestStep_QuestStep_NextQuestStepID",
                        column: x => x.NextQuestStepID,
                        principalSchema: "dbo",
                        principalTable: "QuestStep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestStep_QuestStep_PreviousQuestStepID",
                        column: x => x.PreviousQuestStepID,
                        principalSchema: "dbo",
                        principalTable: "QuestStep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestStep_Quest_QuestID",
                        column: x => x.QuestID,
                        principalSchema: "dbo",
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestID = table.Column<Guid>(type: "uuid", nullable: false),
                    EntryCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TeamID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TeamID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Quest_QuestID",
                        column: x => x.QuestID,
                        principalSchema: "dbo",
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestHint",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestHintID = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageContent = table.Column<string>(type: "text", nullable: true),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    QuestStepID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("QuestHintID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestHint_QuestStep_QuestHintID",
                        column: x => x.QuestHintID,
                        principalSchema: "dbo",
                        principalTable: "QuestStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TeamID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PlayerID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Team_PlayerID",
                        column: x => x.PlayerID,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamQuestStep",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamID = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestID = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestStepID = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TeamQuestStepID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TeamQuestStepID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamQuestStep_QuestStep_QuestStepID",
                        column: x => x.QuestStepID,
                        principalSchema: "dbo",
                        principalTable: "QuestStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestStep_Quest_QuestID",
                        column: x => x.QuestID,
                        principalSchema: "dbo",
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestStep_Team_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamQuestHint",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamID = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestID = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestHintID = table.Column<Guid>(type: "uuid", nullable: false),
                    TeamQuestHintID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamQuestStepID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TeamQuestHintID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamQuestHint_QuestHint_QuestHintID",
                        column: x => x.QuestHintID,
                        principalSchema: "dbo",
                        principalTable: "QuestHint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestHint_Quest_QuestID",
                        column: x => x.QuestID,
                        principalSchema: "dbo",
                        principalTable: "Quest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestHint_TeamQuestStep_TeamQuestHintID",
                        column: x => x.TeamQuestHintID,
                        principalSchema: "dbo",
                        principalTable: "TeamQuestStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamQuestHint_Team_TeamID",
                        column: x => x.TeamID,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Player_PlayerID",
                schema: "dbo",
                table: "Player",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestHint_QuestHintID",
                schema: "dbo",
                table: "QuestHint",
                column: "QuestHintID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestStep_NextQuestStepID",
                schema: "dbo",
                table: "QuestStep",
                column: "NextQuestStepID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestStep_PreviousQuestStepID",
                schema: "dbo",
                table: "QuestStep",
                column: "PreviousQuestStepID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestStep_QuestID",
                schema: "dbo",
                table: "QuestStep",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_QuestID",
                schema: "dbo",
                table: "Team",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestHint_QuestHintID",
                schema: "dbo",
                table: "TeamQuestHint",
                column: "QuestHintID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestHint_QuestID",
                schema: "dbo",
                table: "TeamQuestHint",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestHint_TeamID",
                schema: "dbo",
                table: "TeamQuestHint",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestHint_TeamQuestHintID",
                schema: "dbo",
                table: "TeamQuestHint",
                column: "TeamQuestHintID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestStep_QuestID",
                schema: "dbo",
                table: "TeamQuestStep",
                column: "QuestID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestStep_QuestStepID",
                schema: "dbo",
                table: "TeamQuestStep",
                column: "QuestStepID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamQuestStep_TeamID",
                schema: "dbo",
                table: "TeamQuestStep",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamQuestHint",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "QuestHint",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TeamQuestStep",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "QuestStep",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Quest",
                schema: "dbo");
        }
    }
}
