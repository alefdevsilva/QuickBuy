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

        [HttpPost("VerificarUsuario")]
        public ActionResult VerificarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.ObterPorId(usuario.Id);
                if (usuarioRetorno != null)
                    return Ok(usuarioRetorno);

                return BadRequest("Usuario e senha inválido!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
