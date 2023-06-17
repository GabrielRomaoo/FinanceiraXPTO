using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceiraXPTO.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCelular = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financiamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoFinanciamento = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataUltimoVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financiamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcelas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinanciamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcelas_Financiamento_FinanciamentoId",
                        column: x => x.FinanciamentoId,
                        principalTable: "Financiamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "CPF", "NomeCliente", "NumeroCelular", "UF" },
                values: new object[,]
                {
                    { 1, "46243366073", "José Silva", "21999999999", "PR" },
                    { 2, "67696022024", "André Silva", "21999999998", "SP" },
                    { 3, "48635067088", "Antonio Silva", "21999999997", "SP" },
                    { 4, "88789122046", "Carlos Silva", "21999999996", "RJ" },
                    { 5, "88789122047", "Carlos Silva", "21999999996", "BA" },
                    { 6, "88789122048", "Carlos Silva", "21999999996", "SE" },
                    { 7, "88789122049", "Carlos Silva", "21999999996", "PR" },
                    { 8, "88789122040", "Carlos Silva", "21999999996", "RS" },
                    { 9, "88789122041", "Carlos Silva", "21999999996", "SP" },
                    { 10, "88789122042", "Carlos Silva", "21999999996", "ES" }
                });

            migrationBuilder.InsertData(
                table: "Financiamento",
                columns: new[] { "Id", "CPF", "ClienteId", "DataUltimoVencimento", "TipoFinanciamento", "ValorTotal" },
                values: new object[,]
                {
                    { 1, "46243366073", 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20000m },
                    { 2, "67696022024", 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10000m },
                    { 3, "67696022024", 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5000m },
                    { 4, "48635067088", 3, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 75000m },
                    { 5, "88789122046", 4, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m },
                    { 6, "88789122046", 4, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2000m },
                    { 7, "88789122047", 5, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2000m },
                    { 8, "88789122048", 6, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1000m },
                    { 9, "88789122049", 7, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 6000m },
                    { 10, "88789122041", 8, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8000m },
                    { 11, "88789122042", 9, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1500m }
                });

            migrationBuilder.InsertData(
                table: "Parcelas",
                columns: new[] { "Id", "DataPagamento", "DataVencimento", "FinanciamentoId", "NumeroParcela", "ValorParcela" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4000m },
                    { 2, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4000m },
                    { 3, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 4000m },
                    { 4, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, 4000m },
                    { 5, null, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 4000m },
                    { 6, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1000m },
                    { 7, new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1000m },
                    { 8, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 1000m },
                    { 9, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 1000m },
                    { 10, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 1000m },
                    { 11, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, 1000m },
                    { 12, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, 1000m },
                    { 13, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, 1000m },
                    { 14, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, 1000m },
                    { 15, null, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, 1000m },
                    { 16, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1250m },
                    { 17, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1250m },
                    { 18, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 1250m },
                    { 19, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1250m },
                    { 20, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 15000m },
                    { 21, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 15000m },
                    { 22, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 15000m },
                    { 23, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 15000m },
                    { 24, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 15000m },
                    { 25, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 600m },
                    { 26, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 600m },
                    { 27, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, 600m },
                    { 28, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4, 600m },
                    { 29, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 600m },
                    { 30, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 400m },
                    { 31, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 400m },
                    { 32, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3, 400m },
                    { 33, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4, 400m },
                    { 34, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 400m },
                    { 35, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 400m },
                    { 36, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 400m },
                    { 37, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3, 400m },
                    { 38, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4, 400m },
                    { 39, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, 400m },
                    { 40, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 500m },
                    { 41, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 500m },
                    { 42, null, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 500m },
                    { 43, null, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 500m },
                    { 44, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 250m },
                    { 45, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, 250m },
                    { 46, null, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 3, 250m },
                    { 47, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 250m },
                    { 48, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 3000m },
                    { 49, null, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 3000m },
                    { 50, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 1600m },
                    { 51, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, 1600m },
                    { 52, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3, 1600m },
                    { 53, null, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4, 1600m },
                    { 54, null, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 1600m },
                    { 55, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1, 750m },
                    { 56, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2, 750m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financiamento_ClienteId",
                table: "Financiamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcelas_FinanciamentoId",
                table: "Parcelas",
                column: "FinanciamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcelas");

            migrationBuilder.DropTable(
                name: "Financiamento");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
