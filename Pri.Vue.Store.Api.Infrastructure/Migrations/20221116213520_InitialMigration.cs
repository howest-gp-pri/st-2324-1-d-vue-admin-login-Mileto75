using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.Vue.Store.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PegiRating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, new DateTime(1982, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "5bab4bc0-fe4a-488b-9c67-2c772dfcdcd3", "admin@bull.com", true, false, null, "ADMIN@BULL.COM", "ADMIN@BULL.COM", "AQAAAAEAACcQAAAAEGd7L8XOVzXA5VAcjBuZnEB4odUQPmD7lTt11a6mtSvRJ06Q5CaH3glFVQhIpjeshg==", null, false, "8daffbaa-84a6-464c-9426-2f11caab39b9", false, "admin@bull.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "images/categories/books.jpg", "Boeken" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "images/categories/games.jpg", "Games" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "PegiRating", "Price" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), "<p>Even bad code can function. But if code isn't clean, it can bring a development organization to its knees. Every year, countless hours and significant resources are lost because of poorly written code. But it doesn't have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship. Martin has teamed up with his colleagues from Object Mentor to distill their best agile practice of cleaning code on the fly into a book that will instill within you the values of a software craftsman and make you a better programmer-but only if you work at it. What kind of work will you be doing? You'll be reading code-lots of code. And you will be challenged to think about what's right about that code, and what's wrong with it. More importantly, you will be challenged to reassess your professional values and your commitment to your craft. Clean Code is divided into three parts. The first describes the principles, patterns, and practices of writing clean code. The second part consists of several case studies of increasing complexity. Each case study is an exercise in cleaning up code-of transforming a code base that has some problems into one that is sound and efficient. The third part is the payoff: a single chapter containing a list of heuristics and smells gathered while creating the case studies. The result is a knowledge base that describes the way we think when we write, read, and clean code. Readers will come away from this book understanding How to tell the difference between good and bad code How to write good code and how to transform bad code into good code How to create good names, good functions, good objects, and good classes How to format code for maximum readability How to implement complete error handling without obscuring code logic How to unit test and practice test-driven development This book is a must for any developer, software engineer, project manager, team lead, or systems analyst with an interest in producing better code.</p>", "images/products/00000000-0000-0000-0000-000000000001.jpg", "Clean Code", null, 28.789999999999999 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), "<p>Building upon the success of best-sellers The Clean Coder and Clean Code, legendary software craftsman Robert C. Uncle Bob Martin shows how to bring greater professionalism and discipline to application architecture and design. As with his other books, Martin's Clean Architecture doesn't merely present multiple choices and options, and say use your best judgment : it tells you what choices to make, and why those choices are critical to your success. Martin offers direct, no-nonsense answers to key architecture and design questions like: What are the best high level structures for different kinds of applications, including web, database, thick-client, console, and embedded apps? What are the core principles of software architecture? What is the role of the architect, and what is he/she really trying to achieve? What are the core principles of software design? How do designs and architectures go wrong, and what can you do about it? What are the disciplines and practices of professional architects and designers? Clean Architecture is essential reading for every software architect, systems analyst, system designer, and software manager -- and for any programmer who aspires to these roles or is impacted by their work.</p>", "images/products/00000000-0000-0000-0000-000000000002.jpg", "Clean Architecture", null, 21.489999999999998 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), "<p>Welkom in het nieuwe tijdperk van Call of Duty. Met de terugkeer van de iconische kapitein John Price, de onverschrokken John \"Soap\" MacTavish, de veteraan sergeant Kyle \"Gaz\" Garrick en de eenzame wolf zelf, de fan-favoriete operator Simon \"Ghost\" Riley. Spelers zullen ontdekken wat Task Force 141 tot de legendarische eenheid maakt die het nu is. Call of Duty: Modern Warfare II is het vervolg op de kaskraker van 2019, Modern Warfare.</p><p><strong>Vorm je team en vecht aan de zijde van de Task Force 141</strong></p><p>CoD: Modern Warfare II zal vanaf dag één een grote hoeveelheid content bevatten: vorm je team en vecht aan de zijde van de TF141 in een singleplayer-campagne over de hele wereld, speel alleen of als team in meeslepende multiplayer-gevechten met nieuwe locaties en manieren om te spelen, en ervaar een geavanceerder, verhaalgedreven speltype Special Operations met coöperatief tactisch spel.</p><p>Van kleinschalige infiltratietactieken tot zeer geheime missies, spelers zullen nieuwe wapens, voertuigen en uitrusting moeten gebruiken om het op te nemen tegen hun vijanden. Rust jezelf uit en ga de strijd aan op zee door vijanden onder water te belegeren, een sterk versterkte vijandelijke basis binnen te dringen, langs kanalen te infiltreren en belangrijke bondgenoten te bevrijden op een clandestiene plek die in de bergen verborgen ligt.</p><p><strongAansluiting met Warzone</strong></p>Bovendien sluit Modern Warfare II aan op de nieuwe Warzone-ervaring die dit jaar uitkomt, en daarmee op de evolutie van de Battle Pass met een volledig nieuwe speelruimte en sandbox-modus. Verwacht een schema vol gratis content na de lancering, waarin de gameplay evolueert met nieuwe maps, nieuwe modes, seizoensevents, community-feesten en meer.</p>", "images/products/00000000-0000-0000-0000-000000000003.jpg", "Call of Duty: Modern Warfare II - C.O.D.E. Editie – PS5", 18, 74.790000000000006 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), "<p>Dit is Far Cry 6 - Yara Edition op de Playstation 5 (PS5). Welkom in Yara, een tropisch paradijs dat vastzit in het verleden. Anton Castillo is de dictator van Yara en wil zijn natie koste wat kost terugbrengen naar zijn oude glorie. Zijn zoon Diego volgt in zijn bloederige voetstappen. Hun meedogenloze onderdrukking heeft een revolutie ontketend. Hou deze productpagina in de gaten voor het laatste nieuws omtrent Far Cry 6.</p><p><strong>Vecht voor vrijheid</strong></p><p>Speel als Dani Rojas, een inwoner van Yara, en word een guerrillastrijder die de natie wil bevrijden</p><p><strong>Een verscheurd Yara</strong></p><p>Vecht tegen Antons troepen in het grootste speelveld ooit in een Far Cry-game, met jungles, stranden en hoofdstad Esperanza</p><p><strong>Guerrilla-vuurkracht</strong></p><p>Gebruik geïmproviseerde wapens, voertuigen en de nieuwe huurlingen Amigos om het tirannieke regime omver te werpen</p>", "images/products/00000000-0000-0000-0000-000000000004.jpg", "Far Cry 6 Yara Edition - PS5", 18, 24.789999999999999 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002"), "<p>Spring in de gigantische multiplayer speeltuin van RIDERS REPUBLIC™! Ontmoet andere spelers en neem het tegen hen op. Rijd hard met een spannend scala aan activiteiten zoals fietsen, skiën, snowboarden, wingsuit en rocket wingsuit.</p><p>Beleef de fantasie van een extreme sporter terwijl je je vrij verplaatst in een enorme, levendige open wereld die altijd bruist van andere spelers om je heen. Dompel je onder in de iconische Amerikaanse nationale parken zoals Bryce Canyon, Yosemite Valley, Mammoth Mountain... allemaal voor je klaargezet om te overwinnen!</p><p>Ga samen met je vrienden de strijd aan in een breed scala aan multiplayer-modi: voel de rush van downhill races, domineer de tracks in team- vs teamcompetities, of laat zien wat je kunt in epische massa PvP-races met meer dan 50 andere spelers(1).</p><p>Ga er helemaal voor. Doe mee aan de waanzin!</p><p><strong>Belangrijkste kenmerken</strong></p><p>SPRING IN EEN GIGANTISCHE SOCIALE SPEELTUIN – Waar en wanneer je ook rijdt, je bevindt je altijd tussen andere spelers. Van besneeuwde bergen tot diepe ravijnen, rijd door de meest mooie bestemmingen op aarde: de Amerikaanse Nationale Parken. Bryce Canyon, Yosemite Valley, Sequoia Park, Zion, Canyonlands, Mammoth Mountain en Grand Teton worden allemaal trouw weergegeven en zijn samengebracht tot de meest unieke en levendige speeltuin. Verzamel in een levendige sociale hub en ontmoet een wilde community aan medesporters. Check hun vaardigheden en uiterlijk, zeg hallo of kom gewoon even langs, het is aan jou.</p><p>SPEEL MET OF TEGEN JE VRIENDEN IN KRANKZINNIGE MULTIPLAYER-MODI – Geniet van een volwaardige multiplayer-ervaring met een grote verscheidenheid aan modi:</p><ul><li>Competitieve wedstrijden en trick-uitdagingen: speelbaar in PvP / Co-op / Solo</li><li>Massastart: hectische races met meer dan 50 spelers waarin niets verboden is(1)</li><li>Multiplayer-arena's: 6x6 team PvP-matchups</li><li>Online Cups: alleen voor de allerbeste, werk je een weg naar boven in het klassement.</li></ul><p>WERK AAN JE CARRIÈRE EN BAAN JE EEN WEG NAAR DE TOP – Creëer en vorm je eigen sporter door middel van innovatieve, progressieve uitrusting en bepaal elk aspect van je avatar. Of je nu de beste snowboarder ter wereld wilt zijn of de snelste op twee wielen, alles is mogelijk. Maak naam in verschillende sporten, baan je een weg naar de top van de ranglijsten in de carrièremodus en teken bij legendarische sponsors uit een breed scala aan outdoor-actiesporten.</p><p>HAAL HET MEESTE UIT DE NEXT GEN GAMEPLAY – RIDERS REPUBLIC™ is speelbaar aan 60 FPS op de next gen consoles en zal meer dan 50 spelers tegelijkertijd live op het scherm weergeven. Dankzij het zeer intuïtieve karakter van de game en de camerabesturing in combinatie met een innovatief trucsysteem, krijgen alle spelers, zowel casual als hardcore, de kans om vanaf het allereerste begin ongekende vreugde te ervaren.</p><p>(1) Riders Republic™ zal meer dan 50 spelers weergeven op de volgende generatie consoles & PC, en meer dan 20 spelers op de huidige generatie consoles.</p>", "images/products/00000000-0000-0000-0000-000000000005.jpg", "Riders Republic - PS5", 12, 23.789999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
