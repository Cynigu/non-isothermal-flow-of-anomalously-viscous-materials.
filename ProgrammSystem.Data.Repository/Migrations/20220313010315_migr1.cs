using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramSystem.Data.Repository.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeParameter = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameters_UnitsOfMeas_UnitOfMeasId",
                        column: x => x.UnitOfMeasId,
                        principalTable: "UnitsOfMeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterValues",
                columns: table => new
                {
                    ParameterId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialId = table.Column<int>(type: "INTEGER", nullable: false),
                    CanalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValues", x => new { x.MaterialId, x.ParameterId, x.CanalId });
                    table.ForeignKey(
                        name: "FK_ParameterValues_Canals_CanalId",
                        column: x => x.CanalId,
                        principalTable: "Canals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterValues_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterValues_Parameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Canals",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Канал1" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Полипропилен" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "м" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "кг/м^3" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Дж/(кг·°С)" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "°С" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "м/с" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Па·с^n" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "1/°С" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Вт/(м2·°С)" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "-" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 2, "researcher", "researcher", "researcher" });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 1, "Ширина, W", "Геометрические параметры канала", 1 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 2, "Длина, H", "Геометрические параметры канала", 1 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 3, "Глубина, L", "Геометрические параметры канала", 1 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 4, "Плотность, ρ", "Параметры свойств материала", 2 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 5, "Удельная теплоемкость, c", "Параметры свойств материала", 3 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 6, "Температура плавления, T0", "Параметры свойств материала", 4 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 7, "Скорость крышки, Vu", "Режимные параметры процессаа", 5 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 8, "Температура крышки, Tu", "Режимные параметры процесса", 4 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 9, "Коэффициент консистенции материала при температуре приведения, μ0", "Эмпирические коэффициенты математической модели", 6 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 10, "Температурный коэффициент вязкости материала, b", "Эмпирические коэффициенты математической модели", 7 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 11, "Температура приведения, Tr", "Эмпирические коэффициенты математической модели", 4 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 12, "Индекс течения материала, n", "Эмпирические коэффициенты математической модели", 9 });

            migrationBuilder.InsertData(
                table: "Parameters",
                columns: new[] { "Id", "Name", "TypeParameter", "UnitOfMeasId" },
                values: new object[] { 13, "Коэффициент теплоотдачи от крышки канала к материалу, Tu", "Эмпирические коэффициенты математической модели", 8 });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 1, 0.2f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 2, 0.003f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 3, 7.5f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 4, 900f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 5, 2230f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 6, 172f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 7, 1.5f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 8, 180f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 9, 1500f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 10, 0.014f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 11, 185f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 12, 0.38f });

            migrationBuilder.InsertData(
                table: "ParameterValues",
                columns: new[] { "CanalId", "MaterialId", "ParameterId", "Value" },
                values: new object[] { 1, 1, 13, 1500f });

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_UnitOfMeasId",
                table: "Parameters",
                column: "UnitOfMeasId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValues_CanalId",
                table: "ParameterValues",
                column: "CanalId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterValues_ParameterId",
                table: "ParameterValues",
                column: "ParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterValues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Canals");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Parameters");

            migrationBuilder.DropTable(
                name: "UnitsOfMeas");
        }
    }
}
