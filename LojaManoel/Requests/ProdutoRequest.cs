using LojaManoel.Modelos;
using System.ComponentModel.DataAnnotations;

namespace LojaManoel.Requests;

public record ProdutoRequest([Required]string produto_id, [Required]DimensoesRequest dimensoes)
{
    public Produto ToProduto()
    {
        return new Produto(produto_id, dimensoes.ToDimensoes());
    }
}
