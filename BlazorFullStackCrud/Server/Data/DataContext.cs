namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Horor" },
            new Genre { Id = 2, Name = "Romance" },
            new Genre { Id = 3, Name = "Komedi" },
            new Genre { Id = 4, Name = "Fantasi" },
            new Genre { Id = 5, Name = "Edukasi" }
              );
            modelBuilder.Entity<Buku>().HasData(
                new Buku
                {
                    Id = 11,
                    Judul_Buku = "Dear Nathan",
                    Penerbit = "Tere",
                    Penulis = "Tere Liye",
                    GenreId = 1
                },
            new Buku
            {
                Id = 12,
                Judul_Buku = "Dilan 1991",
                Penerbit = "Pidi Baiq",
                Penulis = "Pidi",
                GenreId = 2
            },
            new Buku
            {
                Id = 16,
                Judul_Buku = "Dibalik 98",
                Penerbit = "Ismail",
                Penulis = "Ismail Marzuki",
                GenreId = 3
            },
            new Buku
            {
                Id = 19,
                Judul_Buku = "Kisah Tanah Jawa",
                Penerbit = "Ismail",
                Penulis = "Ismail Marzuki",
                GenreId = 4
            },
            new Buku
            {
                Id = 56,
                Judul_Buku = "Dilannnn",
                Penerbit = "Ismail",
                Penulis = "Ismail Marzuki",
                GenreId = 5
            }
            );
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Buku> Buku { get; set; }
    }
}
