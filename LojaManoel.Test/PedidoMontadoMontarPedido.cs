using Bogus;
using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class PedidoMontadoMontarPedido
{
    private readonly Faker<Produto> _produtoFaker;
    private readonly Faker<Dimensoes> _dimensoesFaker;

    public PedidoMontadoMontarPedido()
    {
        _dimensoesFaker = new Faker<Dimensoes>()
            .CustomInstantiator(f => new Dimensoes(
                f.Random.Int(1, 100),   
                f.Random.Int(1, 100),   
                f.Random.Int(1, 100))); 

        _produtoFaker = new Faker<Produto>()
            .CustomInstantiator(f => new Produto(
                f.Commerce.ProductName(),  
                _dimensoesFaker.Generate()
            ));
    }

    [Fact]
    public void MontaPedidoCorretamenteQuandoRecebePedidoValido()
    {
        // Arrange
        var pedido = GerarPedidoFake(5);

        // Act
        var resultado = PedidoMontado.MontarPedido(pedido);

        // Assert
        Assert.Equal(pedido.Id, resultado.Id); 
        Assert.NotNull(resultado.Caixas);
        var produtosMontados = resultado.Caixas.SelectMany(c => c.Produtos!).ToList();
        Assert.Equal(pedido.Produtos.Count, produtosMontados.Count);
        Assert.True(pedido.Produtos.All(p => produtosMontados.Contains(p)));
    }

    private Pedido GerarPedidoFake(int quantidadeDeProdutos)
    {
        var produtos = _produtoFaker.Generate(quantidadeDeProdutos);

        return new Pedido(
            id: new Faker().Random.Int(1, 1000),
            produtos: produtos 
        );
    }
}
