
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoDeliveryApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class MensageiroController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MensageiroController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensageiro>>> GetMensageiro()
        {
            return await _context.Mensageiros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mensageiro>> GetMensageiro(int id)
        {
            var Mensageiro = await _context.Mensageiros.FindAsync(id);

            if (Mensageiro == null)
            {
                return NotFound();
            }

            return Mensageiro;
        }

        [HttpPost]
        public async Task<ActionResult<Mensageiro>> PostMensageiro(Mensageiro mensageiro)
        {
            _context.Mensageiros.Add(mensageiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMensageiro), new { id = mensageiro.Id }, mensageiro);
        }

        [HttpGet("movimentoDiario/{mensageiroId}")]
        public async Task<ActionResult<MovimentoDiario>> GetMovimentoDiario(int mensageiroId, [FromQuery] DateTime? dataPrevista)
        {
            var queryList = await _context.MovimentosDiarios
            .Where(movimento => movimento.Mensageiro.Id == mensageiroId)
            .Include(m => m.ContribuicaoRecibo)
            .ToListAsync();

            var movList = new List<MovimentoDiario>();

            if (dataPrevista.HasValue)
            {
                foreach (var mov in queryList)
                {
                    DateTime dataPrev = mov.ContribuicaoRecibo.Data_Prevista;
                    string dataPrevFormatada = dataPrev.ToString("dd/MM/yyyy");
                    if(dataPrevFormatada.Equals(dataPrevista.Value.ToString("dd/MM/yyyy"))){
                            movList.Add(mov);
                    }
                    
                }
                
            } else 
            {
                movList = queryList;
            }

            if (movList == null)
            {
                return NotFound();
            }

            return Ok(movList);
        }

        [HttpGet("movimentoDiario")]
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
        

         [HttpPost("MovimentoDiario")]
        public async Task<ActionResult<Mensageiro>> PostMovimentoDiario(MovimentoDiarioRequest movimentoDiarioRequest)
        {
            var contribuicao = await _context.Contribuicao.FindAsync(movimentoDiarioRequest.id_contribuicao);
            var mensageiro = await _context.Mensageiros.FindAsync(movimentoDiarioRequest.id_mensageiro);

            if (contribuicao == null || mensageiro == null)  
            {
                return BadRequest(new { message = "Campos inválidos." });
            }

            var movi_diario = new MovimentoDiario
            {
                ContribuicaoRecibo = contribuicao,
                Mensageiro = mensageiro,
                Data_Movimento = movimentoDiarioRequest.data_movimento
            };

            _context.MovimentosDiarios.Add(movi_diario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostMovimentoDiario), new { id = movi_diario.Id }, movi_diario); ;
        }
    }
}

public class MovimentoDiarioRequest
{
    public int id_mensageiro { get; set; }
    public int id_contribuicao{ get; set; }
    public DateTime data_movimento { get; set; }

}



