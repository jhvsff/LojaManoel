namespace LojaManoel.Modelos;

public class Pedido(int id, List<Produto> produtos)
{
    public int Id { get; set; } = id;
    public List<Produto> Produtos { get; set; } = produtos;

    public override string ToString()
    {
        string pedido = $"Pedido: {Id}";
        if(Produtos?.Count > 0)
        {
            foreach(var produto in Produtos)
            {
                pedido += $"\n{produto}";
            }
        }
        return pedido;
    }
}
