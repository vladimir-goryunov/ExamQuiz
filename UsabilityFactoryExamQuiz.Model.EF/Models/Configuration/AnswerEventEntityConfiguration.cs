using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models.Configuration
{
    public class AnswerEventEntityConfiguration : IEntityTypeConfiguration<AnswerEventEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEventEntity> builder)
        {
            builder.ToTable("AnswerEvents");

            builder.HasNoKey();
            builder.Property(f => f.Type).IsRequired();
            builder.Property(f => f.ClientTime).IsRequired();
        }
    }
}
