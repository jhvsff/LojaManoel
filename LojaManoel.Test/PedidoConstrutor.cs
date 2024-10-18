using Bogus;
using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class PedidoConstrutor
{
    [Fact]
    public void RetornaPedidoValidoQuandoPedidoCriadoCorretamente()
    {
        //arrange
        var faker = new Faker();
        int id = faker.Random.Int(1, 1000000);

        var fakerProduto = new Faker<Produto>()
            .CustomInstantiator(f =>
            {
                string produtoId = f.Commerce.ProductName();
                int altura = f.Random.Int(1, 350);
                int largura = f.Random.Int(1, 350);
                int comprimento = f.Random.Int(1, 350);
                return new Produto(produtoId, new Dimensoes(altura, largura, comprimento));
            });

        int produtosPorPedido = faker.Random.Int(1, 10);

        //act
        var pedido = new Pedido(id, fakerProduto.Generate(produtosPorPedido));

        string stringPedido = $"Pedido: {pedido.Id}";
        if (pedido.Produtos?.Count > 0)
        {
            foreach (var produto in pedido.Produtos)
            {
                stringPedido += $"\n{produto}";
            }
        }

        //assert
        Assert.Equal(stringPedido, pedido.ToString());
    }
}
