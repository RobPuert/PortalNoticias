namespace PortalNoticias.Models; 

public class Noticia {
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public int UsuarioId { get; set; }

    public Usuario Usuario { get; set; } = null!;
    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}
