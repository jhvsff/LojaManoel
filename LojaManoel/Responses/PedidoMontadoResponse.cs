namespace LojaManoel.Responses;

public record PedidoMontadoResponse(int pedido_id, List<CaixaMontadaResponse> caixas);
