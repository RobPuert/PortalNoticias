namespace PortalNoticias.Models; 

public class NoticiaTag {
    public int Id { get; set; }
    public int NoticiaId { get; set; }
    public int TagId { get; set; }

    public Noticia Noticia { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}
