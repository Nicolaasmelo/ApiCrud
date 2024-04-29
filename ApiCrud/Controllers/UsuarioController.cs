using ApiCrud.Models;
using ApiCrud.Repositorios;
using ApiCrud.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;


        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModels>>> BuscarTodosUsuarios()
        {
            List<UsuarioModels> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModels>>> BuscarPorId(int id)
        {
            UsuarioModels usuarios = await _usuarioRepositorio.BuscarPorId(id);

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModels>> Cadastar([FromBody] UsuarioModels usuarioModels)
        {
           UsuarioModels usuario = await _usuarioRepositorio.Adicionar(usuarioModels);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModels>> Atualizar([FromBody] UsuarioModels usuarioModels, int id)
        {
            usuarioModels.Id = id;
            UsuarioModels usuario = await _usuarioRepositorio.Atualizar(usuarioModels, id);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModels>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
