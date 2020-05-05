using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _repo;
        private readonly IWorkflowStepService _wfsServ;
        private readonly IStepService _stepServ;
        private readonly IStatusService _statusServ;
        private readonly IGrupoAprovadorService _gaServ;
        private readonly IGrupoAprovadorUsuarioService _gauServ;
        private readonly IUsuarioService _usuarioServ;
        public WorkflowService(IWorkflowRepository repo,
                                IWorkflowStepService wfsServ,
                                IStepService stepServ,
                                IStatusService statusServ,
                                IGrupoAprovadorService gaServ,
                                IGrupoAprovadorUsuarioService gauServ,
                                IUsuarioService usuarioServ)
        {
            _repo = repo;
            _wfsServ = wfsServ;
            _stepServ = stepServ;
            _statusServ = statusServ;
            _gaServ = gaServ;
            _gauServ = gauServ;
            _usuarioServ = usuarioServ;
        }

        public Models.Workflow ConsultarWorkflow(Guid IdWorkflow)
        {
            return _repo.ConsultarWorkflow(IdWorkflow);
        }

        public WorkflowVM ConsultarWorkflowCompleto(Guid IdWorkflow)
        {
            WorkflowVM wfvm = new WorkflowVM(ConsultarWorkflow(IdWorkflow));

            var wfsteps = _wfsServ.ConsultarStepsPorWorkflow(IdWorkflow);

            foreach (var _wfstep in wfsteps)
            {
                var wfs = new WorkflowStepVM(_wfstep);
                wfs.Status = _statusServ.ConsultarStatus(_wfstep.IdStatus);
                wfs.Step = new StepVM(_stepServ.ConsultarStep(_wfstep.IdStep));
                wfs.Step.GrupoAprovador = new GrupoAprovadorVM(_gaServ.ConsultarGrupoAprovador(wfs.Step.IdGrupoAprovador));

                var lstgau = _gauServ.ConsultarGrupoAprovadorUsuarios(wfs.Step.IdGrupoAprovador);

                foreach (var gau in lstgau)
                {
                    wfs.Step.GrupoAprovador.Aprovadores.Add(_usuarioServ.ConsultarUsuario(gau.IdUsuario));
                }

                wfvm.WorkflowSteps.Add(wfs);
            }

            return wfvm;
        }

        public List<Models.Workflow> ConsultarWorkflows(Guid IdConta)
        {
            return _repo.ConsultarWorkflows(IdConta);
        }

        public List<Models.Workflow> ConsultarWorkflowsModelo(Guid IdConta)
        {
            return _repo.ConsultarWorkflowsModelo(IdConta);
        }

        public Guid CriarWorkflow(Models.Workflow inputs)
        {
            inputs.IdWorkflow = Guid.NewGuid();

            _repo.CriarWorkflow(inputs);

            return inputs.IdWorkflow;
        }

        public Guid CriarWorkflow(Guid IdWorkflow)
        {
            var wf = ConsultarWorkflow(IdWorkflow);
            var workflowSteps = _wfsServ.ConsultarStepsPorWorkflow(IdWorkflow);

            if (workflowSteps.Count == 0)
                throw new Exception($"Não há nenhuma tarefa cadastrada para o modelo de workflow '{wf.Nome}'");

            wf.IsModelo = false;
            wf.IdWorkflow = CriarWorkflow(wf);

            _wfsServ.CriarWorkflowSteps(wf.IdWorkflow, workflowSteps);

            return wf.IdWorkflow;
        }

        public void DeletarWorkflow(Guid IdWorkflow)
        {
            _repo.DeletarWorkflow(IdWorkflow);
        }

        public void EditarWorkflow(Models.Workflow inputs)
        {
            _repo.EditarWorkflow(inputs);
        }
    }

}
