using Bogus;
using LojaManoel.Modelos;

namespace LojaManoel.Test;

public class CaixaConstrutor
{
    [Fact]
    public void RetornaCaixaValidaQuandoCriadaUmaCaixaValida()
    {
        //arrange
        var faker = new Faker();
        string id = $"Caixa {faker.Random.Int(1, 3)}";
        int altura = faker.Random.Int();
        int largura = faker.Random.Int();
        int comprimento = faker.Random.Int();

        string stringCaixa = $"{id} - Altura: {altura}, Largura: {largura}, Comprimento: {comprimento}";

        //act
        var caixa = new Caixa(id, altura, largura, comprimento);

        //assert
        Assert.Equal(stringCaixa, caixa.ToString());
    }
}