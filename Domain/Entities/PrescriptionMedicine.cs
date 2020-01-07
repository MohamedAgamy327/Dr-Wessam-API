namespace Domain.Entities
{
    public class PrescriptionMedicine
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string EnglishNotes { get; set; }
        public string ArabicNotes { get; set; }
        public int FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public int Duration { get; set; }

    }
}
