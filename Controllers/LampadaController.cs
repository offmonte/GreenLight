using Microsoft.AspNetCore.Mvc;
using GreenLight.Models;
using GreenLight.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GreenLight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampadaController : ControllerBase
    {
        private readonly ILampadaRepository _lampadaRepository;

        public LampadaController(ILampadaRepository lampadaRepository)
        {
            _lampadaRepository = lampadaRepository;
        }
        /// <summary>
        /// Buscar todas Lampadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lampada>>> GetLampadas()
        {
            return Ok(await _lampadaRepository.GetLampadas());
        }
        /// <summary>
        /// Buscar Lampada
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Lampada>> GetLampada(int id)
        {
            var result = await _lampadaRepository.GetLampada(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Criar Lampada
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Lampada>> AddLampada([FromBody] Lampada lampada)
        {
            if (lampada == null) return BadRequest();
            var createdLampada = await _lampadaRepository.AddLampada(lampada);
            return CreatedAtAction(nameof(GetLampada), new { id = createdLampada.Id }, createdLampada);
        }
        /// <summary>
        /// Update Lampada
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Lampada>> UpdateLampada(int id, [FromBody] Lampada lampada)
        {
            var lampadaToUpdate = await _lampadaRepository.GetLampada(id);
            if (lampadaToUpdate == null) return NotFound();

            return await _lampadaRepository.UpdateLampada(lampada);
        }
        /// <summary>
        /// Deletar Lampada
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLampada(int id)
        {
            var lampadaToDelete = await _lampadaRepository.GetLampada(id);
            if (lampadaToDelete == null) return NotFound();

            _lampadaRepository.DeleteLampada(id);
            return Ok($"Lâmpada com ID {id} deletada.");
        }
    }
}
