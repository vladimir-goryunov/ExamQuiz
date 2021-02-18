using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models.Configuration
{
    public class AnswerEntityConfiguration : IEntityTypeConfiguration<AnswerEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder.ToTable("Answers");

            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();

            builder.Ignore(f => f.Events);
            //builder.HasMany(f => f.Events);
            builder.HasMany(f => f.Attachments);
        }
    }
}
