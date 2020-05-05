using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class WorkflowStepVM : WorkflowStep
    {
        public WorkflowStepVM() { }
        public WorkflowStepVM(WorkflowStep inputs)
        {
            this.IdWorkflowStep = inputs.IdWorkflowStep;
            this.IdStatus = inputs.IdStatus;
            this.IdStep = inputs.IdStep;
            this.IdStepAnterior = inputs.IdStepAnterior;
            this.IdStepProximo = inputs.IdStepProximo;
            this.IdWorkflow = inputs.IdWorkflow;
            this.IsStepCorrente = inputs.IsStepCorrente;
            this.Ordem = inputs.Ordem;
        }
        public Status Status { get; set; }
        public StepVM Step { get; set; }
    }
}
