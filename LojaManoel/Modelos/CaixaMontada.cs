using LojaManoel.Responses;

namespace LojaManoel.Modelos;

public class CaixaMontada
{
    public int Id { get; set; }
    public Caixa? Caixa { get; set; }
    public List<Produto>? Produtos { get; set; }
    public string? Observacao { get; set; }

    public static List<CaixaMontada> MontarCaixas(Pedido pedido)
    {
        List<Caixa> caixasDisponiveis =
        [
            new Caixa("Caixa 1", 30, 40, 80),
            new Caixa("Caixa 2", 80, 50, 40),
            new Caixa("Caixa 3", 50, 80, 60)
        ];

        List<CaixaMontada>? melhorCombinacao = null;

        GerarCombinacoes(caixasDisponiveis, pedido.Produtos, [], ref melhorCombinacao);

        return melhorCombinacao ?? [];
    }

    private static void GerarCombinacoes(List<Caixa> caixasDisponiveis, List<Produto> produtosRestantes, List<CaixaMontada> combinacaoAtual, ref List<CaixaMontada>? melhorCombinacao)
    {
        if (produtosRestantes.Count == 0)
        {
            if (melhorCombinacao == null || combinacaoAtual.Count < melhorCombinacao.Count ||
                (combinacaoAtual.Count == melhorCombinacao.Count && VolumeTotal(combinacaoAtual) < VolumeTotal(melhorCombinacao)))
            {
                melhorCombinacao = new List<CaixaMontada>(combinacaoAtual.Select(caixa => new CaixaMontada
                {
                    Caixa = caixa.Caixa,
                    Produtos = new List<Produto>(caixa.Produtos ?? []),
                    Observacao = caixa.Observacao
                }));
            }
            return;
        }

        var produtoAtual = produtosRestantes[0];
        var produtosRestantesAtualizados = produtosRestantes.Skip(1).ToList();

        bool produtoAcomodado = false;

        foreach (var caixaMontada in combinacaoAtual.ToList())
        {
            if (caixaMontada.Caixa is not null)
                if (TentarAcomodarProdutoEmCaixa(caixaMontada.Caixa!, caixaMontada.Produtos ?? [], produtoAtual))
                {
                    caixaMontada.Produtos!.Add(produtoAtual);
                    GerarCombinacoes(caixasDisponiveis, produtosRestantesAtualizados, combinacaoAtual, ref melhorCombinacao);
                    caixaMontada.Produtos.Remove(produtoAtual);
                    produtoAcomodado = true;
                }
        }

        foreach (var caixa in caixasDisponiveis)
        {
            if (TentarAcomodarProdutoEmCaixa(caixa, [], produtoAtual))
            {
                var novaCaixaMontada = new CaixaMontada { Caixa = caixa, Produtos = new List<Produto> { produtoAtual } };
                var novaCombinacaoAtual = new List<CaixaMontada>(combinacaoAtual) { novaCaixaMontada };  // Cria uma nova lista com a nova combinação

                GerarCombinacoes(caixasDisponiveis, produtosRestantesAtualizados, novaCombinacaoAtual, ref melhorCombinacao);

                produtoAcomodado = true;
            }
        }

        if (!produtoAcomodado)
        {
            var caixaComObservacao = new CaixaMontada
            {
                Caixa = null,
                Produtos = new List<Produto> { produtoAtual },
                Observacao = "Produto não cabe em nenhuma caixa disponível."
            };
            var novaCombinacaoAtual = new List<CaixaMontada>(combinacaoAtual) { caixaComObservacao };

            GerarCombinacoes(caixasDisponiveis, produtosRestantesAtualizados, novaCombinacaoAtual, ref melhorCombinacao);
        }
    }

    private static bool TentarAcomodarProdutoEmCaixa(Caixa caixa, List<Produto> produtosJaNaCaixa, Produto produto)
    {
        var rotacoesProduto = produto.Rotacionar();

        foreach (var rotacao in rotacoesProduto)
        {
            var espacoDisponivel = new Dimensoes(caixa.Altura, caixa.Largura, caixa.Comprimento);

            foreach (var p in produtosJaNaCaixa)
            {
                espacoDisponivel.Altura -= p.Dimensoes.Altura;
                espacoDisponivel.Largura -= p.Dimensoes.Largura;
                espacoDisponivel.Comprimento -= p.Dimensoes.Comprimento;
            }

            if (rotacao.Altura <= espacoDisponivel.Altura &&
                rotacao.Largura <= espacoDisponivel.Largura &&
                rotacao.Comprimento <= espacoDisponivel.Comprimento)
            {
                produto.Dimensoes = rotacao;
                return true;
            }
        }

        return false;
    }

    private static int VolumeTotal(List<CaixaMontada> caixasMontadas)
    {
        return caixasMontadas.Sum(caixa => caixa.Caixa?.Volume ?? 0);
    }

    public CaixaMontadaResponse ToCaixaMontadaResponse()
    {
        return new CaixaMontadaResponse(Caixa?.Id ?? null,
                                        Produtos?.Select(p => p.Id)?.ToList() ?? [],
                                        Observacao);

    }
}


