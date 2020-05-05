using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repo;
        public StatusService(IStatusRepository repo)
        {
            _repo = repo;
        }

        public Status ConsultarStatus(Guid IdStatus)
        {
            return _repo.ConsultarStatus(IdStatus);
        }

        public List<Status> ConsultarStatus()
        {
            return _repo.ConsultarStatuss();
        }

        public void CriarStatus(Status inputs)
        {
            inputs.IdStatus = Guid.NewGuid();

            _repo.CriarStatus(inputs);
        }

        public void DeletarStatus(Guid IdStatus)
        {
            _repo.DeletarStatus(IdStatus);
        }

        public void EditarStatus(Status inputs)
        {
            _repo.EditarStatus(inputs);
        }
    }

}
