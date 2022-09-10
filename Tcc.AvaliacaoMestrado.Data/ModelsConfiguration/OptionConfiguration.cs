using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tcc.AvaliacaoMestrado.Domain.Models;

namespace Tcc.AvaliacaoMestrado.Data.ModelsConfiguration
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.Value).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.Question).WithMany(x => x.Options).HasForeignKey(x => x.QuestionId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Answers).WithOne(x => x.Option);
        }
    }
}
