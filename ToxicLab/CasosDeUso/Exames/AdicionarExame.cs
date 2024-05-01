using ToxicLab.Dominio.Entidades;
using ToxicLab.Dominio.Enums;
using ToxicLab.InfraEstrutura.Repositorio;

namespace ToxicLab.CasosDeUso.Exames
{
    public class AdicionarExame
    {
        public class AdicionarExameRequest
        {
            public int ClienteId { get; set; }
            public DateOnly DataRealizado { get; set; }
            public DateOnly DataVencimento { get; set; }
            public MotivoExame MotivoExame { get; set; }
            public bool Ativo { get; set; }
        }

        public class AdicionarExameRequestHandler
        {
            private readonly AppDbContext _context;

            public AdicionarExameRequestHandler(AppDbContext context)
            {
                this._context = context;
            }


            public async Task<AdicionarExameResponse> Handle(AdicionarExameRequest request)
            {
                Exame exame = new Exame(request.ClienteId, request.DataRealizado, request.DataVencimento, request.MotivoExame, request.Ativo);

                await _context.exames.AddAsync(exame);
                await _context.SaveChangesAsync();

                return new AdicionarExameResponse(exame.Id, exame.ClienteId);
            }
        }


        public class AdicionarExameResponse
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }

            public AdicionarExameResponse(int id, int clienteId)
            {
                Id = id;
                ClienteId = clienteId;
            }
        }

    }
}
