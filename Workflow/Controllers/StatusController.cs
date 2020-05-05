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

    [Route("api/v1/Status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _serv;

        public StatusController(IStatusService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarStatus([FromBody] Status inputs)
        {
            try
            {
                _serv.CriarStatus(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Status: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idStatus}")]
        public ActionResult ConsultarStatus([FromRoute] Guid IdStatus)
        {
            try
            {
                var response = _serv.ConsultarStatus(IdStatus);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Status {IdStatus}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarStatuss()
        {
            try
            {
                var response = _serv.ConsultarStatus();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Statuss: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarStatus([FromBody] Status inputs)
        {
            try
            {
                _serv.EditarStatus(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o Status {inputs.IdStatus}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idStatus}")]
        public ActionResult DeletarStatus([FromRoute] Guid IdStatus)
        {
            try
            {
                _serv.DeletarStatus(IdStatus);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Status {IdStatus}: {ex.Message}");
            }
        }
    }

}