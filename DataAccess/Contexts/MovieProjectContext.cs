using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class MovieProjectContext : DbContext
    {
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<FilmTur> FilmTur { get; set; }
        public DbSet<Yonetmen> Yonetmen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string connectionString = @"server=.\SQLEXPRESS;database=MVCMovieProject;user id=sa;password=sa;multipleactiveresultsets=true;";
            optionBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                //.ToTable("Filmler") // genelde tablo isimlerini deðiþtirmeye gerek yoktur, DbSet ismini kullanýr (Urunler)
                .HasOne(film => film.Yonetmen)
                .WithMany(yonetmen => yonetmen.Filmler)
                .HasForeignKey(film => film.YonetmenId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FilmTur>()
                .HasKey(filmTur => new { filmTur.FilmId, filmTur.TurId });

            modelBuilder.Entity<FilmTur>()
                .HasOne(x => x.Film)
                .WithMany(x => x.FilmTurler)
                .HasForeignKey(x => x.FilmId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FilmTur>()
               .HasOne(x => x.Tur)
               .WithMany(x => x.FilmTurler)
               .HasForeignKey(x => x.TurId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
