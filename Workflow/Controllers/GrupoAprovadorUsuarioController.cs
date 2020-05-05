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

    [Route("api/v1/GrupoAprovadorUsuario")]
    [ApiController]
    public class GrupoAprovadorUsuarioController : ControllerBase
    {
        private readonly IGrupoAprovadorUsuarioService _serv;

        public GrupoAprovadorUsuarioController(IGrupoAprovadorUsuarioService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarGrupoAprovadorUsuario([FromBody] GrupoAprovadorUsuario inputs)
        {
            try
            {
                _serv.CriarGrupoAprovadorUsuario(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo GrupoAprovadorUsuario: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idGrupoAprovadorUsuario}")]
        public ActionResult ConsultarGrupoAprovadorUsuario([FromRoute] Guid IdGrupoAprovadorUsuario)
        {
            try
            {
                var response = _serv.ConsultarGrupoAprovadorUsuario(IdGrupoAprovadorUsuario);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o GrupoAprovadorUsuario {IdGrupoAprovadorUsuario}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarGrupoAprovadorUsuarios()
        {
            try
            {
                var response = _serv.ConsultarGrupoAprovadorUsuarios();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar GrupoAprovadorUsuarios: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarGrupoAprovadorUsuario([FromBody] GrupoAprovadorUsuario inputs)
        {
            try
            {
                _serv.EditarGrupoAprovadorUsuario(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o GrupoAprovadorUsuario {inputs.IdGrupoAprovadorUsuario}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idGrupoAprovadorUsuario}")]
        public ActionResult DeletarGrupoAprovadorUsuario([FromRoute] Guid IdGrupoAprovadorUsuario)
        {
            try
            {
                _serv.DeletarGrupoAprovadorUsuario(IdGrupoAprovadorUsuario);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o GrupoAprovadorUsuario {IdGrupoAprovadorUsuario}: {ex.Message}");
            }
        }
    }

}