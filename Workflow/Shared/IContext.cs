using Workflow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Workflow.Shared
{
    public interface IContext : IDisposable
    {
        DbSet<GrupoAprovador> GrupoAprovador { get; }
        DbSet<GrupoAprovadorUsuario> GrupoAprovadorUsuario { get; }
        DbSet<Status> Status { get; }
        DbSet<Step> Step { get; }
        DbSet<Usuario> Usuario { get; }
        DbSet<Models.Workflow> Workflow { get; }
        DbSet<WorkflowStep> WorkflowStep { get; }
        DatabaseFacade Database { get; }
        DbSet<T> DbSet<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();

    }
}