namespace LojaManoel.Modelos;

public class Dimensoes(int altura, int largura, int comprimento)
{
    public int Altura { get; set; } = altura;
    public int Largura { get; set; } = largura;
    public int Comprimento { get; set; } = comprimento;

    public override bool Equals(object obj)
    {
        if (obj is Dimensoes d)
        {
            return Altura == d.Altura && Largura == d.Largura && Comprimento == d.Comprimento;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Altura, Largura, Comprimento);
    }

    public override string ToString()
    {
        return $"Altura: {Altura}, Largura: {Largura}, Comprimento: {Comprimento}";
    }
}
