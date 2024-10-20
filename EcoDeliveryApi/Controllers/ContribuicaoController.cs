
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoDeliveryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuicaoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ContribuicaoController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuicao>>> GetContribuicoes()
        {
            var contribuicoes = await _context.Contribuicao
                .Include(c => c.TipoPagamento)
                .Include(c => c.Contribuinte)
                .ToListAsync();

            return contribuicoes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuicao>> GetContribuicao(int id)
        {
            var contribuicao = await _context.Contribuicao
            .Include(c => c.Contribuinte)  // Incluir a navegação para Contribuinte
            .FirstOrDefaultAsync(c => c.Id == id);  // Busca a contribuição pelo Id
            return contribuicao;
        }

        [HttpPut]
        public async Task<ActionResult<Contribuicao>> UpdateStatus(ContribuicaoPut contribuicaoPut)
        {
            var contribuicao = await _context.Contribuicao.FindAsync(contribuicaoPut.Id);

            if (contribuicao == null)
            {
                return NotFound();
            }

            contribuicao.Status = Contribuicao.GetStatusEnum(contribuicaoPut.Status);
            _context.Contribuicao.Update(contribuicao);
            _context.SaveChanges();

            return contribuicao;
        }
    }

    public class ContribuicaoPut
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }

}
