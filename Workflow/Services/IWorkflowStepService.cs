using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Services
{

    public interface IWorkflowStepService
    {
        void CriarWorkflowStep(WorkflowStep inputs);
        void CriarWorkflowSteps(Guid IdWorkflow, List<WorkflowStep> workflowsteps);
        WorkflowStep ConsultarWorkflowStep(Guid IdWorkflowStep);
        WorkflowStep ConsultarWorkflowStep(Guid IdWorkflow, Guid IdStep);
        List<WorkflowStep> ConsultarWorkflowSteps();
        List<WorkflowStep> ConsultarStepsPorWorkflow(Guid IdWorkflow);
        void EditarWorkflowStep(WorkflowStep inputs);
        void DeletarWorkflowStep(Guid IdWorkflowStep);
    }

}
