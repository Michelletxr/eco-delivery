
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EcoDeliveryApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuinteController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ContribuinteController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuinte>>> GetContribuinte()
        {
            return await _context.Contribuintes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuinte>> GetContribuinte(int id)
        {
            var Contribuinte = await _context.Contribuintes.FindAsync(id);

            if (Contribuinte == null)
            {
                return NotFound();
            }

            return Contribuinte;
        }

        [HttpGet("Contribuicao/{id}")]
        public async Task<ActionResult<Contribuicao>> GetContribuicao(int id)
        {
           var contribuinte = await _context.Contribuintes.FindAsync(id);
            if (contribuinte == null)
            {
                return NotFound(new { message = "Contribuinte não encontrado." });
            }

            // Busca todas as contribuições do contribuinte
            var contribuicoes = await _context.Contribuicao
                .Where(c => c.Contribuinte.Id == id)
                .ToListAsync();

            // Verifica se há contribuições para o contribuinte
            if (contribuicoes == null || !contribuicoes.Any())
            {
                return NotFound(new { message = "Contribuinte não possui contribuições." });
            }

            return Ok(contribuicoes);
        }


        [HttpPost]
        public async Task<ActionResult<Contribuinte>> PostContribuinte(Contribuinte contribuinte)
        {
            _context.Contribuintes.Add(contribuinte);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContribuinte), new { id = contribuinte.Id }, contribuinte);
        }

        [HttpPost("contribuicao")]
        public async Task<ActionResult<Contribuicao>> PostContribuicao(ContribuicaoRequest contribuicaoRequest){
            
            var contribuinte = await _context.Contribuintes.FindAsync(contribuicaoRequest.id_contribuinte);
            var tipoPagamento = await _context.TipoPagamentos.FindAsync(contribuicaoRequest.id_tipo_pagamento);

            if (contribuinte == null || tipoPagamento == null)  
            {
                return BadRequest(new { message = "Campos inválidos." });
            }

            var contribuicao = new Contribuicao
            {
                Contribuinte = contribuinte,
                TipoPagamento = tipoPagamento,
                Data_Prevista = contribuicaoRequest.Data_Prevista,
                valor = contribuicaoRequest.valor,
            };

             // Adiciona e salva a nova contribuição
            _context.Contribuicao.Add(contribuicao);
            await _context.SaveChangesAsync();

            // Retorna a contribuição criada com o código de status 201 (Created)
            return CreatedAtAction(nameof(PostContribuicao), new { id = contribuicao.Id }, contribuicao); ;
        }

    }
}

public class ContribuicaoRequest
{
    public Double valor { get; set; }

    public int id_tipo_pagamento{ get; set; }

    public int id_contribuinte{ get; set; }

    public DateTime Data_Prevista { get; set; }


}