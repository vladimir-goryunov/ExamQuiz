using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsabilityFactoryExamQuiz.Model.EF.Models.Configuration
{
    public class AnswerEventEntityConfiguration : IEntityTypeConfiguration<AnswerEventEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEventEntity> builder)
        {
            
            builder.ToTable("AnswerEvents");

            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();
            builder.Property(f => f.Id).IsRequired().ValueGeneratedNever();

            builder.HasIndex(f => f.AnswerId);

            builder.Property(f => f.Type).IsRequired();
            builder.Property(f => f.ClientTime).IsRequired();
        }
    }
}
