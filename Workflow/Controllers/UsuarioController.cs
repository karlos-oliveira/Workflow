using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workflow.Models;
using Workflow.Services;

namespace Workflow.Controllers
{

    [Route("api/v1/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _serv;
        public UsuarioController(IUsuarioService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarUsuario([FromBody] Usuario inputs)
        {
            try
            {
                inputs.IdConta = Request.ObterIdConta();
                _serv.CriarUsuario(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Usuario: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idUsuario}")]
        public ActionResult ConsultarUsuario([FromRoute] Guid IdUsuario)
        {
            try
            {
                var response = _serv.ConsultarUsuario(IdUsuario);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Usuario {IdUsuario}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarUsuarios()
        {
            try
            {
                var idConta = Request.ObterIdConta();
                var response = _serv.ConsultarUsuarios(idConta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Usuarios: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarUsuario([FromBody] Usuario inputs)
        {
            try
            {
                _serv.EditarUsuario(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o Usuario {inputs.IdUsuario}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idUsuario}")]
        public ActionResult DeletarUsuario([FromRoute] Guid IdUsuario)
        {
            try
            {
                _serv.DeletarUsuario(IdUsuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Usuario {IdUsuario}: {ex.Message}");
            }
        }
    }

}