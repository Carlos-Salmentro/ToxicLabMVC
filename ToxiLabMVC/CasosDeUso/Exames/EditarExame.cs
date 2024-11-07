using ToxicLabMVC.Dominio.Enums;
using ToxicLabMVC.InfraEstrutura.Repositorio;
using Dapper;
using Microsoft.EntityFrameworkCore;
using ToxicLabMVC.Dominio.Entidades;

namespace ToxicLabMVC.CasosDeUso.Exames
{
    public class EditarExame
    {
        public class EditarExameRequest
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public DateTime DataRealizado { get; set; }
            public DateTime DataVencimento { get; set; }
            public MotivoExame MotivoExame { get; set; }
            public bool Ativo { get; set; }
        }

        public class EditarExameHandler
        {
            private readonly AppDbContext _context;

            public EditarExameHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<EditarExameResponse> Handle(int id, int clienteId, DateTime dataRealizado, DateTime dataVencimento, MotivoExame motivo, bool ativo)
            {
                Exame exame = await _context.exames.FirstOrDefaultAsync(x => x.Id == id);

                if(exame == null)
                {
                    throw new Exception("Nenhum exame encontrado");
                }
                
                exame.ClienteId  = clienteId;
                exame.DataRealizado= dataRealizado;
                exame.DataVencimento = dataVencimento;
                exame.MotivoExame= motivo;
                exame.Ativo= ativo;

                _context.SaveChangesAsync();

                return new EditarExameResponse() { Id = exame.Id, ClienteId = exame.ClienteId, DataRealizado = exame.DataRealizado, DataVencimento = exame.DataVencimento, MotivoExame = exame.MotivoExame, Ativo = exame.Ativo };
            }
        }

        public class EditarExameResponse
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public DateTime DataRealizado { get; set; }
            public DateTime DataVencimento { get; set; }
            public MotivoExame MotivoExame { get; set; }
            public bool Ativo { get; set; }
        }
    }
}
