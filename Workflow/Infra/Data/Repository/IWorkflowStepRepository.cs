using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Repository
{

    public interface IWorkflowStepRepository
    {
        void CriarWorkflowStep(WorkflowStep inputs);
        WorkflowStep ConsultarWorkflowStep(Guid IdWorkflowStep);
        WorkflowStep ConsultarWorkflowStep(Guid IdWorkflow, Guid IdStep);
        List<WorkflowStep> ConsultarWorkflowSteps();
        List<WorkflowStep> ConsultarStepsPorWorkflow(Guid IdWorkflow);
        void EditarWorkflowStep(WorkflowStep inputs);
        void DeletarWorkflowStep(Guid IdWorkflowStep);
    }

}
