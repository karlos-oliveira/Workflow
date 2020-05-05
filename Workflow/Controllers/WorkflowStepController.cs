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

    [Route("api/v1/WorkflowStep")]
    [ApiController]
    public class WorkflowStepController : ControllerBase
    {
        private readonly IWorkflowStepService _serv;
        private readonly IGrupoAprovadorUsuarioService _servGAU;
        private readonly IStepService _servStep;

        public WorkflowStepController(IWorkflowStepService serv, 
                                      IGrupoAprovadorUsuarioService servGAU, 
                                      IStepService servStep)
        {
            _serv = serv;
            _servGAU = servGAU;
            _servStep = servStep;
        }

        [HttpPost]
        public ActionResult CriarWorkflowStep([FromBody] WorkflowStep inputs)
        {
            try
            {
                _serv.CriarWorkflowStep(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao criar um novo WorkflowStep: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("{idWorkflowStep}")]
        public ActionResult ConsultarWorkflowStep([FromRoute] Guid IdWorkflowStep)
        {
            try
            {
                var response = _serv.ConsultarWorkflowStep(IdWorkflowStep);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao consultar o WorkflowStep {IdWorkflowStep}: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult ConsultarWorkflowSteps()
        {
            try
            {
                var response = _serv.ConsultarWorkflowSteps();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao listar WorkflowSteps: {ex.Message}");
            }
        }

        [HttpPut]
        public ActionResult EditarWorkflowStep([FromBody] WorkflowStep inputs)
        {
            try
            {
                _serv.EditarWorkflowStep(inputs);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o WorkflowStep {inputs.IdWorkflowStep}: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{idWorkflowStep}/aprovar")]
        public ActionResult AprovarWorkflowStep([FromRoute]Guid IdWorkflowStep)
        {
            try
            {
                var idUsuario = Request.ObterIdUsuario();
                var idConta = Request.ObterIdConta();

                var wfs = _serv.ConsultarWorkflowStep(IdWorkflowStep);

                var proximoWfs = wfs.IdStepProximo.Equals(Guid.Empty) ? null : _serv.ConsultarWorkflowStep(wfs.IdWorkflow, wfs.IdStepProximo);
                var step = _servStep.ConsultarStep(wfs.IdStep);

                if (!_servGAU.IsUsuarioNoGrupo(step.IdGrupoAprovador, idUsuario))
                    return StatusCode(401, "Usuário sem permissão para editar esta tarefa");

                if (!wfs.IsStepCorrente)
                    return BadRequest("A tarefa que está tentando editar não está ativa");

                wfs.DataAtualizacao = DateTime.Now;
                wfs.IdUsuarioAtualizacao = idUsuario;
                wfs.IdStatus = Guid.Parse("5c35bd71-1348-4d53-8396-b6592048142b");// StatusId Aprovado
                wfs.IsStepCorrente = false;

                _serv.EditarWorkflowStep(wfs);

                if(proximoWfs != null)
                {
                    proximoWfs.IsStepCorrente = true;
                    _serv.EditarWorkflowStep(proximoWfs);
                }
                //verificar a necessidade de ter um status no workflow
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o WorkflowStep {IdWorkflowStep}: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{idWorkflowStep}/rejeitar")]
        public ActionResult RejeitarWorkflowStep([FromRoute]Guid IdWorkflowStep)
        {
            try
            {
                var idUsuario = Request.ObterIdUsuario();
                var idConta = Request.ObterIdConta();

                var wfs = _serv.ConsultarWorkflowStep(IdWorkflowStep);

                //var anteriorWfs = wfs.IdStepAnterior.Equals(Guid.Empty) ? null : _serv.ConsultarWorkflowStep(wfs.IdWorkflow, wfs.IdStepAnterior);
                var step = _servStep.ConsultarStep(wfs.IdStep);

                if (!_servGAU.IsUsuarioNoGrupo(step.IdGrupoAprovador, idUsuario))
                    return StatusCode(401, "Usuário sem permissão para editar esta tarefa");

                if (!wfs.IsStepCorrente)
                    return BadRequest("A tarefa que está tentando editar não está ativa");

                wfs.DataAtualizacao = DateTime.Now;
                wfs.IdUsuarioAtualizacao = idUsuario;
                wfs.IdStatus = Guid.Parse("e46d78b4-538c-4304-ab16-55c0b20019f7");// StatusId Cancelado
                //wfs.IsStepCorrente = false;

                _serv.EditarWorkflowStep(wfs);

                //if (anteriorWfs != null)
                //{
                //    anteriorWfs.IsStepCorrente = true;
                //    _serv.EditarWorkflowStep(anteriorWfs);
                //}
               
                //verificar a necessidade de ter um status no workflow
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao editar o WorkflowStep {IdWorkflowStep}: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{idWorkflowStep}")]
        public ActionResult DeletarWorkflowStep([FromRoute] Guid IdWorkflowStep)
        {
            try
            {
                _serv.DeletarWorkflowStep(IdWorkflowStep);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao deletar o WorkflowStep {IdWorkflowStep}: {ex.Message}");
            }
        }
    }

}