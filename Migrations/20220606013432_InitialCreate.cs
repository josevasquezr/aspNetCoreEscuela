using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspNetCoreEscuela.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escuela",
                columns: table => new
                {
                    EscuelaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AnioDeCreacion = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    TipoEscuela = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuela", x => x.EscuelaID);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EscuelaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jornada = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                    table.ForeignKey(
                        name: "FK_Curso_Escuela_EscuelaID",
                        column: x => x.EscuelaID,
                        principalTable: "Escuela",
                        principalColumn: "EscuelaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoID);
                    table.ForeignKey(
                        name: "FK_Alumno_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    AsignaturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CursoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.AsignaturaID);
                    table.ForeignKey(
                        name: "FK_Asignatura_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    EvaluacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlumnoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsignaturaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nota = table.Column<float>(type: "real", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.EvaluacionID);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Alumno_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Asignatura_AsignaturaID",
                        column: x => x.AsignaturaID,
                        principalTable: "Asignatura",
                        principalColumn: "AsignaturaID");
                });

            migrationBuilder.InsertData(
                table: "Escuela",
                columns: new[] { "EscuelaID", "AnioDeCreacion", "Ciudad", "Direccion", "Nombre", "Pais", "TipoEscuela" },
                values: new object[] { new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 2005, "Bogota", "Avd Siempre viva", "Platzi School", "Colombia", 1 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "CursoID", "EscuelaID", "Jornada", "Nombre" },
                values: new object[,]
                {
                    { new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 0, "301" },
                    { new Guid("638b9110-3cef-405d-a936-87d2fe379845"), new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 1, "401" },
                    { new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 1, "501" },
                    { new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 0, "201" },
                    { new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), new Guid("cc83452c-1602-438d-9364-2ff4d42932ee"), 0, "101" }
                });

            migrationBuilder.InsertData(
                table: "Alumno",
                columns: new[] { "AlumnoID", "CursoID", "Nombre" },
                values: new object[,]
                {
                    { new Guid("002c7b8d-b2fa-4a63-8e70-225b6865ab55"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Alvaro Teodoro Ruiz" },
                    { new Guid("0047d664-b591-486b-92d0-1dfa1eb770c2"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Donald Freddy Toledo" },
                    { new Guid("005f1a9b-4eb2-442b-9e89-d4d6740c9f99"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Farid Silvana Ruiz" },
                    { new Guid("00638cc2-ca61-40a0-9466-896868376ffe"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Donald Rick Herrera" },
                    { new Guid("009bfb2a-18b7-41d1-ab8e-af5f5a1d0588"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Alvaro Murty Maduro" },
                    { new Guid("00a7c497-cb20-406a-84ae-52a8c9a4a9d5"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Alvaro Diomedes Toledo" },
                    { new Guid("00c9a798-79fe-41cf-bcb3-aa5c6fabce0f"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Alba Murty Ruiz" },
                    { new Guid("00e4f2a8-b238-4ce0-b566-761c441ea8ce"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alvaro Anabel Sarmiento" },
                    { new Guid("00e9cb2d-e4a9-4ec9-b5c1-7ea6861c4614"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Nicolás Rick Uribe" },
                    { new Guid("00f1e99d-da55-4b8d-9e10-c3b7ed492059"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Donald Silvana Maduro" },
                    { new Guid("012506ed-fe50-4bd6-a487-c7e8cb8f68bf"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Nicolás Nicomedes Toledo" },
                    { new Guid("01437c47-df3a-4252-9074-32f44b99dde8"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Nicolás Freddy Sarmiento" },
                    { new Guid("0143f4e8-5f47-47e0-acdd-1c172a66dae6"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Felipa Anabel Uribe" },
                    { new Guid("0145ec89-82c7-46d1-ac27-123ad641479e"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Alba Anabel Maduro" },
                    { new Guid("01537ab2-b7b4-47b2-9d13-531c59b3c22c"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Nicolás Silvana Herrera" },
                    { new Guid("015a9585-83aa-475e-8ce8-5859dabc2ff4"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alba Murty Ruiz" },
                    { new Guid("019079b2-6477-4765-b65f-821700420098"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Alvaro Nicomedes Herrera" },
                    { new Guid("019aeca0-fa98-45f9-b7eb-f33ca28a5a51"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Alba Freddy Uribe" },
                    { new Guid("01a9ce10-1d48-45b2-8de5-a2c7f7484e35"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Felipa Rick Herrera" },
                    { new Guid("01e02c82-27d2-45f0-ab8d-d63ce5f2cd17"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Eusebio Teodoro Uribe" },
                    { new Guid("01ed7800-bc62-4e9b-ab12-6ca764468e54"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Nicolás Rick Herrera" },
                    { new Guid("01efcb6f-2bc4-43f3-8a69-5ceeed0b5e87"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Felipa Anabel Ruiz" },
                    { new Guid("020ce23d-9e99-4012-9d56-0320147659ca"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alba Diomedes Sarmiento" },
                    { new Guid("022df560-ea6f-4ff2-bcc7-6f43ddf24018"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Farid Silvana Toledo" },
                    { new Guid("022e9a19-5566-4b0c-97df-2420fb1694e1"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Felipa Anabel Sarmiento" },
                    { new Guid("025b3e1e-403e-4505-a6c9-e8ba5a961a93"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alvaro Freddy Herrera" },
                    { new Guid("025e5e1e-ad4d-477d-8640-dec619b81d0d"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Alba Diomedes Herrera" },
                    { new Guid("0264cf60-b299-4e8a-84c8-54e36dd1ea19"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Eusebio Silvana Toledo" },
                    { new Guid("02765a09-f944-4df9-9c28-65d04cc73802"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Alba Teodoro Trump" },
                    { new Guid("02a01ce4-024f-47d0-8087-e8d6aeb1f79e"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Farid Teodoro Herrera" },
                    { new Guid("02f1ccf4-1322-4916-8807-a55777775939"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Farid Diomedes Uribe" },
                    { new Guid("03137c50-3f25-415e-9918-1d04c7b37b85"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Farid Anabel Uribe" },
                    { new Guid("03680b19-8dd0-4911-9987-798242ae3fb0"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Alvaro Murty Herrera" },
                    { new Guid("03942a93-52e0-47e8-9992-995f360ba5b3"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Alvaro Anabel Trump" },
                    { new Guid("03f36db3-8a56-4421-8b68-7f92b968ea7b"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Nicolás Rick Ruiz" },
                    { new Guid("04464771-3845-4918-9c95-1ecf95012d30"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alvaro Nicomedes Trump" },
                    { new Guid("044bfc4b-5bfb-4891-9889-59184532dac4"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Alvaro Silvana Maduro" },
                    { new Guid("048ac994-62cb-458b-af93-6a0de12c4a45"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Felipa Nicomedes Ruiz" },
                    { new Guid("04984ca7-6116-49bb-852f-c86130130a90"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Donald Silvana Ruiz" },
                    { new Guid("0518342e-5f9b-4a02-9080-1f9a25dadd9c"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Alvaro Diomedes Sarmiento" },
                    { new Guid("051fe1d2-4ab7-4b5b-8d7f-f36d9c84fed2"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Alvaro Diomedes Herrera" },
                    { new Guid("0541c2ae-5d4d-4374-b560-e53be7a1f8fc"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Donald Diomedes Uribe" }
                });

            migrationBuilder.InsertData(
                table: "Alumno",
                columns: new[] { "AlumnoID", "CursoID", "Nombre" },
                values: new object[,]
                {
                    { new Guid("058a8922-793a-460c-8079-a87b96a181f3"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Nicolás Murty Uribe" },
                    { new Guid("059f2654-82d5-4f14-b46b-9e5505e8acb9"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Alvaro Murty Sarmiento" },
                    { new Guid("05d060d4-ab7f-4808-b8dc-d7b9e2d03ce5"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Donald Teodoro Sarmiento" },
                    { new Guid("05ee5723-cc17-458f-af1e-5a44dbc63d50"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Alba Anabel Sarmiento" },
                    { new Guid("0645670a-d209-4a90-9176-3232af1bd408"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Alba Silvana Sarmiento" },
                    { new Guid("07180cd1-fb9f-4a39-84f6-d8c182c96041"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Farid Murty Maduro" },
                    { new Guid("071da8b4-0dde-4616-8144-acf6624156c5"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Donald Diomedes Toledo" },
                    { new Guid("074b3cbf-7fae-491d-a684-fd58046dd6f3"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Felipa Freddy Maduro" },
                    { new Guid("07ad9359-8a60-41f8-8b83-e453a0f691f2"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Felipa Silvana Trump" },
                    { new Guid("07b2af25-1897-423a-adf3-52efd2376d64"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Donald Freddy Trump" },
                    { new Guid("07cb4f94-5315-46f8-a8be-c702b00dedf9"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Donald Silvana Trump" },
                    { new Guid("07fc6f18-0a33-44d8-b31e-3a867cc6b7ac"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Eusebio Silvana Ruiz" },
                    { new Guid("0aa008c3-c618-4377-90c5-a0a21d9aa4ed"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Alvaro Anabel Herrera" },
                    { new Guid("0c243149-bff9-4ff3-b467-e684d4f7e636"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Nicolás Anabel Maduro" },
                    { new Guid("0c7dceaf-4d82-44e3-8a8b-f558e8bd3b48"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Farid Diomedes Toledo" },
                    { new Guid("0d5f8179-5628-497e-8605-232e03b0b29b"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Eusebio Murty Sarmiento" },
                    { new Guid("0e0f126c-d0b5-4494-8f75-896795855bb4"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Eusebio Nicomedes Toledo" },
                    { new Guid("0e9d9871-a4a8-4f79-bdbc-2a35a02b497e"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Donald Silvana Toledo" }
                });

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "AsignaturaID", "CursoID", "Nombre" },
                values: new object[,]
                {
                    { new Guid("005e9755-96e0-4ef7-a397-7fde4d756a83"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Programación" },
                    { new Guid("0723042f-794e-4068-b019-14647ae53b44"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Programación" },
                    { new Guid("08d6c22d-8d37-4267-a386-623fe1ce3be8"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Educación Física" },
                    { new Guid("0f9f90de-0f5a-4a5d-89c5-6cc98d9ff8da"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Ciencias Naturales" },
                    { new Guid("230dd8fb-a3a8-4396-aca5-b11cd03472f3"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Programación" },
                    { new Guid("30605797-af64-41ef-b444-5f7eefee8ace"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Matemáticas" },
                    { new Guid("4537dcd8-3a8a-4710-b607-09201b8c9526"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Ciencias Naturales" },
                    { new Guid("50bb22c5-0ca7-43ce-8af7-85b7b8e4cb22"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Castellano" },
                    { new Guid("55710379-7d2d-476c-a4bc-d835efd8871f"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Ciencias Naturales" },
                    { new Guid("5a771a95-15de-442f-aaa0-73fd702155b1"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Educación Física" },
                    { new Guid("5bf9fab8-f815-4ab8-b8a9-cda1159d6c84"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Matemáticas" },
                    { new Guid("5c466535-e2cc-473b-9141-b69a21c7a035"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Educación Física" },
                    { new Guid("5dec46c8-1a4c-4171-8066-35c32b98145b"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Educación Física" },
                    { new Guid("7beef989-62ad-40bf-a542-6168bf93ad0c"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Castellano" },
                    { new Guid("868861f5-31ef-416c-b749-f176eec55b37"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Ciencias Naturales" },
                    { new Guid("89d0a4fa-a0ec-41b9-a449-55de3cff33ff"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Programación" },
                    { new Guid("a2329dac-ea7e-49d2-a832-34ae3c8170e9"), new Guid("cded5de9-aefe-4dce-8e7c-145f4efb1d03"), "Matemáticas" },
                    { new Guid("b4fe762d-f9a6-41cf-9db0-57d40166adcc"), new Guid("17a88bc1-d80a-45ae-951a-ba9cbef3191e"), "Educación Física" },
                    { new Guid("bbaaaa83-3512-482f-9838-cebbc4a3e07b"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Castellano" },
                    { new Guid("c1319eac-675b-4705-85e2-49aaa089525c"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Castellano" },
                    { new Guid("c4ce22c0-1223-46ac-896f-4173c34c1740"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Programación" },
                    { new Guid("c70c125d-8fe2-4751-8cd7-29f827cf6bfb"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Matemáticas" },
                    { new Guid("cbfe5291-9635-4b62-a89e-9c1d5a883791"), new Guid("a20f88fc-b1d5-4b96-aae1-710b1e6b7159"), "Castellano" },
                    { new Guid("e0786d14-1106-44ed-9d8d-17d0c62a2a77"), new Guid("97cebf4c-6624-41ac-b35f-742d88229d62"), "Matemáticas" }
                });

            migrationBuilder.InsertData(
                table: "Asignatura",
                columns: new[] { "AsignaturaID", "CursoID", "Nombre" },
                values: new object[] { new Guid("fd29d3b3-7d0c-4652-9b87-e8fe69f9819c"), new Guid("638b9110-3cef-405d-a936-87d2fe379845"), "Ciencias Naturales" });

            migrationBuilder.CreateIndex(
                name: "IX_Alumno_CursoID",
                table: "Alumno",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_CursoID",
                table: "Asignatura",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_EscuelaID",
                table: "Curso",
                column: "EscuelaID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_AlumnoID",
                table: "Evaluacion",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_AsignaturaID",
                table: "Evaluacion",
                column: "AsignaturaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Escuela");
        }
    }
}
