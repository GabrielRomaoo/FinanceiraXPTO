using FinanceiraXPTO.Domain.Entidades;
using FinanceiraXPTO.Dominio.Entidades;
using FinanceiraXPTO.Dominio.Enums;
using FinanceiraXPTO.Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FinanceiraXPTO.Controllers
{
    [ApiController]
    [Route("api/v1/analise")]
    [OpenApiTag("AnaliseCredito")]
    public class AnaliseCreditoController : ControllerBase
    {
        private readonly IAnaliseCreditoService _analiseCreditoService;

        public AnaliseCreditoController(IAnaliseCreditoService analiseCreditoService)
        {
            _analiseCreditoService = analiseCreditoService;
        }

        /// <summary>
        /// Analisa o pedido de crédito de um determinado cliente.
        /// </summary>
        /// <remarks>
        /// Método que recebe uma solicitação de análise de crédito, aplica regras de negócios e retorna o resulto da análise.
        /// </remarks>
        /// <response code="200">Retorna lista de endereços.</response>
        /// <response code="500">Erro interno da API.</response>
        [ProducesResponseType(typeof(ResultadoAnaliseCredito), 200)]
        [ProducesResponseType(typeof(ResultadoAnaliseCredito), 400)]
        [HttpPost]
        public async Task<ActionResult<ResultadoAnaliseCredito>> GetAnalise(Credito credito)
        {
            var resultado = await _analiseCreditoService.AnalisarCredito(credito);

            if(resultado.AnaliseCredito.Status == StatusCredito.Reprovado)
            {
                return BadRequest(resultado.AnaliseCredito);
            }
            return Ok(resultado.AnaliseCredito);
        }
    }
}
