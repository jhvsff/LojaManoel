using LojaManoel.Responses;

namespace LojaManoel.Modelos;

public class PedidoMontado
{
    public int Id { get; set; }
    public List<CaixaMontada> Caixas { get; set; }

    public static PedidoMontado MontarPedido(Pedido pedido)
    {
        var caixasMontadas = CaixaMontada.MontarCaixas(pedido);

        return new PedidoMontado
        {
            Id = pedido.Id,
            Caixas = caixasMontadas
        };
    }

    public PedidoMontadoResponse ToPedidoMontadoResponse()
    {
        List<CaixaMontadaResponse> listaCaixas = [];
        Caixas.ForEach(c => listaCaixas.Add(c.ToCaixaMontadaResponse()));
        return new PedidoMontadoResponse(Id, listaCaixas);
    }
}
