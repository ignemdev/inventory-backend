using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Data.Migrations
{
    public partial class AddModificadorCreadorFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Usuarios_UsuarioId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Usuarios_UsuarioId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Razones_Usuarios_UsuarioId",
                table: "Razones");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Usuarios_UsuarioId",
                table: "Salidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Usuarios_UsuarioId",
                table: "Unidades");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Unidades",
                newName: "ModificadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Unidades_UsuarioId",
                table: "Unidades",
                newName: "IX_Unidades_ModificadorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Salidas",
                newName: "ModificadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Salidas_UsuarioId",
                table: "Salidas",
                newName: "IX_Salidas_ModificadorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Razones",
                newName: "ModificadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Razones_UsuarioId",
                table: "Razones",
                newName: "IX_Razones_ModificadorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Productos",
                newName: "ModificadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_UsuarioId",
                table: "Productos",
                newName: "IX_Productos_ModificadorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Entradas",
                newName: "ModificadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_UsuarioId",
                table: "Entradas",
                newName: "IX_Entradas_ModificadorId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Unidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Salidas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Razones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_CreadorId",
                table: "Unidades",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_CreadorId",
                table: "Salidas",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Razones_CreadorId",
                table: "Razones",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CreadorId",
                table: "Productos",
                column: "CreadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_CreadorId",
                table: "Entradas",
                column: "CreadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Usuarios_CreadorId",
                table: "Entradas",
                column: "CreadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Usuarios_ModificadorId",
                table: "Entradas",
                column: "ModificadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Usuarios_CreadorId",
                table: "Productos",
                column: "CreadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Usuarios_ModificadorId",
                table: "Productos",
                column: "ModificadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Razones_Usuarios_CreadorId",
                table: "Razones",
                column: "CreadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Razones_Usuarios_ModificadorId",
                table: "Razones",
                column: "ModificadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Usuarios_CreadorId",
                table: "Salidas",
                column: "CreadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Usuarios_ModificadorId",
                table: "Salidas",
                column: "ModificadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Usuarios_CreadorId",
                table: "Unidades",
                column: "CreadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Usuarios_ModificadorId",
                table: "Unidades",
                column: "ModificadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Usuarios_CreadorId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Usuarios_ModificadorId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Usuarios_CreadorId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Usuarios_ModificadorId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Razones_Usuarios_CreadorId",
                table: "Razones");

            migrationBuilder.DropForeignKey(
                name: "FK_Razones_Usuarios_ModificadorId",
                table: "Razones");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Usuarios_CreadorId",
                table: "Salidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Salidas_Usuarios_ModificadorId",
                table: "Salidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Usuarios_CreadorId",
                table: "Unidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Unidades_Usuarios_ModificadorId",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Unidades_CreadorId",
                table: "Unidades");

            migrationBuilder.DropIndex(
                name: "IX_Salidas_CreadorId",
                table: "Salidas");

            migrationBuilder.DropIndex(
                name: "IX_Razones_CreadorId",
                table: "Razones");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CreadorId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_CreadorId",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Unidades");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Salidas");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Razones");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Entradas");

            migrationBuilder.RenameColumn(
                name: "ModificadorId",
                table: "Unidades",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Unidades_ModificadorId",
                table: "Unidades",
                newName: "IX_Unidades_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ModificadorId",
                table: "Salidas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Salidas_ModificadorId",
                table: "Salidas",
                newName: "IX_Salidas_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ModificadorId",
                table: "Razones",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Razones_ModificadorId",
                table: "Razones",
                newName: "IX_Razones_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ModificadorId",
                table: "Productos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_ModificadorId",
                table: "Productos",
                newName: "IX_Productos_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ModificadorId",
                table: "Entradas",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_ModificadorId",
                table: "Entradas",
                newName: "IX_Entradas_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Usuarios_UsuarioId",
                table: "Entradas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Usuarios_UsuarioId",
                table: "Productos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Razones_Usuarios_UsuarioId",
                table: "Razones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Salidas_Usuarios_UsuarioId",
                table: "Salidas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Unidades_Usuarios_UsuarioId",
                table: "Unidades",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
