using System.Globalization;
using ToxicLabMVC.Dominio.Entidades;

namespace ToxiLabMVC.Models.Clientes.ClienteServico
{
    public class Model_Cliente
    {
        public static Cliente ModelToCliente(ClientesModel clientesModel)
        {

            if (string.IsNullOrEmpty(clientesModel.DataNotificacao))
            {
                clientesModel.DataNotificacao = DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            }
            string whatsapp = String.Concat(clientesModel.DDD, clientesModel.WhatsApp);

            Endereco endereco = new Endereco(clientesModel.TipoLogradouro, clientesModel.TipoLogradouro, clientesModel.Logradouro,
                clientesModel.Numero, clientesModel.Complemento, clientesModel.CEP, clientesModel.Bairro);

            Cliente cliente = new Cliente(clientesModel.Nome, DateOnly.ParseExact(clientesModel.Nascimento, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                clientesModel.NumeroCustodia, clientesModel.Cpf, clientesModel.Cnh, DateOnly.ParseExact(clientesModel.VencimentoCnh, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                 endereco, whatsapp, clientesModel.Email.ToString(), DateOnly.ParseExact(clientesModel.DataNotificacao, "yyyy-MM-dd", CultureInfo.InvariantCulture), true);

            return cliente;
        }

        //public static ClientesModel ClienteToModel(Cliente cliente)
        //{

        //}
    }
}
