using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class WorkflowStep
    {
        public Guid IdWorkflowStep { get; set; }
        public Guid IdWorkflow { get; set; }
        public Guid IdStep { get; set; }
        public Guid IdStepAnterior { get; set; }
        public Guid IdStepProximo { get; set; }
        public Guid IdStatus { get; set; }
        public Guid IdUsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Ordem { get; set; }
        public bool IsStepCorrente { get; set; }

    }
}
