namespace PortalNoticias.Models; 

public class Tag {
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;

    public ICollection<NoticiaTag> NoticiaTags { get; set; } = new List<NoticiaTag>();
}
