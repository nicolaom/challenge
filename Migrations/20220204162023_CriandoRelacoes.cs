using Microsoft.EntityFrameworkCore.Migrations;

namespace challenge.Migrations
{
    public partial class CriandoRelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Categorias_CategoriaIdCategoria",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Categorias_CategoriaIdCategoria",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_CategoriaIdCategoria",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_CategoriaIdCategoria",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IdCategoria",
                table: "Receitas",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_IdCategoria",
                table: "Despesas",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Categorias_IdCategoria",
                table: "Despesas",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Categorias_IdCategoria",
                table: "Receitas",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Categorias_IdCategoria",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Categorias_IdCategoria",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Receitas_IdCategoria",
                table: "Receitas");

            migrationBuilder.DropIndex(
                name: "IX_Despesas_IdCategoria",
                table: "Despesas");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Receitas");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Despesas");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Receitas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Despesas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CategoriaIdCategoria",
                table: "Receitas",
                column: "CategoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_CategoriaIdCategoria",
                table: "Despesas",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Categorias_CategoriaIdCategoria",
                table: "Despesas",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Categorias_CategoriaIdCategoria",
                table: "Receitas",
                column: "CategoriaIdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
