﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workflow.Infra.Data;

namespace Workflow.Migrations
{
    [DbContext(typeof(WorkflowDBContext))]
    [Migration("20191023155958_InclusaoCampoEmailNoUsuario")]
    partial class InclusaoCampoEmailNoUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Workflow.Models.GrupoAprovador", b =>
                {
                    b.Property<Guid>("IdGrupoAprovador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrupoAprovador");

                    b.ToTable("GrupoAprovador");
                });

            modelBuilder.Entity("Workflow.Models.GrupoAprovadorUsuario", b =>
                {
                    b.Property<Guid>("IdGrupoAprovadorUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdGrupoAprovador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdGrupoAprovadorUsuario");

                    b.ToTable("GrupoAprovadorUsuario");
                });

            modelBuilder.Entity("Workflow.Models.Status", b =>
                {
                    b.Property<Guid>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BloqueiaAndamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("IdStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Workflow.Models.Step", b =>
                {
                    b.Property<Guid>("IdStep")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdGrupoAprovador")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStep");

                    b.ToTable("Step");
                });

            modelBuilder.Entity("Workflow.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Workflow.Models.Workflow", b =>
                {
                    b.Property<Guid>("IdWorkflow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdWorkflow");

                    b.ToTable("Workflow");
                });

            modelBuilder.Entity("Workflow.Models.WorkflowStep", b =>
                {
                    b.Property<Guid>("IdWorkflowStep")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStatus")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStep")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStepAnterior")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdStepProximo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdWorkflow")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsStepCorrente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.HasKey("IdWorkflowStep");

                    b.ToTable("WorkflowStep");
                });
#pragma warning restore 612, 618
        }
    }
}
