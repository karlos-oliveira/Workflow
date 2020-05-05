using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Repository
{

    public interface IStatusRepository
    {
        void CriarStatus(Status inputs);
        Status ConsultarStatus(Guid IdStatus);
        List<Status> ConsultarStatuss();
        void EditarStatus(Status inputs);
        void DeletarStatus(Guid IdStatus);
    }

}
