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

    [Route("api/v1/Step")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _serv;

        public StepController(IStepService serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public ActionResult CriarStep([FromBody] Step inputs)
        {
            try
            {
                inputs.IdConta = Request.ObterIdConta();
                _serv.CriarStep(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Step: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idStep}")]
        public ActionResult ConsultarStep([FromRoute] Guid IdStep)
        {
            try
            {
                var response = _serv.ConsultarStep(IdStep);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Step {IdStep}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarSteps()
        {
            try
            {
                var idConta = Request.ObterIdConta();
                var response = _serv.ConsultarSteps(idConta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Steps: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarStep([FromBody] Step inputs)
        {
            try
            {
                _serv.EditarStep(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o Step {inputs.IdStep}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idStep}")]
        public ActionResult DeletarStep([FromRoute] Guid IdStep)
        {
            try
            {
                _serv.DeletarStep(IdStep);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Step {IdStep}: {ex.Message}");
            }
        }
    }

}