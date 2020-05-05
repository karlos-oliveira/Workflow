using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Repository
{

    public interface IStepRepository
    {
        void CriarStep(Step inputs);
        Step ConsultarStep(Guid IdStep);
        List<Step> ConsultarSteps(Guid IdConta);
        void EditarStep(Step inputs);
        void DeletarStep(Guid IdStep);
    }

}
