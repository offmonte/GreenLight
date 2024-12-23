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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Buscar todos Usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return Ok(await _usuarioRepository.GetUsuarios());
        }
        /// <summary>
        /// Buscar Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var result = await _usuarioRepository.GetUsuario(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null) return BadRequest();
            var createdUsuario = await _usuarioRepository.AddUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, createdUsuario);
        }
        /// <summary>
        /// Update Usuario
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            var usuarioToUpdate = await _usuarioRepository.GetUsuario(id);
            if (usuarioToUpdate == null) return NotFound();

            return await _usuarioRepository.UpdateUsuario(usuario);
        }
        /// <summary>
        /// Deletar Usuario
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var usuarioToDelete = await _usuarioRepository.GetUsuario(id);
            if (usuarioToDelete == null) return NotFound();

            _usuarioRepository.DeleteUsuario(id);
            return Ok($"Usuário com ID {id} deletado.");
        }
    }
}
