using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Services
{

    public interface IWorkflowService
    {
        Guid CriarWorkflow(Models.Workflow inputs);
        Guid CriarWorkflow(Guid IdWorkflow);
        Models.Workflow ConsultarWorkflow(Guid IdWorkflow);
        Models.WorkflowVM ConsultarWorkflowCompleto(Guid IdWorkflow);
        List<Models.Workflow> ConsultarWorkflows(Guid IdConta);
        List<Models.Workflow> ConsultarWorkflowsModelo(Guid IdConta);
        void EditarWorkflow(Models.Workflow inputs);
        void DeletarWorkflow(Guid IdWorkflow);
    }

}
