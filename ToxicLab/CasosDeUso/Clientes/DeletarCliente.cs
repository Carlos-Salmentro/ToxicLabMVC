using ToxicLab.InfraEstrutura.Repositorio;
using ToxicLab.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ToxicLab.CasosDeUso.Clientes
{
    public class DeletarClienteRequest
    {
        public int Id { get; set; }
    }

    public class DeletarClienteHandler
    {
        private readonly AppDbContext _context;


        public DeletarClienteHandler(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<DeletarClienteResponse> Handle(int id)
        {
            Cliente cliente = await _context.clientes.FirstOrDefaultAsync(x => x.Id == id);
            cliente.Ativo = false;

            _context.SaveChangesAsync();

            DeletarClienteResponse clienteResponse = new DeletarClienteResponse(cliente);

            return clienteResponse;
        }

    }

    public class DeletarClienteResponse
    {
        public Cliente cliente { get; set; }

        public DeletarClienteResponse(Cliente cliente)
        {
            this.cliente = cliente;
        }
    }
}
