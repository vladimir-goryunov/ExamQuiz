using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsabilityFactoryExamQuiz.Model.EF.Models.Configuration
{
    public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionEntity> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();
            //builder.Property(f => f.Answers).IsRequired();
        }
    }
}
