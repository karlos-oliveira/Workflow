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

    [Route("api/v1/GrupoAprovador")]
    [ApiController]
    public class GrupoAprovadorController : ControllerBase
    {
        private readonly IGrupoAprovadorService _serv;
        public GrupoAprovadorController(IGrupoAprovadorService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarGrupoAprovador([FromBody] GrupoAprovador inputs)
        {
            try
            {
                inputs.IdConta = Request.ObterIdConta();
                _serv.CriarGrupoAprovador(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo GrupoAprovador: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idGrupoAprovador}")]
        public ActionResult ConsultarGrupoAprovador([FromRoute] Guid IdGrupoAprovador)
        {
            try
            {
                var response = _serv.ConsultarGrupoAprovador(IdGrupoAprovador);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o GrupoAprovador {IdGrupoAprovador}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarGrupoAprovadores()
        {
            try
            {
                var idConta = Request.ObterIdConta();
                var response = _serv.ConsultarGrupoAprovadores(idConta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar GrupoAprovadors: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarGrupoAprovador([FromBody] GrupoAprovador inputs)
        {
            try
            {
                _serv.EditarGrupoAprovador(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o GrupoAprovador {inputs.IdGrupoAprovador}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idGrupoAprovador}")]
        public ActionResult DeletarGrupoAprovador([FromRoute] Guid IdGrupoAprovador)
        {
            try
            {
                _serv.DeletarGrupoAprovador(IdGrupoAprovador);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o GrupoAprovador {IdGrupoAprovador}: {ex.Message}");
            }
        }
    }

}