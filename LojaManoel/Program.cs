using LojaManoel;
using LojaManoel.Modelos;
using LojaManoel.Requests;
using LojaManoel.Responses;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/Pedido", ([FromBody] ApiRequest listaPedidosRequest) =>
{
    if (listaPedidosRequest is null)
        return Results.BadRequest();

    List<Pedido> listaPedidos = [];
    listaPedidosRequest.pedidos.ForEach(p => listaPedidos.Add(p.ToPedido()));

    List<PedidoMontadoResponse> listaPedidoMontadoResponse = [];

    foreach(var pedido in listaPedidos)
    {
        listaPedidoMontadoResponse
        .Add(PedidoMontado.MontarPedido(pedido).ToPedidoMontadoResponse());
    }

    return Results.Ok(new ApiResponse(listaPedidoMontadoResponse));
})
.WithName("Pedido")
.WithOpenApi();

app.Run();
