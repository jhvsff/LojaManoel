namespace LojaManoel.Modelos;

public class Caixa(string id, int altura, int largura, int comprimento)
{
    public string Id { get; set; } = id;
    public int Altura { get; set; } = altura;
    public int Largura { get; set; } = largura;
    public int Comprimento { get; set; } = comprimento;
    public int Volume => Altura * Largura * Comprimento;

    public override string ToString()
    {
        return $"{Id} - Altura: {Altura}, Largura: {Largura}, Comprimento: {Comprimento}";
    }
}
