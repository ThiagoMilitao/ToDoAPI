
using System.Text.Json.Serialization;
namespace TodoApi.Models;
public class Tarefa
{
    public int Id { get; set; } = default!;
    public string Nome { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;
    public bool Concluido { get; set; } = false;
}