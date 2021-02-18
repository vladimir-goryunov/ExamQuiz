using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsabilityFactoryExamQuiz.Model.EF.Migrations
{
    public partial class Questionaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerEvents",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ClientTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionEntityId",
                        column: x => x.QuestionEntityId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    AnswerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerAttachments_Answers_AnswerEntityId",
                        column: x => x.AnswerEntityId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttachments_AnswerEntityId",
                table: "AnswerAttachments",
                column: "AnswerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttachments_AnswerId",
                table: "AnswerAttachments",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAttachments_Id",
                table: "AnswerAttachments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Id",
                table: "Answers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionEntityId",
                table: "Answers",
                column: "QuestionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Id",
                table: "Questions",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerAttachments");

            migrationBuilder.DropTable(
                name: "AnswerEvents");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
