using LojaManoel.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaManoel.Test;
public class ProdutoRotacionar
{
    [Fact]
    public void Rotacionar_DeveRetornarTodasRotacoesPossiveis()
    {
        // Arrange
        var dimensoes = new Dimensoes(10, 20, 30);
        var produto = new Produto("123", dimensoes);

        List<Dimensoes> rotacoesEsperadas = 
        [
            new(10, 20, 30),
            new(10, 30, 20),
            new(20, 10, 30),
            new(20, 30, 10),
            new(30, 10, 20),
            new(30, 20, 10)
        ];

        // Act
        var rotacoes = produto.Rotacionar();

        // Assert
        Assert.Equal(rotacoesEsperadas.Count, rotacoes.Count);
        for (int i = 0; i < rotacoesEsperadas.Count; i++)
        {
            Assert.Equal(rotacoesEsperadas[i], rotacoes[i]);
        }
    }
}
