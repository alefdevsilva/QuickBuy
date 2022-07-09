using System;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public ActionResult Get()
        {

            return Ok(_usuarioRepositorio.ObterTodos());
        }

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                    return Ok(usuarioRetorno);

                return BadRequest("Usuario e senha inválido!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _usuarioRepositorio.Obter(usuario.Email);

                if(usuarioCadastrado != null)
                    return BadRequest("Email já cadastrado!");
                
                _usuarioRepositorio.Adicionar(usuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
