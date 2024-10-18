using Bogus;
using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class CaixaMontadaMontarCaixa
{
    [Fact]
    public void RetornaListaDeCaixasMontadasQuandoRecebePedidoComProdutosQueCabemNela()
    {
        //arrange
        var faker = new Faker();
        int id = faker.Random.Int(1, 1000000);

        //var produto1 = new Produto("PS5", new Dimensoes(40, 10, 25));
        //var produto2 = new Produto("Volante", new Dimensoes(50, 30, 30));

        var produto1 = new Produto("Joystick", new Dimensoes(15, 20, 10));
        var produto2 = new Produto("Fifa 24", new Dimensoes(10, 30, 10));
        var produto3 = new Produto("Call of Duty", new Dimensoes(30, 15, 10));

        var pedido = new Pedido(id, [produto1, produto2]);

        //act
        List<CaixaMontada>? listaCaixasMontadas = CaixaMontada.MontarCaixas(pedido);

        //assert
        Assert.NotEmpty(listaCaixasMontadas);
    }

    [Fact]
    public void RetornaObservacaoQuandoRecebePedidoComProdutosQueNãoCabemEmNenhumaCaixa()
    {
        //arrange
        var faker = new Faker();
        int id = faker.Random.Int(1, 1000000);

        var produto1 = new Produto("PS5", new Dimensoes(150, 10, 25));

        var pedido = new Pedido(id, [produto1]);

        //act
        List<CaixaMontada>? listaCaixasMontadas = CaixaMontada.MontarCaixas(pedido);

        //assert
        Assert.Equal("Produto não cabe em nenhuma caixa disponível.", listaCaixasMontadas[0].Observacao);
    }

    [Fact]
    public void RetornaListaVaziaQuandoRecebePedidoComNenhumProduto()
    {
        //arrange
        var faker = new Faker();
        int id = faker.Random.Int(1, 1000000);

        var pedido = new Pedido(id, []);

        //act
        List<CaixaMontada>? listaCaixasMontadas = CaixaMontada.MontarCaixas(pedido);

        //assert
        Assert.Empty(listaCaixasMontadas);
    }
}
