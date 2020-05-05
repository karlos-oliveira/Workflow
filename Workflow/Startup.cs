using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Workflow.Infra.Data;
using Workflow.Infra.Data.Repository;
using Workflow.Services;
using Workflow.Shared;

namespace Workflow
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks()
              .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddDbContext<WorkflowDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WorkflowConnection")));

            services.AddTransient<IGrupoAprovadorService, GrupoAprovadorService>();
            services.AddTransient<IGrupoAprovadorUsuarioService, GrupoAprovadorUsuarioService>();
            services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IStepService, StepService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IWorkflowService, WorkflowService>();
            services.AddTransient<IWorkflowStepService, WorkflowStepService>();
           
            services.AddTransient<IGrupoAprovadorRepository, GrupoAprovadorRepository>();
            services.AddTransient<IGrupoAprovadorUsuarioRepository, GrupoAprovadorUsuarioRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IStepRepository, StepRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IWorkflowRepository, WorkflowRepository>();
            services.AddTransient<IWorkflowStepRepository, WorkflowStepRepository>();
           

            services.AddScoped<IContext, WorkflowDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });
            app.UseHealthChecks("/ready", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("ready")
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
