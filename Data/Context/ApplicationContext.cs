using Data.SeedData;
using Domain.Entities;
using Domain.EntitiesMap;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);          
            new KnowingMap(modelBuilder.Entity<Knowing>());
            new PatientMap(modelBuilder.Entity<Patient>());
            new MedicineMap(modelBuilder.Entity<Medicine>());
            new FrequencyMap(modelBuilder.Entity<Frequency>());           
            new OccupationMap(modelBuilder.Entity<Occupation>());
            new InstructionMap(modelBuilder.Entity<Instruction>());
            new MedicineTypeMap(modelBuilder.Entity<MedicineType>());
            new PrescriptionMap(modelBuilder.Entity<Prescription>());
            new PrescriptionMedicineMap(modelBuilder.Entity<PrescriptionMedicine>());
            new PrescriptionInstructionMap(modelBuilder.Entity<PrescriptionInstruction>());
           
            modelBuilder.Seed();
        }

        public DbSet<Knowing> Knowings { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Frequency> Frequencys { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Instruction> Instructions { get; set; }     
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
        public DbSet<PrescriptionInstruction> PrescriptionInstructions { get; set; }
    }
}
