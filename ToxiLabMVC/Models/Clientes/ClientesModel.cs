using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ToxicLabMVC.Dominio.Entidades;
using ToxicLabMVC.Dominio.Enums;
using System.Runtime.CompilerServices;
using System.Linq;

public class ClientesModel
{
    public List<(int Value, string Name)> TiposLogradouros { get; set; } = new List<(int Value, string Name)>(Enum.GetValues(typeof(TiposLogradouro))
        .Cast<TiposLogradouro>().Select(e => (Convert.ToInt32(e), e.ToString())).ToList());
    public int? Id { get; set; }
    public string Nome { get; set; }
    public DateOnly Nascimento { get; set; }
    public Endereco Endereco { get; set; } = new Endereco();
    public string NumeroCustodia { get; set; }
    public string Cpf { get; set; }
    public string Cnh { get; set; }
    public DateOnly VencimentoCnh { get; set; }
    public string WhatsApp { get; set; }
    public string? Email { get; set; }
    public DateOnly? DataNotificacao { get; set; }
    public bool Ativo { get; set; }
}