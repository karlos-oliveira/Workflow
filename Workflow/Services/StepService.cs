using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class StepService : IStepService
    {
        private readonly IStepRepository _repo;
        public StepService(IStepRepository repo)
        {
            _repo = repo;
        }

        public Step ConsultarStep(Guid IdStep)
        {
            return _repo.ConsultarStep(IdStep);
        }

        public List<Step> ConsultarSteps(Guid IdConta)
        {
            return _repo.ConsultarSteps(IdConta);
        }

        public void CriarStep(Step inputs)
        {
            inputs.IdStep = Guid.NewGuid();

            _repo.CriarStep(inputs);
        }

        public void DeletarStep(Guid IdStep)
        {
            _repo.DeletarStep(IdStep);
        }

        public void EditarStep(Step inputs)
        {
            _repo.EditarStep(inputs);
        }
    }

}
