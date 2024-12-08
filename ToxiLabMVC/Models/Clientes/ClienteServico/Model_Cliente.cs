using ToxicLabMVC.Dominio.Entidades;

namespace ToxiLabMVC.Models.Clientes.ClienteServico
{
    public class Model_Cliente
    {
        public static Cliente ModelToCliente(ClientesModel clientesModel)
        {
            string whatsapp = String.Concat(clientesModel.DDD, clientesModel.WhatsApp);

            Endereco endereco = new Endereco(clientesModel.TipoLogradouro, clientesModel.TipoLogradouro, clientesModel.Logradouro,
                clientesModel.Numero, clientesModel.Complemento, clientesModel.CEP, clientesModel.Bairro);

            Cliente cliente = new Cliente(clientesModel.Nome, clientesModel.Nascimento,
                clientesModel.NumeroCustodia, clientesModel.Cpf, clientesModel.Cnh, clientesModel.VencimentoCnh,
                 endereco, whatsapp, clientesModel.Email.ToString(), clientesModel.DataNotificacao, true);

            return cliente;
        }

        //public static ClientesModel ClienteToModel(Cliente cliente)
        //{

        //}
    }
}
