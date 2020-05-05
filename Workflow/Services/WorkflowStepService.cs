using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class WorkflowStepService : IWorkflowStepService
    {
        private readonly IWorkflowStepRepository _repo;
        public WorkflowStepService(IWorkflowStepRepository repo)
        {
            _repo = repo;
        }

        public List<WorkflowStep> ConsultarStepsPorWorkflow(Guid IdWorkflow)
        {
            return _repo.ConsultarStepsPorWorkflow(IdWorkflow);
        }

        public WorkflowStep ConsultarWorkflowStep(Guid IdWorkflowStep)
        {
            return _repo.ConsultarWorkflowStep(IdWorkflowStep);
        }

        public WorkflowStep ConsultarWorkflowStep(Guid IdWorkflow, Guid IdStep)
        {
            return _repo.ConsultarWorkflowStep(IdWorkflow, IdStep);
        }

        public List<WorkflowStep> ConsultarWorkflowSteps()
        {
            return _repo.ConsultarWorkflowSteps();
        }

        public void CriarWorkflowStep(WorkflowStep inputs)
        {
            inputs.IdWorkflowStep = Guid.NewGuid();

            _repo.CriarWorkflowStep(inputs);
        }

        public void CriarWorkflowSteps(Guid IdWorkflow, List<WorkflowStep> workflowsteps)
        {
            foreach (var workflowstep in workflowsteps)
            {
                if (workflowstep.IdWorkflow != IdWorkflow)
                    workflowstep.IdWorkflow = IdWorkflow;

                if (workflowstep.Ordem == 0)
                    workflowstep.IsStepCorrente = true;

                CriarWorkflowStep(workflowstep);
            }
        }

        public void DeletarWorkflowStep(Guid IdWorkflowStep)
        {
            _repo.DeletarWorkflowStep(IdWorkflowStep);
        }

        public void EditarWorkflowStep(WorkflowStep inputs)
        {
            _repo.EditarWorkflowStep(inputs);
        }
    }

}
