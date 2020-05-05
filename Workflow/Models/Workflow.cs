using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class Workflow
    {
        public Guid IdWorkflow { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsModelo { get; set; }
        public Guid IdConta { get; set; }
    }
}
