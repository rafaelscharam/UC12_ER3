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
    
    //[Authorize]

    public class LivrosController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivrosController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        // GET /api/livros
        [HttpGet]
        public IActionResult Listar()
        {
            // retorna no corpo da resposta, a lista de livros
            // retorna o status Ok - 200, sucesso

            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //GET /api/livros/1
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro LivroProcurado = _livroRepository.BuscarPorId(id);

                if (LivroProcurado == null)
                {
                    return NotFound();
                }
                return Ok(LivroProcurado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]

        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                //return StatusCode(201);
                return Ok("Livro Cadastrado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);

                //return StatusCode(204);
                return Ok("Livro Atualizado");

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
                _livroRepository.Deletar(id);

                //return StatusCode(204);
                return Ok("Livro Deletado");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }


}

