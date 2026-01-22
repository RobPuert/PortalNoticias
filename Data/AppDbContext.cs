using Microsoft.EntityFrameworkCore;
using PortalNoticias.Models;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Noticia> Noticias => Set<Noticia>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<NoticiaTag> NoticiaTags => Set<NoticiaTag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Usuario>().HasData(
        new Usuario {
            Id = 1,
            Nome = "Administrador"
        }
    );

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NoticiaTag>()
            .HasOne(nt => nt.Noticia)
            .WithMany(n => n.NoticiaTags)
            .HasForeignKey(nt => nt.NoticiaId);

        modelBuilder.Entity<NoticiaTag>()
            .HasOne(nt => nt.Tag)
            .WithMany(t => t.NoticiaTags)
            .HasForeignKey(nt => nt.TagId);
    }
}
