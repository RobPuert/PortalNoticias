namespace PortalNoticias.ViewModels;

public class NoticiaViewModel {
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;
    public string Texto { get; set; } = null!;

    public List<int> TagIds { get; set; } = new();
}
