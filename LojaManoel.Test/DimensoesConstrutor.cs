using Bogus;
using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class DimensoesConstrutor
{
    [Fact]
    public void RetornaDimensoesValidasQuandoCriadoCorretamente()
    {
        //arrange
        var faker = new Faker();

        int altura = faker.Random.Int();
        int largura = faker.Random.Int();
        int comprimento = faker.Random.Int();

        string stringDimensoes = $"Altura: {altura}, Largura: {largura}, Comprimento: {comprimento}";

        //act
        var dimensoes = new Dimensoes(altura, largura, comprimento);

        //assert
        Assert.Equal(stringDimensoes, dimensoes.ToString());
    }
}
