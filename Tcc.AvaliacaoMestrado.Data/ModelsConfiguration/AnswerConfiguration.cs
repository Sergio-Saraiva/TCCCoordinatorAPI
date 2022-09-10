using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcc.AvaliacaoMestrado.Domain.Models;

namespace Tcc.AvaliacaoMestrado.Data.ModelsConfiguration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId).IsRequired(false);
            builder.HasOne(x => x.Option).WithMany(x => x.Answers).HasForeignKey(x => x.OptionId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
