using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class PrescriptionMap
    {
        public PrescriptionMap(EntityTypeBuilder<Prescription> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.HasOne(h => h.Patient).WithMany(w => w.Prescriptions).HasForeignKey(h => h.PatientId);
        }
    }
}
