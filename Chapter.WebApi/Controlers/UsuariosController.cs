using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chapter.WebApi.Controlers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);            
            }
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioProcurado = _usuarioRepository.BuscarPorId(id);

                if (usuarioProcurado == null)
                { 
                    return NotFound();
                }
                return Ok(usuarioProcurado);

            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]

        public IActionResult Cadastrar(Usuario u)
        {
            try
            {
                _usuarioRepository.Cadastrar(u);

                //return StatusCode(201);
                return Ok("Usuario Cadastrado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(int id, Usuario u)
        {
            try
            {
                _usuarioRepository.Atualizar(id, u);

                //return StatusCode(204);
                return Ok("Usuario Atualizado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                //return StatusCode(204);
                return Ok("Usuario Deletado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
