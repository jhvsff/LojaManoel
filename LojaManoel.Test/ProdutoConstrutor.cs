using Bogus;
using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class ProdutoConstrutor
{
    [Fact]
    public void RetornaProdutoValidoQuandoProdutoCriadoCorretamente()
    {
        //arrange
        var faker = new Faker();
        string id = faker.Commerce.ProductName();
        int altura = faker.Random.Int();
        int largura = faker.Random.Int();
        int comprimento = faker.Random.Int();        

        //act
        var produto = new Produto(id, new Dimensoes(altura, largura, comprimento));
        string stringProduto = $"Produto: {id} - {produto.Dimensoes}";

        //assert
        Assert.Equal(stringProduto, produto.ToString());
    }
}
