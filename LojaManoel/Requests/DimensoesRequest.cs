using LojaManoel.Modelos;
using System.ComponentModel.DataAnnotations;

namespace LojaManoel.Requests;

public record DimensoesRequest([Required] int altura, [Required] int largura, [Required] int comprimento)
{
    public Dimensoes ToDimensoes()
    {
        return new Dimensoes(altura, largura, comprimento);
    }
};
