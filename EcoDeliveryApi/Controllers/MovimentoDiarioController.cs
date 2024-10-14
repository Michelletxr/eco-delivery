using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoDiarioController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MovimentoDiarioController(DatabaseContext context)
        {
            _context = context;
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentoDiario>>> GetMovimentosDiario()
        {
            var movimentosDiarios = await _context.MovimentosDiarios
                .Include(m => m.Mensageiro)
                .Include(m => m.ContribuicaoRecibo)
                    .ThenInclude(c => c.TipoPagamento)
                .Include(m => m.ContribuicaoRecibo)
                    .ThenInclude(c => c.Contribuinte)
                .ToListAsync();

            foreach (var movimento in movimentosDiarios)
            {
                Console.WriteLine($"Id: {movimento.Id}, Data: {movimento.Data_Movimento}, contribuicao: {movimento.ContribuicaoRecibo.Id}");
                var campos =  movimento.GetType().GetProperties();
            }

            return movimentosDiarios;
        }
    
    }
}
