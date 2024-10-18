using LojaManoel.Modelos;
using System.ComponentModel.DataAnnotations;

namespace LojaManoel.Requests;

public record PedidoRequest([Required] int pedido_id, [Required] List<ProdutoRequest> produtos)
{
    public Pedido ToPedido()
    {
        List<Produto> listaProduto = [];
        produtos.ForEach(p => listaProduto.Add(p.ToProduto()));

        return new(pedido_id, listaProduto);
    }
}
