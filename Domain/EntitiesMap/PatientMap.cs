using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Domain.EntitiesMap
{
    public class PatientMap
    {
        public PatientMap(EntityTypeBuilder<Patient> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Birthday).HasColumnType("date");
            entityBuilder.Property(t => t.HusbandBirthday).HasColumnType("date");
            entityBuilder.HasOne(h => h.Knowing).WithMany(w => w.Patients).HasForeignKey(h => h.KnowingId);
            entityBuilder.HasOne(h => h.Occupation).WithMany(w => w.Patients).HasForeignKey(h => h.OccupationId);
            entityBuilder.HasOne(h => h.HusbandOccupation).WithMany(w => w.HusbandsPatients).HasForeignKey(h => h.HusbandOccupationId);
        }
    }
}
