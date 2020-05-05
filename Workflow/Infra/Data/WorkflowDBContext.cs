using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Configurations;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data
{
    public class WorkflowDBContext : DbContext, IContext
    {
        public WorkflowDBContext(DbContextOptions<WorkflowDBContext> options) : base(options) { }

        public DbSet<GrupoAprovador> GrupoAprovador { get { return this.Set<GrupoAprovador>(); } }
        public DbSet<GrupoAprovadorUsuario> GrupoAprovadorUsuario { get { return this.Set<GrupoAprovadorUsuario>(); } }
        public DbSet<Status> Status { get { return this.Set<Status>(); } }
        public DbSet<Step> Step { get { return this.Set<Step>(); } }
        public DbSet<Usuario> Usuario { get { return this.Set<Usuario>(); } }
        public DbSet<Models.Workflow> Workflow { get { return this.Set<Models.Workflow>(); } }
        public DbSet<WorkflowStep> WorkflowStep { get { return this.Set<WorkflowStep>(); } }
     
        public int Commit()
        {
            return this.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.DbSet<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GrupoAprovadorConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoAprovadorUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new StepConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new WorkflowConfiguration());
            modelBuilder.ApplyConfiguration(new WorkflowStepConfiguration());
        }
    }
}
