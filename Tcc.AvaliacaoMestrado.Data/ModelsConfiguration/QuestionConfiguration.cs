using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcc.AvaliacaoMestrado.Domain.Models;

namespace Tcc.AvaliacaoMestrado.Data.ModelsConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Statement).IsRequired().HasMaxLength(200);
            builder.HasOne(x => x.Form).WithMany(x => x.Questions).HasForeignKey(x => x.FormId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Options).WithOne(x => x.Question);
            builder.HasMany(x => x.Answers).WithOne(x => x.Question);
        }
    }
}
