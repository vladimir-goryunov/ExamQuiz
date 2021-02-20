﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsabilityFactoryExamQuiz.Model.EF;

namespace UsabilityFactoryExamQuiz.Model.EF.Migrations
{
    [DbContext(typeof(QuestionaireDBContext))]
    partial class QuestionaireDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerAttachmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerEntityId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("AnswerAttachments");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("QuestionEntityId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnswerEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClientTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerEntityId");

                    b.HasIndex("AnswerId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("AnswerEvents");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerAttachmentEntity", b =>
                {
                    b.HasOne("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEntity", null)
                        .WithMany("Attachments")
                        .HasForeignKey("AnswerEntityId");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEntity", b =>
                {
                    b.HasOne("UsabilityFactoryExamQuiz.Model.EF.Models.QuestionEntity", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionEntityId");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEventEntity", b =>
                {
                    b.HasOne("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEntity", null)
                        .WithMany("Events")
                        .HasForeignKey("AnswerEntityId");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.AnswerEntity", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("UsabilityFactoryExamQuiz.Model.EF.Models.QuestionEntity", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
