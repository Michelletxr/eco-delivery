
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoDeliveryApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TipoPagamentoController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPagamento>>> GetTipoPagamento()
        {
            return await _context.TipoPagamentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPagamento>> GetTipoPagamento(int id)
        {
            var TipoPagamento = await _context.TipoPagamentos.FindAsync(id);

            if (TipoPagamento == null)
            {
                return NotFound();
            }

            return TipoPagamento;
        }

        [HttpPost]
        public async Task<ActionResult<TipoPagamento>> PostTipoPagamento(TipoPagamento tipoPagamento)
        {
            _context.TipoPagamentos.Add(tipoPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoPagamento), new { id = tipoPagamento.Id }, tipoPagamento);
        }
    }
}