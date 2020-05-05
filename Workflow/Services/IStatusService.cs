using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Services
{

    public interface IStatusService
    {
        void CriarStatus(Status inputs);
        Status ConsultarStatus(Guid IdStatus);
        List<Status> ConsultarStatus();
        void EditarStatus(Status inputs);
        void DeletarStatus(Guid IdStatus);
    }

}
