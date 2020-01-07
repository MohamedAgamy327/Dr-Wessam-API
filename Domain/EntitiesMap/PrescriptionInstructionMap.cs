using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class PrescriptionInstructionMap
    {
        public PrescriptionInstructionMap(EntityTypeBuilder<PrescriptionInstruction> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.InstructionId, t.PrescriptionId });
            entityBuilder.HasOne(h => h.Instruction).WithMany(w => w.PrescriptionInstructions).HasForeignKey(h => h.InstructionId);
            entityBuilder.HasOne(h => h.Prescription).WithMany(w => w.PrescriptionInstructions).HasForeignKey(h => h.PrescriptionId);
        }
    }
}
