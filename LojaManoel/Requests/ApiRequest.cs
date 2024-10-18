using System.ComponentModel.DataAnnotations;

namespace LojaManoel.Requests;

public record ApiRequest([Required] List<PedidoRequest> pedidos);