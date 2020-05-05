using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class StatusRepository : IStatusRepository
    {
        private readonly IContext _context;

        public StatusRepository(IContext context)
        {
            _context = context;
        }

        public Status ConsultarStatus(Guid IdStatus)
        {
            return _context.Status.Where(x => x.IdStatus == IdStatus).First();
        }

        public List<Status> ConsultarStatuss()
        {
            return _context.Status.Where(x => x.IsAtivo).ToList();
        }

        public void CriarStatus(Status inputs)
        {
            _context.Status.Add(inputs);
            _context.Commit();
        }

        public void DeletarStatus(Guid IdStatus)
        {
            _context.Status.Find(IdStatus).IsAtivo = false;
            _context.Commit();
        }

        public void EditarStatus(Status inputs)
        {
            _context.Status.Update(inputs);
            _context.Commit();
        }
    }

}
