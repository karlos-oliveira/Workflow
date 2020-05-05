using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class Status
    {
        public Guid IdStatus { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
        public bool BloqueiaAndamento { get; set; }

    }
}
