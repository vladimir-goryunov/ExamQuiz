using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsabilityFactoryExamQuiz.Model.EF.Models.Configuration
{
    class AnswerAttachmentEntityConfiguration : IEntityTypeConfiguration<AnswerAttachmentEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerAttachmentEntity> builder)
        {
            builder.ToTable("AnswerAttachments");

            builder.HasKey(f => f.Id);
            builder.HasIndex(f => f.Id).IsUnique();
            builder.Property(f => f.Id).IsRequired().ValueGeneratedNever();

            builder.HasIndex(f => f.AnswerId);

            builder.Property(f => f.MimeType).IsRequired();
            builder.Property(f => f.FileName).IsRequired();
            builder.Property(f => f.Created).IsRequired();
        }
    }
}
