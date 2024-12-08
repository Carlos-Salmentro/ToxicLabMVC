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
    public string Nascimento { get; set; }
    public int TipoLogradouro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string CEP { get; set; }
    public string Bairro { get; set; }
    public string NumeroCustodia { get; set; }
    public string Cpf { get; set; }
    public string Cnh { get; set; }
    public string VencimentoCnh { get; set; }
    public string DDD { get; set; }
    public string WhatsApp { get; set; }
    public string? Email { get; set; }
    public string DataNotificacao { get; set; }
    public bool Ativo { get; set; }
    public List<Exame> Exames { get; set; }
    public List<Cliente>? Clientes { get; set; } = new List<Cliente>(); 
}