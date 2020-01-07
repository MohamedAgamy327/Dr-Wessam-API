using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class PrescriptionMedicineMap
    {
        public PrescriptionMedicineMap(EntityTypeBuilder<PrescriptionMedicine> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.MedicineId, t.PrescriptionId });
            entityBuilder.HasOne(h => h.Frequency).WithMany(w => w.PrescriptionMedicines).HasForeignKey(h => h.FrequencyId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(h => h.Medicine).WithMany(w => w.PrescriptionMedicines).HasForeignKey(h => h.MedicineId);
            entityBuilder.HasOne(h => h.Prescription).WithMany(w => w.PrescriptionMedicines).HasForeignKey(h => h.PrescriptionId);

        }
    }
}
