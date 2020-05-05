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

    [Route("api/v1/Workflow")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _serv;
        private readonly IWorkflowStepService _servWorkflowStep;
        
        public WorkflowController(IWorkflowService serv, IWorkflowStepService servWorkflowStep)
        {
            _serv = serv;
            _servWorkflowStep = servWorkflowStep;
        }

        [HttpPost]
        public ActionResult CriarWorkflowModelo([FromBody] Models.Workflow inputs)
        {
            try
            {
                inputs.IsModelo = true;
                inputs.IdConta = Request.ObterIdConta();
                var IdWorkflowCriado = _serv.CriarWorkflow(inputs);

                return Ok(IdWorkflowCriado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Workflow: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("{idWorkflow}")]
        public ActionResult CriarWorkflow([FromRoute] Guid IdWorkflow)
        {
            try
            {
                var IdWorkflowCriado = _serv.CriarWorkflow(IdWorkflow);

                return Ok(IdWorkflowCriado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Workflow: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("{idWorkflow}/steps")]
        public ActionResult CriarWorkflowSteps([FromRoute] Guid IdWorkflow, [FromBody] List<WorkflowStep> workflowsteps)
        {
            try
            {
                _servWorkflowStep.CriarWorkflowSteps(IdWorkflow, workflowsteps);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo Workflow: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idWorkflow}")]
        public ActionResult ConsultarWorkflow([FromRoute] Guid IdWorkflow)
        {
            try
            {
                var response = _serv.ConsultarWorkflow(IdWorkflow);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Workflow {IdWorkflow}: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idWorkflow}/completo")]
        public ActionResult ConsultarWorkflowCompleto([FromRoute] Guid IdWorkflow)
        {
            try
            {
                var response = _serv.ConsultarWorkflowCompleto(IdWorkflow);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Workflow {IdWorkflow}: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{idWorkflow}/steps")]
        public ActionResult ConsultarWorkflowSteps([FromRoute] Guid IdWorkflow)
        {
            try
            {
                var response = _servWorkflowStep.ConsultarStepsPorWorkflow(IdWorkflow);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o Workflow {IdWorkflow}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarWorkflows()
        {
            try
            {
                var idConta = Request.ObterIdConta();
                var response = _serv.ConsultarWorkflows(idConta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Workflows: {ex.Message}");
            }
        }

        [HttpGet("modelos")]
        public ActionResult ConsultarWorkflowsModelo()
        {
            try
            {
                var idConta = Request.ObterIdConta();
                var response = _serv.ConsultarWorkflowsModelo(idConta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar Workflows: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarWorkflow([FromBody] Models.Workflow inputs)
        {
            try
            {
                _serv.EditarWorkflow(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o Workflow {inputs.IdWorkflow}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idWorkflow}")]
        public ActionResult DeletarWorkflow([FromRoute] Guid IdWorkflow)
        {
            try
            {
                _serv.DeletarWorkflow(IdWorkflow);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o Workflow {IdWorkflow}: {ex.Message}");
            }
        }
    }

}