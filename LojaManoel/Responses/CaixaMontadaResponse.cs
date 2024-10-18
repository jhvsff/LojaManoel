namespace LojaManoel.Responses;

public record CaixaMontadaResponse(string? caixa_id, List<string> produtos, string? observacao);
