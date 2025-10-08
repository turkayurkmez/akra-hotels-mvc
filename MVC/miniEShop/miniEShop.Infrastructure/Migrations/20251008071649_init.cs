using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace miniEShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bilgisayar" },
                    { 2, "Giyim" },
                    { 3, "Kırtasiye" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "13 inç ekranlı ultrabook", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Laptop Dell XPS 13", 25000m },
                    { 2, 1, "RGB gaming mouse", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Gaming Mouse Logitech", 850m },
                    { 3, 1, "Cherry MX anahtarlı klavye", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Mechanical Keyboard", 1200m },
                    { 4, 1, "4K çözünürlüklü monitör", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Monitor 27 inch 4K", 8500m },
                    { 5, 1, "NVMe M.2 SSD", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "SSD Samsung 1TB", 3200m },
                    { 6, 1, "Full HD webcam", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Webcam Logitech C920", 1800m },
                    { 7, 1, "7 portlu USB hub", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "USB Hub 7 Port", 450m },
                    { 8, 1, "Ayarlanabilir laptop standı", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Laptop Stand", 320m },
                    { 9, 2, "Pamuklu beyaz t-shirt", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "T-Shirt Beyaz", 180m },
                    { 10, 2, "Slim fit jean pantolon", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Jean Pantolon", 450m },
                    { 11, 2, "Unisex kapüşonlu sweatshirt", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Kapüşonlu Sweatshirt", 320m },
                    { 12, 2, "Koşu ayakkabısı", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Spor Ayakkabı", 850m },
                    { 13, 2, "Suni deri ceket", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Ceket Deri", 1200m },
                    { 14, 2, "Çiçek desenli elbise", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Elbise Yazlık", 280m },
                    { 15, 2, "Ayarlanabilir şapka", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Şapka Baseball", 120m },
                    { 16, 2, "Pamuklu spor çorap seti", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Çorap Spor 3'lü", 85m },
                    { 17, 3, "Renkli kalem seti", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Kalem Seti 12'li", 45m },
                    { 18, 3, "100 sayfa kareli defter", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Defter A4 Kareli", 25m },
                    { 19, 3, "Beyaz silgi", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Silgi Beyaz", 8m },
                    { 20, 3, "Plastik cetvel", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Cetvel 30cm", 12m },
                    { 21, 3, "Metal kalemtıraş", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Kalemtıraş Metal", 15m },
                    { 22, 3, "21g yapıştırıcı stick", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Yapıştırıcı Stick", 18m },
                    { 23, 3, "A4 plastik dosya", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Dosya Plastik", 35m },
                    { 24, 3, "Renkli yapışkanlı notlar", "https://upload.wikimedia.org/wikipedia/commons/a/ac/No_image_available.svg", "Post-it Notlar", 22m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
