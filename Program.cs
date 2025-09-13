using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione estes dois métodos:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<List<Tarefa>>();

var app = builder.Build();

// Ative o Swagger no pipeline:
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/tarefas", (List<Tarefa> tarefas) => tarefas);

app.MapPost("/tarefas", (List<Tarefa> tarefas, Tarefa tarefaModel) =>
{

    if (string.IsNullOrWhiteSpace(tarefaModel.Nome))
        return Results.BadRequest("O nome da tarefa é obrigatório");

    int novoId;
    if (tarefas.Any())
    {
        novoId = tarefas.Max(t => t.Id) + 1;
    }
    else
    {
        novoId = 1;
    }
    tarefaModel.Id = novoId; 
    tarefas.Add(tarefaModel);

    return Results.Created($"/tarefas/{tarefaModel.Id}", tarefaModel);
});

app.MapGet("tarefas/{id}", (int id, List<Tarefa> tarefas) =>
{
    var busca = tarefas.Find(i => i.Id == id);

    if (busca is not null)
        return Results.Ok(busca);
    else
        return Results.NotFound("A tarefa que você buscou não foi encontrada");
});
    

app.MapPut("tarefas/{id}", (int id, List<Tarefa> tarefas, Tarefa tarefaModel) =>
{

    var busca = tarefas.Find(i => i.Id == id);

    if (busca is not null)
    {
        busca.Nome = tarefaModel.Nome;
        busca.Descricao = tarefaModel.Descricao;
        busca.Concluido = tarefaModel.Concluido;
        return Results.Ok(busca);
    }
    else
        return Results.NotFound("A tarefa que você buscou não foi encontrada");
});

app.MapDelete("tarefas/{id}", (int id, List<Tarefa> tarefas) =>
{
    var busca = tarefas.Find(i => i.Id == id);

    if (busca is not null)
    {
        tarefas.Remove(busca);
        return Results.Ok(tarefas);
    }
    else
        return Results.NotFound("A tarefa que você buscou não foi encontrada");
});

app.Run();