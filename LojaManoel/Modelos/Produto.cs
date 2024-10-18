namespace LojaManoel.Modelos;

public class Produto(string id, Dimensoes dimensoes)
{
    public string Id { get; set; } = id;
    public Dimensoes Dimensoes { get; set; } = dimensoes;

    public override string ToString()
    {
        return $"Produto: {Id} - {Dimensoes}";
    }

    public List<Dimensoes> Rotacionar()
    {
        var p = Dimensoes;
        return
        [
            new Dimensoes(p.Altura, p.Largura, p.Comprimento),
            new Dimensoes(p.Altura, p.Comprimento, p.Largura),
            new Dimensoes(p.Largura, p.Altura, p.Comprimento),
            new Dimensoes(p.Largura, p.Comprimento, p.Altura),
            new Dimensoes(p.Comprimento, p.Altura, p.Largura),
            new Dimensoes(p.Comprimento, p.Largura, p.Altura)
        ];
    }
}
