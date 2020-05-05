using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Workflow.Shared
{
    public interface IUnitOfWork
    {
        void Rollback();

        Task CommitAsync();

        void Commit();
       // IDbContextTransaction BeginTransaction(ICapPublisher capPublisher, bool autoCommit = true);
        IDbContextTransaction BeginTransaction();
    }
}
