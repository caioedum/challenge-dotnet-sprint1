using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeDotnet.Migrations
{
    /// <inheritdoc />
    public partial class firstExec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIO_ODONTOPREV",
                columns: table => new
                {
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CPF = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SOBRENOME = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GENERO = table.Column<string>(type: "NVARCHAR2(1)", maxLength: 1, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO_ODONTOPREV", x => x.USUARIO_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_ATENDIMENTO_USUARIO_ODONTOPREV",
                columns: table => new
                {
                    ATENDIMENTO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", maxLength: 10, nullable: false),
                    DENTISTA_NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CLINICA_NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DATA_ATENDIMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DESCRICAO_PROCEDIMENTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CUSTO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    DATA_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ATENDIMENTO_USUARIO_ODONTOPREV", x => x.ATENDIMENTO_ID);
                    table.ForeignKey(
                        name: "FK_T_ATENDIMENTO_USUARIO_ODONTOPREV_T_USUARIO_ODONTOPREV_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "T_USUARIO_ODONTOPREV",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_IMAGEM_USUARIO_ODONTOPREV",
                columns: table => new
                {
                    IMAGEM_USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", maxLength: 10, nullable: false),
                    IMAGEM_URL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DATA_ENVIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_IMAGEM_USUARIO_ODONTOPREV", x => x.IMAGEM_USUARIO_ID);
                    table.ForeignKey(
                        name: "FK_T_IMAGEM_USUARIO_ODONTOPREV_T_USUARIO_ODONTOPREV_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "T_USUARIO_ODONTOPREV",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_PREVISAO_USUARIO_ODONTOPREV",
                columns: table => new
                {
                    PREVISAO_USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IMAGEM_USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PREVISAO_TEXTO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    PROBABILIDADE = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    RECOMENDACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DATA_PREVISAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PREVISAO_USUARIO_ODONTOPREV", x => x.PREVISAO_USUARIO_ID);
                    table.ForeignKey(
                        name: "FK_T_PREVISAO_USUARIO_ODONTOPREV_T_IMAGEM_USUARIO_ODONTOPREV_IMAGEM_USUARIO_ID",
                        column: x => x.IMAGEM_USUARIO_ID,
                        principalTable: "T_IMAGEM_USUARIO_ODONTOPREV",
                        principalColumn: "IMAGEM_USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PREVISAO_USUARIO_ODONTOPREV_T_USUARIO_ODONTOPREV_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "T_USUARIO_ODONTOPREV",
                        principalColumn: "USUARIO_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ATENDIMENTO_USUARIO_ODONTOPREV_USUARIO_ID",
                table: "T_ATENDIMENTO_USUARIO_ODONTOPREV",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_IMAGEM_USUARIO_ODONTOPREV_USUARIO_ID",
                table: "T_IMAGEM_USUARIO_ODONTOPREV",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_PREVISAO_USUARIO_ODONTOPREV_IMAGEM_USUARIO_ID",
                table: "T_PREVISAO_USUARIO_ODONTOPREV",
                column: "IMAGEM_USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_T_PREVISAO_USUARIO_ODONTOPREV_USUARIO_ID",
                table: "T_PREVISAO_USUARIO_ODONTOPREV",
                column: "USUARIO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ATENDIMENTO_USUARIO_ODONTOPREV");

            migrationBuilder.DropTable(
                name: "T_PREVISAO_USUARIO_ODONTOPREV");

            migrationBuilder.DropTable(
                name: "T_IMAGEM_USUARIO_ODONTOPREV");

            migrationBuilder.DropTable(
                name: "T_USUARIO_ODONTOPREV");
        }
    }
}
