using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntitiesMap
{
    public class InstructionMap
    {
        public InstructionMap(EntityTypeBuilder<Instruction> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.ArabicName).IsRequired();
            entityBuilder.Property(t => t.EnglishName).IsRequired();
        }
    }
}
