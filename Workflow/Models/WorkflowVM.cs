using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class WorkflowVM : Workflow
    {
        public WorkflowVM() 
        {
            this.WorkflowSteps = new List<WorkflowStepVM>();
        }
        public WorkflowVM(Workflow input)
        {
            this.IdWorkflow = input.IdWorkflow;
            this.Descricao = input.Descricao;
            this.Nome = input.Nome;
            this.IsAtivo = input.IsAtivo;
            this.IsModelo = input.IsModelo;
            this.WorkflowSteps = new List<WorkflowStepVM>();
        }
        public List<WorkflowStepVM> WorkflowSteps { get; set; }

    }
}
