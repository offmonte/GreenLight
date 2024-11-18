﻿using Microsoft.AspNetCore.Mvc;
using GreenLight.Models;
using GreenLight.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GreenLight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroRepository _registroRepository;

        public RegistroController(IRegistroRepository registroRepository)
        {
            _registroRepository = registroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro>>> GetRegistros()
        {
            return Ok(await _registroRepository.GetRegistros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> GetRegistro(int id)
        {
            var result = await _registroRepository.GetRegistro(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Registro>> AddRegistro([FromBody] Registro registro)
        {
            if (registro == null) return BadRequest();
            var createdRegistro = await _registroRepository.AddRegistro(registro);
            return CreatedAtAction(nameof(GetRegistro), new { id = createdRegistro.Id }, createdRegistro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Registro>> UpdateRegistro(int id, [FromBody] Registro registro)
        {
            var registroToUpdate = await _registroRepository.GetRegistro(id);
            if (registroToUpdate == null) return NotFound();

            return await _registroRepository.UpdateRegistro(registro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegistro(int id)
        {
            var registroToDelete = await _registroRepository.GetRegistro(id);
            if (registroToDelete == null) return NotFound();

            _registroRepository.DeleteRegistro(id);
            return Ok($"Registro com ID {id} deletado.");
        }
    }
}