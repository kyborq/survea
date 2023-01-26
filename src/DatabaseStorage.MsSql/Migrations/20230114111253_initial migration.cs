using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseStorage.MsSql.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailedTestInfo",
                columns: table => new
                {
                    DetailedTestInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageTestCompletionTime = table.Column<int>(type: "int", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedTestInfo", x => x.DetailedTestInfoId);
                });

            migrationBuilder.CreateTable(
                name: "DetailedUserInfo",
                columns: table => new
                {
                    DetailedUserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassedTestCount = table.Column<int>(type: "int", nullable: false),
                    CreatedTestCount = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedUserInfo", x => x.DetailedUserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountMode = table.Column<byte>(type: "tinyint", nullable: false),
                    ReferalCodeId = table.Column<int>(type: "int", nullable: false),
                    DetailedUserInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_DetailedUserInfo_DetailedUserInfoId",
                        column: x => x.DetailedUserInfoId,
                        principalTable: "DetailedUserInfo",
                        principalColumn: "DetailedUserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferalCode",
                columns: table => new
                {
                    ReferalCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferalCode", x => x.ReferalCodeId);
                    table.ForeignKey(
                        name: "FK_ReferalCode_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    QuestionCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    DetailedTestInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Test_DetailedTestInfo_DetailedTestInfoId",
                        column: x => x.DetailedTestInfoId,
                        principalTable: "DetailedTestInfo",
                        principalColumn: "DetailedTestInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTag",
                columns: table => new
                {
                    TagsTagId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTag", x => new { x.TagsTagId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_UserTag_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTag_User_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedTest",
                columns: table => new
                {
                    TestPassingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedTest", x => x.TestPassingId);
                    table.ForeignKey(
                        name: "FK_PassedTest_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassedTest_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TestTag",
                columns: table => new
                {
                    TagsTagId = table.Column<int>(type: "int", nullable: false),
                    TestsTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTag", x => new { x.TagsTagId, x.TestsTestId });
                    table.ForeignKey(
                        name: "FK_TestTag_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestTag_Test_TestsTestId",
                        column: x => x.TestsTestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNumber = table.Column<int>(type: "int", nullable: false),
                    QuestionType = table.Column<byte>(type: "tinyint", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TestPassingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answer_PassedTest_TestPassingId",
                        column: x => x.TestPassingId,
                        principalTable: "PassedTest",
                        principalColumn: "TestPassingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_TestPassingId",
                table: "Answer",
                column: "TestPassingId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedTest_TestId",
                table: "PassedTest",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedTest_UserId",
                table: "PassedTest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferalCode_OwnerId",
                table: "ReferalCode",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_DetailedTestInfoId",
                table: "Test",
                column: "DetailedTestInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_OwnerId",
                table: "Test",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestTag_TestsTestId",
                table: "TestTag",
                column: "TestsTestId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DetailedUserInfoId",
                table: "User",
                column: "DetailedUserInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_UsersUserId",
                table: "UserTag",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "ReferalCode");

            migrationBuilder.DropTable(
                name: "TestTag");

            migrationBuilder.DropTable(
                name: "UserTag");

            migrationBuilder.DropTable(
                name: "PassedTest");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "DetailedTestInfo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DetailedUserInfo");
        }
    }
}
