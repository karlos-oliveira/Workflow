using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Infra.Data.Repository
{

    public interface IWorkflowRepository
    {
        void CriarWorkflow(Models.Workflow inputs);
        Models.Workflow ConsultarWorkflow(Guid IdWorkflow);
        List<Models.Workflow> ConsultarWorkflows(Guid IdConta);
        List<Models.Workflow> ConsultarWorkflowsModelo(Guid IdConta);
        void EditarWorkflow(Models.Workflow inputs);
        void DeletarWorkflow(Guid IdWorkflow);
    }

}
